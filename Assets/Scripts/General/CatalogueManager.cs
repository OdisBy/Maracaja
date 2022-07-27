using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogueManager : MonoBehaviour
{
    public GameObject UI;
    public GameObject catalogo;
    public GameObject[] pages;
    public bool isOpen;
    
    public int actualPage;

    void Start()
    {
        actualPage = 0;
    }

    public void openCatalogue()
    {
        isOpen = true;
        Time.timeScale = 0f;
        UI.SetActive(false);
        catalogo.SetActive(true);
        pages[actualPage].SetActive(true);
    }

    public void closeCatalogue()
    {
        isOpen = false;
        Time.timeScale = 1f;
        UI.SetActive(true);
        catalogo.SetActive(false);
        pages[actualPage].SetActive(false);
    }

    public void nextPage()
    {

    }

    public void previousPage()
    {

    }
}
