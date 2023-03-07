using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{

    public NavMeshAgent guard;
    public Transform player;
    public LayerMask whatisground,whatisplayer;

    //patrol
    public Vector3 walkP;
    bool walkPSet;
    public float walkPointRange;

    //view
    public float sightrange;
    public bool PlayerInSightRange;

    //sets up rules on wake
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        guard = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //looks for player in sight
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);

        if(!PlayerInSightRange)
        {
            Patrolling();
        }
        if(PlayerInSightRange)
        {
            Chaseplayer();
        }
    }

    private void Patrolling()
    {
        //looks for a point when one is made
        if(!walkPSet) SearchWalkPoint();

        if(walkPSet)
        {
            guard.SetDestination(walkP);
        }

        //makes guard start walking to point
        Vector3 distanceToWalkPoint = transform.position - walkP;

        //when guard arrives to walk point guard will look for new walk point
        if(distanceToWalkPoint.magnitude <1f)
        {
            walkPSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        //will find a random point to walk to
        float ranomZ = Random.Range(-walkPointRange, walkPointRange);
        float ranomX = Random.Range(-walkPointRange, walkPointRange);

        //set up where guard will walk to
        walkP = new Vector3(transform.position.x + ranomX, transform.position.y, transform.position.z + ranomZ);

        if(Physics.Raycast(walkP, -transform.up, 2f, whatisground))
        {
            walkPSet = true;
        }
    }

    private void Chaseplayer()
    {
        //in the name
        guard.SetDestination(player.position);
    }
    
    public void TakeDamage()
    {
        StartCoroutine(freeze());
    }

    public void slowDamage()
    {
        guard.speed = guard.speed + 1;
    }

    void OnTriggerEnter()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

    IEnumerator freeze()
    {
        guard.enabled = false;
        yield return new WaitForSeconds(5f);
        guard.enabled = true;
    }
}
