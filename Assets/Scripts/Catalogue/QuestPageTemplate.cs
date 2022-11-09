using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Catalogue/Quest")]
public class QuestPageTemplate : ScriptableObject
{
    public int id;
    public bool questPageAtual;
    public bool isUnlocked;
    public Sprite fotoDesbloqueada;
    public string questName;
    [TextArea(3, 30)]
    public string infos;

    public Sprite fotoOculta;
}
