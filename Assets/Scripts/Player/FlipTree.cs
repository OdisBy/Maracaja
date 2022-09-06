using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTree : MonoBehaviour
{
    public BoxCollider2D colliderChecker;
    public PlayerScript player;
    public bool onTree, girarEsquerda, girarDireita;

    public void GirarParaEsquerda()
    {
        girarEsquerda = true;
        transform.position += new Vector3(-0.5f, 0, 0);
    }

    void Update()
    {
        while(onTree)
        {
            if(girarEsquerda)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }   
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col = colliderChecker;
        if(col.gameObject.layer == LayerMask.NameToLayer("Escalaveis"))
        {
            Debug.Log("Tree");
            onTree = true;
        } else {
            onTree = false;
            Debug.Log("Air");
            //player.transform.position = colliderChecker.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        col = colliderChecker;
        if(col.gameObject.layer == LayerMask.NameToLayer("Escalaveis"))
        {
            onTree = false;
            Debug.Log("Saiu da árvore");
        }
    }
}
