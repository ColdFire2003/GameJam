using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private bool _ActiveSettings;
    private bool _ActiveCredits;
    public GameObject Credits;
    public GameObject Settings;

    #region Buttons
    public void StartGame()
    {
        // will load the scene we give it
        SceneManager.LoadScene("Test");
    }

    public void PopUpSettings()
    {
        // will make a pop up the settings menu
        if (_ActiveSettings == true)
        {
            Settings.SetActive(true);
            Credits.SetActive(false);
        }
        else Settings.SetActive(false);
    }

    public void PopUpCredits()
    {
        // will make a pop up the settings menu
        if (_ActiveCredits == true)
        {
            Settings.SetActive(false);
            Credits.SetActive(true);
        }
        else Credits.SetActive(false);
    }

    public void QuitGame()
    {
        // closes the application
        Application.Quit();
    }
    #endregion

    #region Settings
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // when press ESC deactivates UI
        {
            _ActiveSettings = false; // Deactivates UI
            PopUpSettings();

            _ActiveCredits = false; // Deactivates UI
            PopUpCredits();
        }
    }
    public void SetVolume(float volume)
    {
     
    }
    #endregion
}