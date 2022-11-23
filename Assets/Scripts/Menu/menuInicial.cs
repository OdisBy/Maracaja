using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuInicial : MonoBehaviour
{

    public FMOD.Studio.EventInstance instanceFMODMusic;
    public FMOD.Studio.EventInstance instanceFMODFeedback;

    public AudioClip click;
    public GameObject menuPag;
    public GameObject confiracoesPag;


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


    

    void Start(){
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = click;
        menuPag.SetActive(true);
        confiracoesPag.SetActive(false);

        PlayerPrefs.SetFloat("somGeral", 100);
        PlayerPrefs.SetFloat("somAnimais", 100);
        PlayerPrefs.SetFloat("somBG", 100);
        PlayerPrefs.SetFloat("somMusica", 100);
        PlayerPrefs.SetFloat("somPersonagem", 100);


        instanceFMODMusic = FMODUnity.RuntimeManager.CreateInstance("event:/MenuIntro");

        instanceFMODFeedback = FMODUnity.RuntimeManager.CreateInstance("event:/miadoFeedback");
        
        instanceFMODMusic.start();
    }

    void Update(){
        instanceFMODMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        instanceFMODFeedback.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

    }

    public void goToGame(){
        clickSound();
        SceneManager.LoadScene("CutScene-Inicial");
    }
    public void openConfiguration(){
        //TODO
        clickSound();
        instanceFMODMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        menuPag.SetActive(false);
        confiracoesPag.SetActive(true);
        setVolumeSlider();
    }

    public void openMenu(){
        salvarConfiguracoesVolume();
        clickSound();

        instanceFMODMusic.start();

        menuPag.SetActive(true);
        confiracoesPag.SetActive(false);
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


    public void somFeedbackMiado(Slider a){
        instanceFMODFeedback.setVolume(a.value);
        instanceFMODFeedback.start();
    }

    public void sairJogo(){
        Application.Quit();
    }
}
