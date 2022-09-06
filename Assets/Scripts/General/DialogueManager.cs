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





    public Animator animator;
    public AnimalScript animalSelected;
    public AnimalPageManager animalPageManager;
    private string inQuestSentenca;
    private string declineSentenca;
    private string redencaoSentenca;
    private string concluiuSentenca;

    private Queue<string> sentencas;
    void Start()
    {
        sentencas = new Queue<string>();
        redencaoButton.SetActive(false);
        declineButton.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue, AnimalScript animal)
    {
        animalSelected = animal;
        dialogueBox.SetActive(true);
        animator.SetBool("IsOpen", true);
        closeButton.SetActive(true);
        nameText.text = dialogue.nome;
        sentencas.Clear();
        

        if(animal.jaDialogou)
        {
            if(animal.recusou)
            {
                redencaoButton.SetActive(true);
                declineButton.SetActive(true);
            }
            continueButton.SetActive(false);
            if(animal.inQuest)
            {
                //BOTOES
                // closeButton.SetActive(true);
                declineButton.SetActive(true);

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
        if(animalSelected.inQuest)
        {
            dialogueText.text = inQuestSentenca;
            continueButton.SetActive(true);
            return;
        }
        if(animalSelected.concluiuQuest)
        {
            dialogueText.text = concluiuSentenca;

            continueButton.SetActive(false);
            acceptButton.SetActive(false);  
            declineButton.SetActive(false);
            redencaoButton.SetActive(false);
        }
        if(animalSelected.redimiu)
        {
            dialogueText.text = redencaoSentenca;
            continueButton.SetActive(true);
            declineButton.SetActive(true);
            return;
        }
        if(sentencas.Count == 0)
        {
            EndDialogue();
        }

        if(sentencas.Count != 1)
        {
            continueButton.SetActive(true);
        }

        string sentenca = sentencas.Dequeue();
        dialogueText.text = sentenca;
    }

    public void AcceptQuest()
    {
        sentencas.Enqueue(inQuestSentenca);
        DisplayNextSentence();
        animalSelected.inQuest = true;
        animalSelected.recusou = false;
        

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


        continueButton.SetActive(false);
        acceptButton.SetActive(false);  
        declineButton.SetActive(true);
        redencaoButton.SetActive(false);
    }

    public void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        Invoke("disableDialogueBox", 1);
    }

    public void disableDialogueBox()
    {
        dialogueBox.SetActive(false);
    }

    public void AAAAA()
    {
        Debug.Log("A");
    }
}
