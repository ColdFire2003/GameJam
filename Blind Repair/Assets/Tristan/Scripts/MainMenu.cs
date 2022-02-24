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
        SceneManager.LoadScene("Test");
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
        Application.Quit();
    }
    #endregion
}