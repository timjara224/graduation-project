using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel; // 指向 Panel
    public Button closeButton;    // 關閉按鈕

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false); // 開始時關閉面板
        closeButton.onClick.AddListener(ClosePanel); // 綁定按鈕事件
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // 遊戲暫停/繼續
    }

    void ClosePanel()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
