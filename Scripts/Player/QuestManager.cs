using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public PlayerScript player;
    public bool finalizarQuest;

    public void concluirQuest()
    {
        if(finalizarQuest)
        {
            if(!player.inQuest)
                return;
            else
            {
                player.inQuest = false;
                Debug.Log("Finalizou a quest");
                finalizarQuest = false;
            }
        }
    }
}
