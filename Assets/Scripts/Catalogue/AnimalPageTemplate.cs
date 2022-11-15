using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "ScriptableObjects/Catalogue/Animals")]
public class AnimalPageTemplate : ScriptableObject
{
    public int id;
    public bool faseDia;
    public bool isUnlocked = false;
    public bool podeFinalizar;
    public bool inQuestPage;
    public bool inQuest;
    public bool questFineshed;
    public Sprite fotoItem;
    public Sprite fotoBloqueada;
    public Sprite FotoReal;
    public Sprite foto;
    [TextArea(3, 30)]
    public string infos_1;
    [TextArea(3, 30)]
    public string infos_2;
}
