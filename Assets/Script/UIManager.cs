using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text powerUpText;

    public void UpdateScore(float score)
    {
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public void ShowPowerUp(string text)
    {
        powerUpText.text = text;
        powerUpText.gameObject.SetActive(true);

        CancelInvoke(nameof(HidePowerUp));
        Invoke(nameof(HidePowerUp), 1.5f);
    }

    void HidePowerUp()
    {
        powerUpText.gameObject.SetActive(false);
    }
}
