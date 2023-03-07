using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
   public void LoseGame()
   {
     SceneManager.LoadScene (sceneBuildIndex: 0);
   }
   public void QuitGame ()
   {
    Application.Quit();
   }
}
