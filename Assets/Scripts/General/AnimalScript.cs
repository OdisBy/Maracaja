using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    [SerializeField]
    internal string nome;
    internal bool podeDialogar;
    internal bool jaFalou;
    internal bool inQuest;
    internal bool recusou;
    internal bool redimiu;
    internal bool jaFotografou;
    [SerializeField]
    internal Collider2D trigger;
    [SerializeField]
    internal PlayerScript player;

    public Dialogue dialogue;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && podeDialogar)
        {
            dialogar();
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        trigger = this.trigger;
        this.podeDialogar = true;
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        trigger = this.trigger;
        this.podeDialogar = false;
    }
    private void dialogar()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
    }

    public void Quest(bool aceita)
    {

    }
}
