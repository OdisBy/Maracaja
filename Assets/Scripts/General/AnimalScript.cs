using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    [SerializeField]
    internal string nome;
    public int id;
    internal int missaoAtual;
    public bool jaDialogou;
    internal bool inQuest;
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
    public bool comItem;

    [Space]
    public AnimalPageTemplate pageTemplate;
    public QuestPageTemplate questPageTemplate;
    public QuestPageManager questPageManager;
    public Animator playerAnimator;
    public AnimalPageManager animalPageManager;
    public soundEmitter soundEmitterRef;

    public GameObject itemQuestAnimal;
    public GameObject particulas;
    public AudioController AudioController;


    void Start()
    {
        jaDialogou = false;
        missaoAtual = PlayerPrefs.GetInt("fase", 0);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            podeFotografar = true;
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
        soundEmitterRef.pararSom();
        if(comItem){
            StartCoroutine(particulasItem());
        }else{
            dialogueManager.StartDialogue(dialogue, this);
        }
    }

    

    public void questSecundaria(){
        inQuest = true;
        itemQuestAnimal.SetActive(true);
    }

    public void concluiuQuest(){
        missaoAtual = PlayerPrefs.GetInt("fase", 0);
        pageTemplate.questFineshed = true;
        questPageManager.updateInfos();
        animalPageManager.updateInfos();
    }

    IEnumerator particulasItem(){
        particulas.SetActive(true);
        AudioController.successSoundFunc();
        particulas.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSecondsRealtime(3f);
        particulas.GetComponent<ParticleSystem>().Stop();
        particulas.SetActive(false);
        dialogueManager.StartDialogue(dialogue, this);
    }
}
