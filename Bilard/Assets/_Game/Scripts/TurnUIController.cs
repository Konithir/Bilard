using TMPro;
using UnityEngine;

public class TurnUIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _turnText;

    public void UpdateTurnText(string text)
    {
        _turnText.text = text;
    }
}
