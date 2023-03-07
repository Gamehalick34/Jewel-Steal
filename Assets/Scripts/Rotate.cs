using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //gameobject needs to be selected
    public GameObject diamond;
    [SerializeField] [Range(0,1)] float speed = 1f;
    [SerializeField] [Range(0,100)] float range = 1f;


    void Update()
    {
        //diamond jumps up and down
        float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
        transform.position = new Vector3(transform.position.x, yPos + 5, transform.position.z);

        //diamond rotates in place
        transform.Rotate(0f, 1f, 0f, Space.Self);

    }
}
