using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestPageManager : MonoBehaviour
{
    public TextMeshProUGUI nomeQuestPagina;
    public TextMeshProUGUI infosPagina;
    public int actualId;
    public QuestPageTemplate[] allPages;
    [SerializeField]
    public Image fotoOculta;

    void Start()
    {
        PlayerPrefs.SetInt("questPageId", 0);
        actualId = PlayerPrefs.GetInt("questPageId", 0);
        updateInfos();

        foreach(QuestPageTemplate questTemplate in allPages)
        {
            questTemplate.isUnlocked = false;
        }
    }

    public void updateInfos()
    {
        actualId = PlayerPrefs.GetInt("questPageId", 0);
        if(allPages[actualId].isUnlocked)
        {
            fotoOculta.sprite = allPages[actualId].fotoDesbloqueada;
        }else{
            fotoOculta.sprite = allPages[actualId].fotoOculta;
        }
        nomeQuestPagina.text = allPages[actualId].questName;
        infosPagina.text = allPages[actualId].infos;
    }


}
