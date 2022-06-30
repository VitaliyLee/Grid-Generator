using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Filling
{
    public void FillingLetter(List<string> LetterList, GameObject Card)
    {
        int randomIndex = Random.Range(0, LetterList.Count);
        Card.GetComponentInChildren<TextMeshProUGUI>().text = LetterList[randomIndex];
    }
}
