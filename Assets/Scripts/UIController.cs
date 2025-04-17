using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Button homeButton;
    public Button resetButton;
    public TMP_Text boxCountText; // Inspector에서 이 오브젝트를 할당해주세요.
    
    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        // GameManager 싱글톤이 존재하면, Home과 Reset 버튼에 이벤트를 등록합니다.
        if (gameManager != null)
        {
            homeButton.onClick.RemoveAllListeners();
            resetButton.onClick.RemoveAllListeners();

            homeButton.onClick.AddListener(gameManager.GoToMainMenu);
            resetButton.onClick.AddListener(gameManager.ResetLevel);
        }
        else
        {
            Debug.LogError("GameManager.instance is null!");
        }

        gameManager.OnBox += UpdateBoxCountUI;
        // gameManager.OnGameClear +=
    }

    void Update()
    {
       // UpdateBoxCountUI();
    }
    
    void UpdateBoxCountUI(int boxCount)
    {
        // BoxController[] boxes = FindObjectsOfType<BoxController>();
        // int totalBoxes = boxes.Length;
        // int onTargetCount = 0;
        //
        // foreach (BoxController box in boxes)
        // {
        //     if (box.isOnTarget)
        //     {
        //         onTargetCount++;
        //     }
        // }
        
        if (boxCountText != null)
        {
            boxCountText.text = "Boxes: " + boxCount;// + " / " + totalBoxes;
        }
    }
}
