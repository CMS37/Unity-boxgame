using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button continueButton;
    void Start()
    {
        if (PlayerPrefs.HasKey("LastStage"))
        {
            continueButton.interactable = true;
        }
        else
        {
            continueButton.interactable = false;
        }
    }
    public void StartGame()
    {
        if (PlayerPrefs.HasKey("LastStage"))
        {
            PlayerPrefs.DeleteKey("LastStage");
        }
        SceneManager.LoadScene("Level0");
    }

    public void ContinueGame()
    {
        int lastStage = PlayerPrefs.GetInt("LastStage", 0);
        SceneManager.LoadScene(lastStage);
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
