using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
   public void WinGame()
   {
     SceneManager.LoadScene (sceneBuildIndex: 0);
   }
   public void QuitGame ()
   {
    Application.Quit();
   }
}
