using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemQuestScript : MonoBehaviour
{
    public AnimalScript animal;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ASAS");
        if(col.gameObject.CompareTag("Player"))
        {
            animal.concluiuQuest();
            Destroy(gameObject);
        }
    }
}
