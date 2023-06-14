using UnityEngine;
using TMPro;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public void UpdateScoreText(string text)
    {
        _scoreText.text = text;
    }
}
