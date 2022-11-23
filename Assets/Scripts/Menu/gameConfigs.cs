using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameConfigs : MonoBehaviour
{
    public Slider somGeralSlider;
    public Slider somAnimaisSlider;
    public Slider somBGSlider;
    public Slider somMusicaSlider;
    public Slider somPersonagemSlider;

    public float somGeral;
    public float somAnimais;
    public float somBG;
    public float somMusica;
    public float somPersonagem;
    public GameObject GOConfiguracoes;
    public void abrirConfiguracoes(){
        GOConfiguracoes.SetActive(true);
        setVolumeSlider();
    }

    public void fecharConfiguracoes(){
        GOConfiguracoes.SetActive(false);
    }

    public void quitGame(){
        clickSound();
        Application.Quit();
    }

    public void clickSound(){
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("somGeral", 100);
        GetComponent<AudioSource>().Play();
    }

    public void salvarConfiguracoesVolume(){
        PlayerPrefs.SetFloat("somGeral", somGeralSlider.value);
        PlayerPrefs.SetFloat("somAnimais", somAnimaisSlider.value);
        PlayerPrefs.SetFloat("somBG", somBGSlider.value);
        PlayerPrefs.SetFloat("somMusica", somMusicaSlider.value);
        PlayerPrefs.SetFloat("somPersonagem", somPersonagemSlider.value);

        fecharConfiguracoes();
    }

    public void getActualVolume(){
        somGeral = PlayerPrefs.GetFloat("somGeral", 100);
        somAnimais = PlayerPrefs.GetFloat("somAnimais", 100);
        somBG = PlayerPrefs.GetFloat("somBG", 100);
        somMusica = PlayerPrefs.GetFloat("somMusica", 100);
        somPersonagem = PlayerPrefs.GetFloat("somPersonagem", 100);
    }

    public void setVolumeSlider(){
        getActualVolume();

        somGeralSlider.value = somGeral;
        somAnimaisSlider.value = somAnimais;
        somBGSlider.value = somBG;
        somMusicaSlider.value = somMusica;
        somPersonagemSlider.value = somPersonagem;
    }

    public void sairJogo(){
        Application.Quit();
    }
}
