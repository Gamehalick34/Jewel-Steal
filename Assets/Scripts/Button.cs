using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool alarm = false;
    bool enter = false;

    public GameObject guard;
    public GameObject ButtonText;
    public GameObject tazer;

    public GameObject lazerwall;

    public GameObject wallcode;

    void Start()
    {
        //disables the button UI on start
        ButtonText.SetActive(false);
    }

    void Update()
    {
        //when player gets into triggerbox and the alarm has not been triggered yet
        if(enter == true && alarm == false)
        {  
            ButtonText.SetActive(true);
        
            if(Input.GetButtonDown("E"))
            {
                //stops game
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //turns on the button UI
            wallcode.SetActive(true);
            }
        }
        else
        {
            //UI telling player to to press "E"
            ButtonText.SetActive(false);
        }

    }

    //trigger bool
    void OnTriggerEnter()
    {
        enter = true;
    }
    void OnTriggerExit()
    {
        enter = false;
    }
}