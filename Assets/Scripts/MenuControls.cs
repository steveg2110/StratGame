using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructionsMenu;

    
    public void PlayGameButton() {
        SceneManager.LoadScene("GameScene");
    }

    public void InstructionsButton() {
        mainMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void InstructionsBackButton() {
        instructionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGameButton() {
        Application.Quit();
    }

}
