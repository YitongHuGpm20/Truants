using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MainMenuSystem : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject loginScreen;
    public GameObject firstButtons;
    public GameObject secondButtons;
    public GameObject continueWindow;
    public GameObject settingsWindow;
    public GameObject creditsWindow;

    public void NewGame()
    {
        mainMenu.SetActive(false);
        loginScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game Already!");
    }

    public void ContinueGame()
    {
        firstButtons.SetActive(false);
        secondButtons.SetActive(false);
        continueWindow.SetActive(true);
    }

    public void Settings()
    {
        firstButtons.SetActive(false);
        secondButtons.SetActive(false);
        settingsWindow.SetActive(true);
    }

    public void Credits()
    {
        firstButtons.SetActive(false);
        secondButtons.SetActive(false);
        creditsWindow.SetActive(true);
    }

    public void BackToMainMenu()
    {
        GameObject thisbutton = EventSystem.current.currentSelectedGameObject;
        thisbutton.transform.parent.gameObject.SetActive(false);
        firstButtons.SetActive(true);
        secondButtons.SetActive(true);
    }
}
