using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public Button closeButton;

    public TextMeshProUGUI playTimeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyDisplayText;

    private float playTime = 0f;
    private int level = 1;
    private int money = 1000;
    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        closeButton.onClick.AddListener(ClosePanel);
    }

    void Update()
    {
        if (!isPaused)
        {
            playTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }

        // 更新右上角金錢顯示
        moneyDisplayText.text = "$" + money.ToString();
    }

    void TogglePanel()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;

        if (isPaused)
        {
            UpdatePanelInfo();
        }
    }

    void ClosePanel()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void UpdatePanelInfo()
    {
        // 時間格式轉換為 mm:ss
        int minutes = Mathf.FloorToInt(playTime / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);
        playTimeText.text = $"時間:{minutes:D2}:{seconds:D2}";

        levelText.text = $"等級:{level}";
        moneyText.text = $"金錢:${money}";
    }

    // 可加這個方法用於增加金錢
    public void AddMoney(int amount)
    {
        money += amount;

        int newLevel = money / 1000;

        if (newLevel > level)
        {
            level = newLevel;
        }
    }

}
