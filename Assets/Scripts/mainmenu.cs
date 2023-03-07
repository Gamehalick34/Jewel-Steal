using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void PlayGame()
   {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    SceneManager.LoadScene(sceneBuildIndex: 1);
   }
   public void QuitGame ()
   {
    Application.Quit();
   }
}
