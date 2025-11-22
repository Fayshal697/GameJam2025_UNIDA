using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("HUD Elements")]
    public TMP_Text scoreText;
    public TMP_Text powerUpText;

    private void Awake()
    {
        if (powerUpText != null)
            powerUpText.gameObject.SetActive(false);
    }

    public void UpdateScore(float score)
    {
        if (scoreText != null)
            scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void ShowPowerUp(string text)
    {
        if (powerUpText == null) return;

        powerUpText.text = text;
        powerUpText.gameObject.SetActive(true);

        CancelInvoke(nameof(HidePowerUp));
        Invoke(nameof(HidePowerUp), 1.5f);
    }

    private void HidePowerUp()
    {
        if (powerUpText != null)
            powerUpText.gameObject.SetActive(false);
    }
}
