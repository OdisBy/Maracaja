using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemQuestScript : MonoBehaviour
{
    public GameObject tronco;
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
    }
}
