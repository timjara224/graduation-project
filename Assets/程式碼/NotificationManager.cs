using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text messageText;
    public Button closeButton;

    void Start()
    {
        panel.SetActive(false);

        closeButton.onClick.AddListener(() =>
        {
            panel.SetActive(false);
        });

        ShowNotification("歡迎來到角色養成世界！");
    }

    public void ShowNotification(string message, float duration = 0f)
    {
        messageText.text = message;
        panel.SetActive(true);

        if (duration > 0f)
        {
            CancelInvoke();
            Invoke(nameof(HideNotification), duration);
        }
    }

    public void HideNotification()
    {
        panel.SetActive(false);
    }
}
