using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somAnimais : MonoBehaviour
{

    public AudioController audioController;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            audioController.ararajubaSom();
        }
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
    }
}
