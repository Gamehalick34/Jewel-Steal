using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public TMP_InputField numHolder;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;
    public GameObject B5;
    public GameObject B6;
    public GameObject B7;
    public GameObject B8;
    public GameObject B9;
    public GameObject B0;
    public GameObject clrB;
    public GameObject entrB;

    public Button script;

    //when UI button is pressed it will add number to text field
    public void b1()
    {
        numHolder.text = numHolder.text + "1";
    }

    public void b2()
    {
        numHolder.text = numHolder.text + "2";
    }
    
    public void b3()
    {
        numHolder.text = numHolder.text + "3";
    }
    
    public void b4()
    {
        numHolder.text = numHolder.text + "4";
    }
    
    public void b5()
    {
        numHolder.text = numHolder.text + "5";
    }
    
    public void b6()
    {
        numHolder.text = numHolder.text + "6";
    }
    
    public void b7()
    {
        numHolder.text = numHolder.text + "7";
    }
    
    public void b8()
    {
        numHolder.text = numHolder.text + "8";
    }
    
    public void b9()
    {
        numHolder.text = numHolder.text + "9";
    }

    public void b0()
    {
        numHolder.text = numHolder.text + "0";
    }

    //will empty textfield
    public void clrEvent()
    {
        numHolder.text = null;
    }

    public void entrEvent()
    {
        if (numHolder.text == "1234")
        {
            script.wallcode.SetActive(false);
            Activate();
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("wall disabled");
        }
        else
        {
            Debug.Log("incorrect");
        }
    }

    void Activate()
    {
        script.lazerwall.SetActive(false);
        script.guard.SetActive(true);
        script.tazer.SetActive(true);
        Debug.Log("Disabled wall");
        script.alarm = true;
    }
}