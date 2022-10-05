using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    [SerializeField]
    internal string nome;
    internal bool podeDialogar;
    internal bool jaDialogou;
    internal int inQuestPage;
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
    public DialogueManager dialogueManager;

    [Space]
    public AnimalPageTemplate pageTemplate;
    public QuestPageTemplate questPageTemplate;
    public QuestPageManager questPageManager;
    public Animator playerAnimator;
    public AnimalPageManager animalPageManager;

    void Start()
    {
        inQuestPage = PlayerPrefs.GetInt("questPageId", 0);
        if(pageTemplate.id == inQuestPage)
        {
            pageTemplate.inQuestPage = true;
        }
    }
    void Update()
    {
        foreach (AnimalPageTemplate animal in animalPageManager.allAnimals)
        {
            if(animal.questFineshed)
            {

                player.irSpawnPoint();



                concluiuQuest = true;
                pageTemplate.inQuestPage = false;
                PlayerPrefs.SetInt("questPageId", +1);
                inQuestPage = PlayerPrefs.GetInt("questPageId", 0);
                pageTemplate.inQuestPage = true;
                questPageManager.updateInfos();

            }else{
                concluiuQuest = false;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            podeFotografar = true;
            if(animalPageManager.allAnimals[0].podeFinalizar){
                dialogar();
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            podeFotografar = false;

        }
    }
    public void dialogar()
    {
        player.isTalking = true;
        dialogueManager.StartDialogue(dialogue, this);
    }

    public void Quest(bool aceita)
    {
        
    }
}
