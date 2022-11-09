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

    void Awake()
    {
        Debug.Log("Startando animalpagemanager");
        PlayerPrefs.SetInt("questPageId", 0);
        actualId = PlayerPrefs.GetInt("questPageId", 0);
        updateInfos();
        resetInfos();
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

    public void resetInfos(){
        foreach (QuestPageTemplate template in allPages)
        {
            template.isUnlocked = false;
        }
    }

    public void animalConversou(int id, bool item){
        allPages[id].isUnlocked = true;
    }

    public void finalizouQuest(int id){
        //TODO ADD FOTO DO ITEM
    }

    public void finalizouAnimal(int id){
        allPages[id].questPageAtual = false;
    }
}
