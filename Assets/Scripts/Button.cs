using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool alarm = false;
    bool enter = false;

    //public GameObject laserWall;
    public GameObject guard;
    public GameObject ButtonText;
    public GameObject tazer;

    public GameObject lazerwall;

    public GameObject wallcode;

    void Start()
    {
        ButtonText.SetActive(false);
    }

    void Update()
    {
        if(enter == true && alarm == false)
        {  
        ButtonText.SetActive(true);

            if(Input.GetButtonDown("E"))
            {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            wallcode.SetActive(true);
            }
        }
        else
        {
            ButtonText.SetActive(false);
        }

    }

    void OnTriggerEnter()
    {
        enter = true;
    }
    void OnTriggerExit()
    {
        enter = false;
    }
}