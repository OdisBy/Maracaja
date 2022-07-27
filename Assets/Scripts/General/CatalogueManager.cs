using System.Collections;
using System.Collections.Generic;
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
    private Sprite sprite_01;
    private Sprite sprite_02;
    private Sprite sprite_03;
    
    [Space]
    //INFO Pag missoes
    [Header("Pagina das missoes")]

    [Space]
    //INFOS PAG Animais
    [Header("Area dos animais")]
    public Image Animais_Foto_1;
    public Image Animais_Foto_2;
    public Image Animais_Foto_3;
    public GameObject Animais_Infos;
    [Space]
    [Header("Area das plantas")]
    public Image Plantas_Foto_1;
    public Image Plantas_screenshot;
    public GameObject Plantas_Infos;


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

    public void firstBookmark()
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


    //MUDAR DE PAGINAS NAS SESSÕES
    //SESSAO ANIMAL
    public void AnimaisCatalogo()
    {
        sprite_01 = Resources.Load<Sprite>("Animais/Macaco/Macaco_01_Teste");
        sprite_02 = Resources.Load<Sprite>("Animais/Macaco/Macaco_02_Teste");
        sprite_03 = Resources.Load<Sprite>("Animais/Macaco/Macaco_03_Teste");
        Animais_Foto_1.sprite = sprite_01;
        Animais_Foto_2.sprite = sprite_02;
        Animais_Foto_3.sprite = sprite_03;
    }


}
