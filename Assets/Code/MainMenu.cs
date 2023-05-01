using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject CreditScreen;
    public GameObject MainMenuScreen;
   

    public void DoExitGame()
    {
        Debug.Log("Game is quitting");

       
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Starting Game");

        
    }

    public void OpenCredits()
    {
        Debug.Log("Opening Creditview");

        CreditScreen.SetActive(true);
        MainMenuScreen.SetActive(false);

        
    }

    public void CloseCredits() 
    {
        Debug.Log("Closing Creditview");

        CreditScreen.SetActive(false);
        MainMenuScreen.SetActive(true);

        
    }

  
}
