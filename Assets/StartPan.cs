using UnityEngine;
using UnityEngine.UI;

public class start : MonoBehaviour
{
    public GameObject StartPanel; // «ü¦V Panel
    public Button closeButton;    // Ãö³¬«ö¶s

    private bool isPaused = false;

    void Start()
    {
        StartPanel.SetActive(true); 
        closeButton.onClick.AddListener(ClosePanel);
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
    }
}
