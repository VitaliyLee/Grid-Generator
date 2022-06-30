using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    public void Move(CardInfo CardInfo, float Speed)
    {
        CardInfo.card.transform.localPosition =
            Vector3.Lerp(CardInfo.card.transform.localPosition,
            CardInfo.targetPosition, Speed * Time.deltaTime);
    }

    public void SetTarget(int GridWidth, int GridHeight, List<CardInfo> CardInfoList)
    {
        int index = 0;
        int currentCellsCount = GridWidth * GridHeight;
        List<int> list = new List<int>();

        while (list.Count < currentCellsCount)
        {
            int rnd = Random.Range(0, currentCellsCount);
            if (!list.Contains(rnd))
            {
                list.Add(rnd);
                CardInfoList[index].targetPosition = CardInfoList[rnd].card.transform.localPosition;
                index++;
            }
        }
    }
}
