using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureManager : MonoBehaviour
{
    public PlayerScript player;
    public List<AnimalScript> animais = new List<AnimalScript>();
    public List<PlantsScript> plantas = new List<PlantsScript>();
    public void picture()
    {
        foreach(AnimalScript animal in animais)
        {
            if(animal.podeFotografar){
                player.returnPictureAnimal(animal);
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
