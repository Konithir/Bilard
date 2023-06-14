using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private float _maxForce;

    [SerializeField]
    private int _pushForceMultiplyer = 100;

    [SerializeField]
    private int _rotationStep = 15;

    [SerializeField]
    private int _forceIncreaseSpeed = 10;

    [SerializeField]
    private int _startForce = 1;

    [SerializeField]
    private float _rigidbodySleepValue = 0.4f;

    [SerializeField]
    private float _drawingLineForceMultiplyer = 0.2f;

    [SerializeField]
    private Rigidbody _rigidBody;

    [SerializeField]
    private LineRenderer _lineRenderer;

    private float _currentForce = 1;

    private Vector3 _currentDirection;

    public Rigidbody Rigidbody
    {
        get { return _rigidBody; }
    }

    private void Start()
    {
        ResetValues();
        _gameController.NextTurn();
    }

    void Update()
    {
        CheckForInput();
    }

    private void CheckForInput()
    {
        if(Input.GetKey(KeyCode.W))
        {
            IncreaseForce();
        }

        if (Input.GetKey(KeyCode.S))
        {
            DecreaseForce();
        }

        if (Input.GetKey(KeyCode.A))
        {
            TurnRight();
        }

        if (Input.GetKey(KeyCode.D))
        {
            TurnLeft();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Push();
        }

        DrawForce();
    }

    private void Push()
    {
        if (_gameController.BallsMoving || _gameController.GameEnded)
            return;

        _rigidBody.AddForce(_currentDirection * _currentForce * _pushForceMultiplyer);

        _gameController.NextTurn();
    }

    private void IncreaseForce()
    {
        if (_currentForce >= _maxForce)
            return;

        _currentForce += Time.deltaTime * _forceIncreaseSpeed;
    }

    private void DecreaseForce()
    {
        if (_currentForce <= 0)
            return;

        _currentForce -= Time.deltaTime * _forceIncreaseSpeed;
    }

    private void TurnLeft()
    {
        _currentDirection = Quaternion.Euler(0, _rotationStep * Time.deltaTime, 0) * _currentDirection;
    }

    private void TurnRight()
    {
        _currentDirection = Quaternion.Euler(0, -_rotationStep * Time.deltaTime, 0) * _currentDirection;
    }

    private void ResetValues()
    {
        _currentForce = _startForce;
        _currentDirection = transform.forward;
        _rigidBody.sleepThreshold = _rigidbodySleepValue;
    }

    private void DrawForce()
    {
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, transform.position + (_currentDirection * _currentForce) * _drawingLineForceMultiplyer);
    }
}
