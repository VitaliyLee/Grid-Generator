using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainEntryPoint : MonoBehaviour
{
    [SerializeField] private LetterDataSet _letterDataSet;
    [SerializeField] private GridSettings _gridSettings;
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private TMP_InputField _widthField;
    [SerializeField] private TMP_InputField _heightField;

    private int gridWidth = 3;
    private int gridHight = 3;
    private int maxCells;

    private bool canMove = false;

    private GridController gridController;

    private void Start()
    {
        gridController = new GridController( _gridSettings,
            _gridLayout, _letterDataSet);

        maxCells = _gridSettings.MaxGridWidth * _gridSettings.MaxGridHeight;

        CardPooler.Warm(_gridSettings.Tile, transform, maxCells);

        CreateGrid();
    }

    private void Update()
    {
        if (canMove)
        {
            gridController.MoveCards();
        }
    }

    public void CreateGrid()
    {
        canMove = false;
        if (int.Parse(_widthField.text) * int.Parse(_heightField.text) > maxCells)
        {
            _widthField.text = _gridSettings.MaxGridWidth.ToString();
            _heightField.text = _gridSettings.MaxGridHeight.ToString();
        }

        gridWidth = int.Parse(_widthField.text);
        gridHight = int.Parse(_heightField.text);
        gridController.GridCreator(gridWidth, gridHight);
    }

    public void GridShuffle()
    {
        gridController.RepositionCells();
        canMove = true;
    }
}
