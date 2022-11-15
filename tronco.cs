using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    public AnimalPageManager animalPageManager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(animalPageManager.allAnimals[0].inQuest)
            {
                Debug.Log("Encostou tronco");
                animalPageManager.allAnimals[0].podeFinalizar = true;
                animalPageManager.allAnimals[0].inQuest = false;
                Destroy(this.gameObject);
            }
        }
    }
}
