using TMPro;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    public IntVariable score;
    public TMP_Text questionText;
    private void OnEnable()
    {
        score.OnValueChanged += UpdateUI;
    }

    private void OnDisable()
    {
        score.OnValueChanged -= UpdateUI;
    }

    private void Start()
    {
        questionText.text = $"{score.Value}/15";
    }

    private void UpdateUI(int newValue)
    {
        questionText.text = $"{score.Value}/15";
    }
}




