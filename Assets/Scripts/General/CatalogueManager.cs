using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatalogueManager : MonoBehaviour
{
    //infos gerais
    public GameObject UI;
    public GameObject catalogo;

    //Variaveis p esse script
    public GameObject[] bookmarks;
    public bool isOpen;    
    public int actualBookmark;
    public int actualPage;
    private Sprite sprite;
    
    [Space]
    //INFO Pag missoes
    [Header("Pagina das missoes")]
    public Image Quest_Foto;

    [Space]
    //INFOS PAG Animais
    [Header("Area dos animais")]
    public Image Animal_Foto;
    public TextMeshProUGUI Animais_Info_1;
    public TextMeshProUGUI Animais_Info_2;

    [Space]
    [Header("Area das plantas")]
    public Image Plantas_Foto_1;
    public Image Plantas_screenshot;
    public GameObject Plantas_Infos;



    //INFOS ADD
    [TextArea(3, 30)]
    public string[] infos; 


    void Start()
    {
        actualBookmark = 0;
        actualPage = 0;
    }

    //ABRIR E FECHAR CATALOGO
    public void openCatalogue()
    {
        isOpen = true;
        Time.timeScale = 0f;
        UI.SetActive(false);
        catalogo.SetActive(true);
        bookmarks[actualBookmark].SetActive(true);
    }
    public void closeCatalogue()
    {
        isOpen = false;
        Time.timeScale = 1f;
        UI.SetActive(true);
        catalogo.SetActive(false);
        bookmarks[actualBookmark].SetActive(false);
    }



    //Mudar de sessoes

    public void blueBookmark()
    {
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 0;
        bookmarks[actualBookmark].SetActive(true);
    }
    public void greenBookmark()
    {
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 1;
        bookmarks[actualBookmark].SetActive(true);
        AnimaisCatalogo();
    }

    public void brownBookmark()
    {
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 2;
        bookmarks[actualBookmark].SetActive(true);
    }

    public void AnimaisCatalogo(){}
    //MUDAR DE PAGINAS NAS SESSÕES
    //SESSAO ANIMAL
    // public void AnimaisCatalogo()
    // {
    //     switch(actualPage)
    //     {
    //         case 0:
    //             sprite = Resources.Load<Sprite>("Animais/tamandua");
    //             Animais_Info_1.text = infos[0];
    //             Animais_Info_2.text = infos[1];
    //         break;
    //         case 1:
    //         break;
    //     }
    //     Animal_Foto.sprite = sprite;
    // }


}
