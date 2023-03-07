using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         if (Input.GetKeyDown(KeyCode.Escape))
      {
        SceneManager.LoadScene (sceneBuildIndex: 1);
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        SceneManager.LoadScene (sceneBuildIndex: 1);
      }
    }  
}
