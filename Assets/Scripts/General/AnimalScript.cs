using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    [SerializeField]
    internal string nome;
    internal bool podeDialogar;
    internal bool jaDialogou;
    internal bool inQuest;
    internal bool concluiuQuest;
    internal bool recusou;
    internal bool redimiu;
    internal bool jaFotografou;
    public bool podeFotografar;
    [SerializeField]
    internal Collider2D trigger;
    [SerializeField]
    internal PlayerScript player;

    public Dialogue dialogue;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && podeDialogar)
        {
            dialogar();
        }
    }

    private void OnTriggerEnter2D(Collider2D _trigger)
    {
        podeDialogar = true;
    }

    private void OnTriggerStay2D(Collider2D _trigger)
    {
        if(recusou || concluiuQuest)
        {
            podeFotografar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D _trigger)
    {
        podeDialogar = false;
        podeFotografar = false;
    }
    private void dialogar()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
    }

    public void Quest(bool aceita)
    {
        
    }
}
