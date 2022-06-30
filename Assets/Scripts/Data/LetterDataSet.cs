using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "NewLetterDataSet", menuName = "new LetterDataSet")]
public class LetterDataSet : ScriptableObject
{
    [SerializeField] private List<string> _letterList = new List<string>();

    public List<string> LetterList => _letterList;
}
