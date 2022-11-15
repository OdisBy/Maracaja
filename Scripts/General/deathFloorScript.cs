using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathFloorScript : MonoBehaviour
{
    public PlayerScript player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            Debug.Log("Player caiu");
            player.irSpawnPoint();

        }
    }
}
