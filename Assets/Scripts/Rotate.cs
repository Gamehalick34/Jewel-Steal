using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject diamond;
    [SerializeField] [Range(0,1)] float speed = 1f;
    [SerializeField] [Range(0,100)] float range = 1f;


    void Update()
    {
        float yPos = Mathf.PingPong(Time.time * speed, 1) * range;
        transform.position = new Vector3(transform.position.x, yPos + 5, transform.position.z);

        transform.Rotate(0f, 1f, 0f, Space.Self);

    }
}
