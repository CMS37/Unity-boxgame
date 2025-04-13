using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Button homeButton;
    public Button resetButton;
    public TMP_Text boxCountText; // Inspector에서 이 오브젝트를 할당해주세요.
    
    void Start()
    {
        // GameManager 싱글톤이 존재하면, Home과 Reset 버튼에 이벤트를 등록합니다.
        if (GameManager.instance != null)
        {
            homeButton.onClick.RemoveAllListeners();
            resetButton.onClick.RemoveAllListeners();

            homeButton.onClick.AddListener(GameManager.instance.GoToMainMenu);
            resetButton.onClick.AddListener(GameManager.instance.ResetLevel);
        }
        else
        {
            Debug.LogError("GameManager.instance is null!");
        }
    }

    void Update()
    {
        UpdateBoxCountUI();
    }
    
    void UpdateBoxCountUI()
    {
        BoxController[] boxes = FindObjectsOfType<BoxController>();
        int totalBoxes = boxes.Length;
        int onTargetCount = 0;
        
        foreach (BoxController box in boxes)
        {
            if (box.isOnTarget)
            {
                onTargetCount++;
            }
        }
        
        if (boxCountText != null)
        {
            boxCountText.text = "Boxes: " + onTargetCount + " / " + totalBoxes;
        }
    }
}
