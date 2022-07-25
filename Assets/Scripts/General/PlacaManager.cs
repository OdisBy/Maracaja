using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlacaManager : MonoBehaviour
{
    public GameObject infoBox;
    public TextMeshProUGUI informacoes;
    private int index;
    public float velocidadeEscrita;
    public GameObject nextIcon;
    private Queue<string> sentencas;
    public bool isOpen;
    
    void Start()
    {
        sentencas = new Queue<string>();
    }
    void Update()
    {
        if(isOpen == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                NextSentence();
            }
        }
    }

    public void StartDisplay(string[] frases)
    {
        Debug.Log("Start Display");
        infoBox.SetActive(true);
        isOpen = true;
        nextIcon.SetActive(true);
        sentencas.Clear();

        sentencas.Enqueue("A");
        foreach(string frase in frases)
        {
                sentencas.Enqueue(frase);
        }
        NextSentence();
    }

    public void NextSentence()
    {
        Debug.Log("Next sentneca");
        if(sentencas.Count == 0)
        {
            EndDialogue();
        }else{
            string sentenca = sentencas.Dequeue();
            informacoes.text = sentenca;
        }
        
    }
    public void EndDialogue(){
        Debug.Log("End dialogue");
        isOpen = false;
        nextIcon.SetActive(false);
        infoBox.SetActive(false);
    }

}
