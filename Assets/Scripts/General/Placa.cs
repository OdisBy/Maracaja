using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : MonoBehaviour
{
    // [SerializeField]
    // internal Collider2D trigger;
    [SerializeField]
    internal PlayerScript player;
    [SerializeField]
    internal PlacaManager manager;

    public PlacaInfo dialogue;
    public GameObject exclamacaoPop;
    public bool canBeOpen;
    public bool alreadyOpen;
    [TextArea(3, 10)]
    public string[] sentencas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBeOpen && !manager.isOpen)
        {
           alreadyOpen = true;
           exclamacaoPop.SetActive(false);
           manager.StartDisplay(sentencas);
        }

        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(!alreadyOpen)
            {
                // exclamacaoPop.GetComponent<RectTransform>().anchoredPosition =  new Vector2(6, 2);
                exclamacaoPop.SetActive(true);
            }
            canBeOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            exclamacaoPop.SetActive(false);
        }
        canBeOpen = false;
    }
}
