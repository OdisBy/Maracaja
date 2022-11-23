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
            if(animal.podeFotografar)
            {
                animal.pageTemplate.isUnlocked = true;
                animal.dialogar();
                player.canWalk = false;
                animal.questPageTemplate.isUnlocked = true;
                animal.questPageManager.updateInfos();
                animal.animalPageManager.updateInfos();
                Debug.Log(animal + " foi desbloqueado");
                return;
            }else{
                player.canMove = true;
            }
        }
    }
}
