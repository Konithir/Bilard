using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/BallColorSettings")]
public class BallColorSettings : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private int _points;

    public string Name
    {
        get { return _name; }
    }

    public Color Color
    {
        get { return _color; }
    }

    public int Points
    {
        get { return _points; }
    }
}
