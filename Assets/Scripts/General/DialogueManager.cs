using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    // public Text continueText;
    // public Text declineText;
    // public Text redencaoText;
    public GameObject declineButton;
    public GameObject continueButton;
    public GameObject redencaoButton;
    public GameObject acceptButton;
    public GameObject closeButton;
    public GameObject fecharButton;
    public string currentState;





    public Animator animator;
    public AnimalScript animalSelected;
    public AnimalPageManager animalPageManager;
    private string inQuestSentenca;
    private string declineSentenca;
    private string redencaoSentenca;
    // private string finalSentenca = "Muito obrigado por me ajudar meu amiguinho. Pode retornar para casa agora!";
    private string concluiuSentenca;

    public bool terminou;

    private Queue<string> sentencas;
    void Start()
    {
        sentencas = new Queue<string>();
        redencaoButton.SetActive(false);
        declineButton.SetActive(false);
        ChangeState("DialogueBox_Stop");
    }

    public void StartDialogue(Dialogue dialogue, AnimalScript animal)
    {
        animalSelected = animal;
        animalSelected.player.canMove = false;
        // dialogueBox.SetActive(true);
        // animator.SetBool("IsOpen", true);
        ChangeState("DialogueBox_Open");
        // closeButton.SetActive(true);
        nameText.text = dialogue.nome;
        sentencas.Clear();
        fecharButton.SetActive(false);
        animal.player.canMove = false;
        

        if(animal.jaDialogou)
        {
            if(animal.comItem){
                sentencas.Clear();
                sentencas.Enqueue(concluiuSentenca);
                DisplayNextSentence();

                fecharButton.SetActive(true);
                redencaoButton.SetActive(false);
                declineButton.SetActive(false);
                acceptButton.SetActive(false);
            }
            else if(animal.recusou)
            {
                redencaoButton.SetActive(true);
                declineButton.SetActive(true);
                continueButton.SetActive(false);
            }
            else if(animal.inQuest)
            {
                //BOTOES
                // closeButton.SetActive(true);
                declineButton.SetActive(true);
                fecharButton.SetActive(true);

                //DIALOGO
                dialogueText.text = inQuestSentenca;
            }
            else if(!animal.inQuest)
            {
                //BOTOES
                // closeButton.SetActive(true);
                acceptButton.SetActive(true);
            }
        }
        else
        {
            animal.jaDialogou = true;
            animator.SetBool("IsOpen", true);
            
            //BOTOES
            // closeButton.SetActive(true);
            Debug.Log("ASsa");


            foreach(string sentenca in dialogue.sentencas)
            {
                sentencas.Enqueue(sentenca);
            }
            inQuestSentenca = dialogue.inQuestSentenca;
            declineSentenca = dialogue.recusouSentenca;
            redencaoSentenca = dialogue.redencaoSentenca;
            concluiuSentenca = dialogue.concluiuSentenca;
            DisplayNextSentence();
        }
    }
    
    public void DisplayNextSentence()
    {
        continueButton.SetActive(false);
        acceptButton.SetActive(false);  
        declineButton.SetActive(false);
        redencaoButton.SetActive(false);
        if(animalSelected.comItem){
            sentencas.Clear();
            sentencas.Enqueue(concluiuSentenca);
            fecharButton.SetActive(true);
            animalSelected.concluiuQuest();
        }else{

        
        if(sentencas.Count == 1)
        {
            continueButton.SetActive(false);
            acceptButton.SetActive(true);  
            declineButton.SetActive(true);
        }
        if(animalSelected.recusou)
        {
            dialogueText.text = declineSentenca;
            redencaoButton.SetActive(true);
            return;
        }
        if(animalSelected.inQuest && !animalSelected.pageTemplate.questFineshed)
        {
            dialogueText.text = inQuestSentenca;
            continueButton.SetActive(true);
            return;
        }
        // if(animalSelected.concluiuQuest)
        // {
        //     dialogueText.text = concluiuSentenca;

        //     continueButton.SetActive(false);
        //     acceptButton.SetActive(false);  
        //     declineButton.SetActive(false);
        //     redencaoButton.SetActive(false);
        // }
        if(animalSelected.redimiu)
        {
            dialogueText.text = redencaoSentenca;
            continueButton.SetActive(true);
            declineButton.SetActive(true);
            return;
        }

        if(sentencas.Count != 1)
        {
            continueButton.SetActive(true);
        }
        }

        string sentenca = sentencas.Dequeue();
        dialogueText.text = sentenca;
    }

    public void AcceptQuest()
    {
        sentencas.Enqueue(inQuestSentenca);
        DisplayNextSentence();
        animalSelected.recusou = false;

        fecharButton.SetActive(true);
        animalSelected.questSecundaria();
        

        continueButton.SetActive(false);
        acceptButton.SetActive(false);  
        declineButton.SetActive(false);
        redencaoButton.SetActive(false);
    }

    public void DeclineQuest()
    {
        animalSelected.inQuest = false;
        animalSelected.recusou = true;
        sentencas.Enqueue(declineSentenca);
        DisplayNextSentence();
        
        fecharButton.SetActive(true);

        continueButton.SetActive(false);
        acceptButton.SetActive(false);  
        declineButton.SetActive(false);
        redencaoButton.SetActive(false);
    }

    public void Redencao()
    {
        animalSelected.inQuest = true;
        animalSelected.recusou = false;
        sentencas.Enqueue(redencaoSentenca);
        DisplayNextSentence();

        fecharButton.SetActive(true);

        continueButton.SetActive(false);
        acceptButton.SetActive(false);  
        declineButton.SetActive(true);
        redencaoButton.SetActive(false);
    }
    public void EndDialogue()
    {
        ChangeState("DialogueBox_Close");
        animalSelected.player.isTalking = false;
        animalSelected.player.canMove = true;
        animalSelected.player.canWalk = true;
    }




    internal void ChangeState(string newState)
    {
        if (newState != currentState)
        {
            animator.Play(newState);
            currentState = newState;
        }
    }
}
