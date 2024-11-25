using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
   public void ReplayGame()
   {
      SceneManager.LoadScene("LASCENEPOURLEJEUVIDEAL");
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
