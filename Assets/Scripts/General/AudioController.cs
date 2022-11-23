using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    int actualPlayer;
    public AudioSource Foto;
    public AudioSource passo;
    public AudioSource escalando;
    public AudioSource CairChao;
    public AudioSource Caindo;
    public AudioSource pulando;
    public AudioSource Zoom;
    public AudioClip[] ararajuba;
    public AudioClip[] gatoMiado;
    public float somGeral;
    public float somAnimais;
    public float somBG;
    public float somMusica;
    public float somPersonagem;

    public int dayNight;


    public FMOD.Studio.EventInstance ararajubaFMOD;
    public FMOD.Studio.EventInstance macacoFMOD;
    public FMOD.Studio.EventInstance oncaFMOD;
    public FMOD.Studio.EventInstance tamanduaFMOD;

    public GameObject BGM, BG;
    public GameObject BGTheme, BGNight;

    public void Start(){
        atualizarSom();
        BGM.SetActive(true);
        BG.SetActive(true);
        BGTheme.SetActive(false);
        BGNight.SetActive(false);
    }
    public void diaNoite(){
        dayNight = PlayerPrefs.GetInt("fase", 0);

        if(dayNight % 2 == 0){
            BGM.SetActive(true);
            BG.SetActive(true);
            BGTheme.SetActive(false);
            BGNight.SetActive(false);
        }else {
            BGM.SetActive(false);
            BG.SetActive(false);
            BGTheme.SetActive(true);
            BGNight.SetActive(true);
        }
    }
    public void atualizarSom(){
        getActualVolume();

        //PERSONAGEM SONS
        Foto.volume = somPersonagem;
        passo.volume = somPersonagem;
        escalando.volume = somPersonagem;
        CairChao.volume = somPersonagem;
        Caindo.volume = somPersonagem;
        pulando.volume = somPersonagem;
        Zoom.volume = somPersonagem;

        //ANIMAIS SONS
        ararajubaFMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Ararajuba");
        macacoFMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Macaco");
        tamanduaFMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Onca");
        oncaFMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Tamandua");
    }

    void getActualVolume(){
        somGeral = PlayerPrefs.GetFloat("somGeral", 100);
        somAnimais = PlayerPrefs.GetFloat("somAnimais", 100);
        somBG = PlayerPrefs.GetFloat("somBG", 100);
        somMusica = PlayerPrefs.GetFloat("somMusica", 100);
        somPersonagem = PlayerPrefs.GetFloat("somPersonagem", 100);
    }

    public void ajustarVolume(){
        getActualVolume();
        ararajubaFMOD.setVolume(somAnimais);
        macacoFMOD.setVolume(somAnimais);
        tamanduaFMOD.setVolume(somAnimais);
        oncaFMOD.setVolume(somAnimais);
    }

    void Update(){
        ararajubaFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        macacoFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        tamanduaFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        oncaFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

    }

    public void foto(){
        Foto.Play();
    }
    public void Passo(){
        passo.Play();
    }
    public void Escalando(){
        escalando.Play();
    }
    public void CairNoChao(){
        CairChao.Play();
    }
    public void caindo(){
        Caindo.Play();
    }
    public void Pulando(){
        pulando.Play();
    }
    public void zoom(){
        Zoom.Play();
    }

    public void ararajubaSom(){
        ararajubaFMOD.start();
    }
    public void tamanduaSom(){
        tamanduaFMOD.start();
    }
    public void macacoSom(){
        macacoFMOD.start();
    }
    public void oncaSom(){
        oncaFMOD.start();
    }

    public void miadoGato(){
        actualPlayer = Random.Range(0, 2);
        audioSource.clip = gatoMiado[actualPlayer]; 
        audioSource.Play();
    }

}
