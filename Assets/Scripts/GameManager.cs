using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlayerPrefs.SetInt("LastStage", SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        if (AllBoxesOnTarget())
        {
            LoadNextLevel();
        }
    }
    bool AllBoxesOnTarget()
    {
        BoxController[] boxes = FindObjectsOfType<BoxController>();
        foreach (BoxController box in boxes)
        {
            if (!box.isOnTarget)
                return false;
        }
        return true;
    }

    void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("모든 씬 완료!");
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
