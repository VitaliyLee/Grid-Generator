using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardPooler
{
    public static List<GameObject> CardList;
    public static List<CardInfo> CardInfoList;
    private static int index = 0;

    public static void Warm(GameObject cardPrefab, Transform transform, int count)
    {
        CardList = new List<GameObject>();
        CardInfoList = new List<CardInfo>();

        for (int i = 0; i < count; i++)
        {
            GameObject card = Object.Instantiate(cardPrefab, transform, false);
            CardInfo cardInfo = new CardInfo(card);
            card.gameObject.SetActive(false);
            CardList.Add(card);
            CardInfoList.Add(cardInfo);
        }
    }

    public static GameObject ActivCard(int cardCount)
    {
        CardList[index].gameObject.SetActive(true);

        index++;
        return CardList[index - 1].gameObject;
    }

    public static void DisactivCards()
    {
        index = 0;

        for (int i = 0; i < CardList.Count; i++)
        {
            CardList[i].gameObject.SetActive(false);
        }
    }
}
