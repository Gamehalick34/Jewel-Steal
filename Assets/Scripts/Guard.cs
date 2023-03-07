using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Guard : MonoBehaviour
{
    //sets up the AI states
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
        //creates a circle checking for when player is close
        PlayerInSightRange = Physics.CheckSphere(transform.position, sightrange, whatisplayer);

        //if player is not in sight
        if(!PlayerInSightRange)
        {
            Patrolling();
        }
        //if player is in sight
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
        //grabs current player position and walk to it
        guard.SetDestination(player.position);
    }
    
    public void TakeDamage()
    {
        //when AI is shot stops the AI from working
        StartCoroutine(freeze());
    }

    public void slowDamage()
    {
        /*
        if AI has already been stopped instead the ai speed will 
        start going up by a factor of 1
        */
        guard.speed = guard.speed + 1;
    }

    void OnTriggerEnter()
    {
        //when AI collids with player elims player and triggers lose scene
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

    IEnumerator freeze()
    {
        //stops ai for 5 sec and then goes back to regular script
        guard.enabled = false;
        yield return new WaitForSeconds(5f);
        guard.enabled = true;
    }
}
