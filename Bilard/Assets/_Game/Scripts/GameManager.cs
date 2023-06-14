using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;

    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    public GameController GameController
    {
        get { return _gameController; }
    }

    private void Awake()
    {
        _instance = this;
    }
}
