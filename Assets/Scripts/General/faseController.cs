using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faseController : MonoBehaviour
{
    public GameObject[] animaisGO;
    public AnimalScript[] animais;
    public int faseAtual;
    public int dayNight;

    public cutSceneDiaNoite cutSceneDiaNoite;
    
    void Start()
    {
        faseAtual = 0;
        inicioJogo();
    }

    public void inicioJogo(){
        PlayerPrefs.SetInt("fase", 0);
        animaisGO[0].SetActive(true);
        animaisGO[1].SetActive(false);
        animaisGO[2].SetActive(false);
        animaisGO[3].SetActive(false);
    }

    public void atualizarFase(){
        Debug.Log("Atualizando fase");
        faseAtual = PlayerPrefs.GetInt("fase", 0);
        Debug.Log("desabilitando id " + faseAtual);

        animaisGO[faseAtual].SetActive(false);

        PlayerPrefs.SetInt("fase", faseAtual + 1);

        faseAtual = PlayerPrefs.GetInt("fase", 0);

        animaisGO[faseAtual].SetActive(true);
        Debug.Log("habilitando id " + faseAtual);

        if(faseAtual % 2 == 0){
            cutSceneDiaNoite.diaParaNoite();
        }else{
            cutSceneDiaNoite.noiteParaDia();
        }
    }

    public void finalizarJogo(){
        cutSceneDiaNoite.finalJogo();
    }
}
