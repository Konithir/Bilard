using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameSettings _mainSettings;

    [SerializeField]
    private ScoreUIController _scoreUIController;

    [SerializeField]
    private TurnUIController _turnUIController;

    [SerializeField]
    private PlayerBallController _playerBallController;

    private Score _score;

    private int _currentTurn;

    private List<ScoreBallController> _balls = new List<ScoreBallController>();

    private float _movementLimit = 0.1f;

    public bool GameEnded
    {
        get { return _currentTurn >= _mainSettings.GameTurns; }
    }

    public bool BallsMoving
    {
        get { return CheckIfBallsAreMoving(); }
    }

    private void Start()
    {
        SetUpScore();
        SetUpTurns();
    }

    private void SetUpScore()
    {
        _score = new Score();
        _score.ScoreValue = 0;
    }

    private void SetUpTurns()
    {
        _currentTurn = 0;
    }

    public void Score(int value)
    {
        _score.ScoreValue += value;
        _scoreUIController.UpdateScoreText(_score.ScoreValue.ToString());
    }

    public void NextTurn()
    {
        _currentTurn++;
        _turnUIController.UpdateTurnText($"{_currentTurn} / {_mainSettings.GameTurns}");
    }

    public void RegisterBallToList(ScoreBallController ball)
    {
        _balls.Add(ball);
    }

    private bool CheckIfBallsAreMoving()
    {
        for(int i = 0; i < _balls.Count; i++)
        {
            if(_balls[i].gameObject.activeInHierarchy && _balls[i].Rigidbody.velocity.magnitude >= _movementLimit)
            {
                return true;
            }
        }

        if(_playerBallController.Rigidbody.velocity.magnitude >= _movementLimit)
        {
            return true;
        }

        return false;
    }
}
