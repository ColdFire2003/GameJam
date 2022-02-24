using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private bool _ActiveCredits;
    [SerializeField] private GameObject Credits;

    #region Buttons
    public void StartGame()
    {
        // will load the scene we give it
        SceneManager.LoadScene("main scen");
    }

    public void BackToMainMenu()
    {
        // will load the scene we give it
        SceneManager.LoadScene("MainMenu");
    }

    public void InfoMenu()
    {
        // will load the scene we give it
        SceneManager.LoadScene("InfoMenu");
    }
    public void PopUpCredits()
    {
        // will make a pop up the settings menu
        if (_ActiveCredits == true)
        {
            Credits.SetActive(true);
        }
        else Credits.SetActive(false);
    }

    public void QuitGame()
    {
        // closes the application
        print("log out");
        Application.Quit();
    }
    #endregion
}