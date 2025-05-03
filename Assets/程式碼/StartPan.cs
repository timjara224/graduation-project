using UnityEngine;
using UnityEngine.UI;

public class startPan : MonoBehaviour
{
    public GameObject StartPanel; // 指向 Panel
    public Button closeButton;    // 關閉按鈕

    private bool isPaused = false;

    public static bool hasGameStarted = false; // 🔥 全域靜態變數

    void Start()
    {
        StartPanel.SetActive(true);
        closeButton.onClick.AddListener(ClosePanel);
        Time.timeScale = 0; // 避免遊戲一開始就動
    }

    void Update()
    {
    }

    void TogglePanel()
    {
        isPaused = !isPaused;
        StartPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    void ClosePanel()
    {
        isPaused = false;
        StartPanel.SetActive(false);
        Time.timeScale = 1;

        hasGameStarted = true; // ✅ 告訴其他腳本：遊戲開始了
    }
}
