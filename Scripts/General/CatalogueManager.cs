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
    [SerializeField]
    private QuestPageManager questManager;

    [Space]
    //INFOS PAG Animais
    [Header("Area dos animais")]
    [SerializeField]
    private AnimalPageManager animalManager;
    [SerializeField]
    private GameObject previousPageGO;
    [SerializeField]
    private GameObject nextPageGO;

    [Space]
    [Header("Area do album")]
    [SerializeField]
    private Album albumManager;

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
        questManager.updateInfos();
        animalManager.updateInfos();
        albumManager.updateInfos();
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

    //Desabilitar e habilitar next and previous button
    void checkButtonAnimal()
    {
        //Animais
        //previous
        if(PlayerPrefs.GetInt("animalPageId", 0) == 0)
        {
            previousPageGO.SetActive(false);
        }else{
            previousPageGO.SetActive(true);
        }
        //next
        if(PlayerPrefs.GetInt("animalPageId", 0) + 1 == animalManager.allAnimals.Length)
        {
            nextPageGO.SetActive(false);
        }else{
            nextPageGO.SetActive(true);
        }


    }



    //Mudar de sessoes

    public void blueBookmark()
    {
        questManager.updateInfos();
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 0;
        checkButtonAnimal();
        bookmarks[actualBookmark].SetActive(true);
    }
    public void greenBookmark()
    {
        questManager.updateInfos();
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 1;
        checkButtonAnimal();
        bookmarks[actualBookmark].SetActive(true);
    }

    public void brownBookmark()
    {
        albumManager.updateInfos();
        bookmarks[actualBookmark].SetActive(false);
        actualBookmark = 2;
        bookmarks[actualBookmark].SetActive(true);
    }

    public void nextPage()
    {
        Debug.Log("Next Page");
        actualPage = PlayerPrefs.GetInt("animalPageId", 0);
        actualPage += 1;
        PlayerPrefs.SetInt("animalPageId", actualPage);
        checkButtonAnimal();
        animalManager.updateInfos();
    }
    public void previousPage()
    {
        Debug.Log("Previous Page");
        actualPage = PlayerPrefs.GetInt("animalPageId", 0);
        actualPage -= 1;
        PlayerPrefs.SetInt("animalPageId", actualPage);
        checkButtonAnimal();
        animalManager.updateInfos();
    }
}
