using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    int actualPlayer;
    public float somGeral;
    public float somAnimais;
    public float somBG;
    public float somMusica;
    public float somPersonagem;

    public int dayNight;

    public GameObject BGM, BG;
    public GameObject BGTheme, BGNight;


    public FMODUnity.EventReference miadoGatoRef;
    public FMODUnity.EventReference passosSoundRef;
    public FMODUnity.EventReference fotoSoundRef;
    public FMODUnity.EventReference escalandoSoundRef;
    public FMODUnity.EventReference caindoChaoSoundRef;
    public FMODUnity.EventReference caindoSoundRef;
    public FMODUnity.EventReference pulandoSoundRef;

    public FMOD.Studio.EventInstance miadoGato;
    public FMOD.Studio.EventInstance fotoSound;
    public FMOD.Studio.EventInstance escalandoSound;
    public FMOD.Studio.EventInstance caindoChaoSound;
    public FMOD.Studio.EventInstance caindoSound;
    public FMOD.Studio.EventInstance pulandoSound;
    public FMOD.Studio.EventInstance passosSound;

    public void Start(){
        atualizarSom();
        BGM.SetActive(true);
        BG.SetActive(true);
        BGTheme.SetActive(false);
        BGNight.SetActive(false);


        miadoGato = FMODUnity.RuntimeManager.CreateInstance(miadoGatoRef);
        passosSound = FMODUnity.RuntimeManager.CreateInstance(passosSoundRef);
        fotoSound = FMODUnity.RuntimeManager.CreateInstance(fotoSoundRef);
        escalandoSound = FMODUnity.RuntimeManager.CreateInstance(escalandoSoundRef);
        caindoChaoSoundRef = FMODUnity.RuntimeManager.CreateInstance(caindoChaoSoundRef);
        caindoChaoSound = FMODUnity.RuntimeManager.CreateInstance(caindoSoundRef);
        pulandoSound = FMODUnity.RuntimeManager.CreateInstance(pulandoSoundRef);
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
    }

    void getActualVolume(){
        somGeral = PlayerPrefs.GetFloat("somGeral", 100);
        somAnimais = PlayerPrefs.GetFloat("somAnimais", 100);
        somBG = PlayerPrefs.GetFloat("somBG", 100);
        somMusica = PlayerPrefs.GetFloat("somMusica", 100);
        somPersonagem = PlayerPrefs.GetFloat("somPersonagem", 100);
    }


    public void foto(){
        fotoSound.start();
    }
    public void Passo(){
        passosSound.start();
    }
    public void Escalando(){
        escalandoSound.start();
    }
    public void CairNoChao(){
        caindoChaoSoundRef.start();
    }
    public void caindo(){
        caindoChaoSound.start();
    }
    public void Pulando(){
        pulandoSound.start();
    }

    public void miadoGatoFunc(){
        miadoGato.start();
    }

}
