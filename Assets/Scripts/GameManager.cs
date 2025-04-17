using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private BoxController[] boxes;

    public Action<int> OnBox;       // 타겟에 올라갔을떄
    public Action OnGameClear;      // 게임 클리어
    
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
        
        boxes = FindObjectsOfType<BoxController>();
        OnGameClear += LoadNextLevel;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        // if (AllBoxesOnTarget())
        // {
        //     LoadNextLevel();
        // }
    }

    public void OnTraget()
    {
        int i = 0;
        foreach (BoxController box in boxes)
        {
            if (box.isOnTarget)
                i += 1;
        }
        
        OnBox?.Invoke(i);
        
        if(boxes.Length == i)
            OnGameClear?.Invoke();
        
    }
    
    
    bool AllBoxesOnTarget()
    {
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
