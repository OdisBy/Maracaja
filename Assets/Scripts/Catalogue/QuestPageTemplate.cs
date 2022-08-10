using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Catalogue/Quest")]
public class QuestPageTemplate : ScriptableObject
{
    public int id;
    public string questName;
    [TextArea(3, 30)]
    public string infos;


}
