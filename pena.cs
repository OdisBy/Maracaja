using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pena : MonoBehaviour
{
    public AnimalPageManager animalPageManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(animalPageManager.allAnimals[1].inQuest)
            {
                Debug.Log("Encostou pena");
                animalPageManager.allAnimals[1].podeFinalizar = true;
                animalPageManager.allAnimals[1].inQuest = false;
                Destroy(this.gameObject);
            }
        }
    }
}
