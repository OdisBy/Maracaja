using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public PlayerScript player;
    public List<AnimalScript> animais = new List<AnimalScript>();
    public List<PlantsScript> plantas = new List<PlantsScript>();
    public int nextQuestID;
    public void picture()
    {
        foreach(AnimalScript animal in animais)
        {
            if(animal.pageTemplate.inQuestPage && animal.podeFotografar)
            {
                animal.pageTemplate.isUnlocked = true;
                animal.pageTemplate.inQuest = true;
                // nextQuestID = PlayerPrefs.GetInt("questPageId", 1) + 1;
                // PlayerPrefs.SetInt("questPageId", nextQuestID);
                animal.dialogar();
                animal.questPageTemplate.isUnlocked = true;
                animal.questPageManager.updateInfos();
                Debug.Log(animal + " foi desbloqueado");
                return;
            }
        }

        foreach (PlantsScript planta in plantas)
        {
            if(planta.podeFotografar)
            {
                player.returnPicturePlanta(planta);
                return;
            }
        }
        player.returnPictureVazia();
    }
}
