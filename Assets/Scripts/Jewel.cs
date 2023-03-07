using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jewel : MonoBehaviour
{
    public Button script;
    
    void OnTriggerEnter()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        script.tazer.SetActive(false);
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }

    //public float xAngle, yAngle, zAngle;
   //Jewel.transform.position = new Vector3(0.75f, 0.0f, 0.0f);
}
