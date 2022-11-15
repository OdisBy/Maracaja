using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemQuestScript : MonoBehaviour
{
    public GameObject tronco;
    public GameObject pena;
    public AnimalPageManager animalPageManager;

    void Update()
    {
        if(tronco != null)
        {
            if(animalPageManager.allAnimals[0].inQuest)
            {
                tronco.SetActive(true);
            }
        }
        if(pena != null)
        {
            if(animalPageManager.allAnimals[1].inQuest)
            {
                pena.SetActive(true);
            }
        }
    }
}
