using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    public AnimalPageManager animalPageManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(animalPageManager.allAnimals[0].inQuest)
            {
                Debug.Log("Encostou tronco");
                animalPageManager.allAnimals[0].questFineshed = true;
                animalPageManager.allAnimals[0].inQuest = false;
                Destroy(this.gameObject);
            }
        }
    }
}
