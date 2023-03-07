using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public float speedH = 3.0f;
    public float speedV = 3.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float minPitch = -90f;
    private float maxPitch = 70f;
    bool movement;

    void Update()
    {
        movement = Player_Movement.cStop;

        //when game is unpaused camera is free
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
