using UnityEngine;
using UnityEngine.UI;

public class GridController
{
    private GridSettings gridSettings;
    private LetterDataSet dataSet;
    private Movement movement;
    private Filling filling;

    private RectTransform gridRectTransform;
    private GridLayoutGroup gridLayout;
    private int gridWidth;
    private int gridHeight;

    public GridController(GridSettings GridSettings, GridLayoutGroup GridLayout, LetterDataSet LetterDataSet)
    {
        gridSettings = GridSettings;
        gridRectTransform = gridSettings.GridRectTransform;
        gridLayout = GridLayout;
        dataSet = LetterDataSet;
        movement = new Movement();
        filling = new Filling();
    }

    public void GridCreator(int GridWidth, int GridHeight)
    {
        gridWidth = GridWidth;
        gridHeight = GridHeight;
        int currentCellsCount = gridWidth * gridHeight;

        CardPooler.DisactivCards();
        for (int i = 0; i < currentCellsCount; i++)
        {
            CardPooler.ActivCard(currentCellsCount);
        }

        GridResize();
        GridFilling();
    }

    public void RepositionCells()
    {
        movement.SetTarget(gridWidth, gridHeight, CardPooler.CardInfoList);
    }

    public void MoveCards()
    {
        for (int i = 0; i < CardPooler.CardInfoList.Count; i++)
        {
            movement.Move(CardPooler.CardInfoList[i], gridSettings.ShuffleSpeed);
        }
    }

    private void GridFilling()
    {
        for (int i = 0; i < CardPooler.CardList.Count; i++)
        {
            filling.FillingLetter(dataSet.LetterList, CardPooler.CardList[i]);
        }
    }

    private void GridResize()
    {
        gridLayout.constraintCount = gridWidth;
        float width = gridRectTransform.rect.width;

        Vector2 newSize = new Vector2(width / gridWidth, width / gridWidth);
        gridLayout.cellSize = newSize;
    }
}
