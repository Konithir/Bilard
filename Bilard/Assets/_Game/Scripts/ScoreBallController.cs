using UnityEngine;

public class ScoreBallController : MonoBehaviour
{
    [SerializeField]
    private BallColorSettings _settings;

    [SerializeField]
    private float _rigidbodySleepValue = 0.4f;

    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private GameController _gameController;

    [SerializeField]
    private Renderer _renderer;

    public Rigidbody Rigidbody
    {
        get { return _rigidbody; }
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        RecolorBall();
    }

    private void RecolorBall()
    {
        _renderer.material.color = _settings.Color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("pole"))
        {
            _gameController.Score(_settings.Points);
            gameObject.SetActive(false);
        }
    }

    private void Init()
    {
        _rigidbody.sleepThreshold = _rigidbodySleepValue;
        _gameController.RegisterBallToList(this);
    }
}
