using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField]
    private int _gameTurns;

    [SerializeField]
    private List<BallColorSettings> _ballColorSettings;

    public int GameTurns
    {
        get { return _gameTurns; }
    }

    public List<BallColorSettings> BallColorSettings
    {
        get { return _ballColorSettings; }
    }
}
