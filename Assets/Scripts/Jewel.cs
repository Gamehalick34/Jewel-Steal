using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jewel : MonoBehaviour
{
    //will use the variables from "Button" script
    public Button script;
    
    void OnTriggerEnter()
    {
        //takes player to win scene
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        script.tazer.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}
