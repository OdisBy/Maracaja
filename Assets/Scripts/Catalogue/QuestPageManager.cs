using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestPageManager : MonoBehaviour
{
    public TextMeshProUGUI nomeQuestPagina;
    public TextMeshProUGUI infosPagina;
    public int actualId;
    public QuestPageTemplate[] allPages;

    void Start()
    {
        actualId = PlayerPrefs.GetInt("questPageId", 0);
        Debug.Log(actualId);
        updateInfos();
    }

    public void updateInfos()
    {
        nomeQuestPagina.text = allPages[actualId].questName;
        infosPagina.text = allPages[actualId].infos;
    }
}
