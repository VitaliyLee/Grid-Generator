using UnityEngine;

[CreateAssetMenu(fileName = "NewGridSettings", menuName = "new GridSettings")]
public class GridSettings : ScriptableObject
{
    [SerializeField] private GameObject _tile;
    [SerializeField] private RectTransform _gridRectTransform;
    [SerializeField] private int _maxGridWidth;
    [SerializeField] private int _maxGridHeight;
    [SerializeField] private float _shuffleSpeed;

    public GameObject Tile => _tile;
    public RectTransform GridRectTransform => _gridRectTransform;
    public int MaxGridWidth => _maxGridWidth;
    public int MaxGridHeight => _maxGridHeight;
    public float ShuffleSpeed => _shuffleSpeed;
}
