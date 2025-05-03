using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class QuestionManager : MonoBehaviour
{
    public GameObject questionPanel;
    public TextMeshProUGUI questionText;
    public Button[] optionButtons;
    public TextMeshProUGUI[] optionTexts;

    public PauseMenu pauseMenu; // 連到 PauseMenu.cs 控制金錢和等級

    private float timer = 0f;
    private float questionInterval = 3f;

    private int correctAnswerIndex;

    void Start()
    {
        questionPanel.SetActive(false);

        // 綁定按鈕事件
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i; // 本地 copy 防止閉包 bug
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void Update()
    {
        if (!startPan.hasGameStarted) return; // 🔥 沒開始遊戲就不執行

        timer += Time.deltaTime;

        if (timer >= questionInterval)
        {
            timer = 0f;
            ShowRandomQuestion();
        }
    }


    void ShowRandomQuestion()
    {
        questionPanel.SetActive(true);

        // 題庫範例（你可以之後擴充）
        string question = "Chooe 1？";
        string[] options = { "1", "2", "3", "4" };
        correctAnswerIndex = 0;

        questionText.text = question;
        for (int i = 0; i < 4; i++)
        {
            optionTexts[i].text = options[i];
        }
    }

    void CheckAnswer(int selectedIndex)
    {
        if (selectedIndex == correctAnswerIndex)
        {
            pauseMenu.AddMoney(1000);
        }

        questionPanel.SetActive(false);
    }
}
