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
    public FMODUnity.EventReference zoomSoundRef;

    public FMOD.Studio.EventInstance miadoGato;
    public FMOD.Studio.EventInstance fotoSound;
    public FMOD.Studio.EventInstance escalandoSound;
    public FMOD.Studio.EventInstance caindoChaoSound;
    public FMOD.Studio.EventInstance caindoSound;
    public FMOD.Studio.EventInstance pulandoSound;
    public FMOD.Studio.EventInstance passosSound;
    public FMOD.Studio.EventInstance zoomSound;

    public GameObject player;

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
        caindoChaoSound = FMODUnity.RuntimeManager.CreateInstance(caindoChaoSoundRef);
        caindoSound = FMODUnity.RuntimeManager.CreateInstance(caindoSoundRef);
        pulandoSound = FMODUnity.RuntimeManager.CreateInstance(pulandoSoundRef);
        zoomSound = FMODUnity.RuntimeManager.CreateInstance(zoomSoundRef);

    }

    void Update(){
        miadoGato.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        passosSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        fotoSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        zoomSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        escalandoSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        caindoChaoSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        caindoSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        pulandoSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
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
        miadoGato.setVolume(somPersonagem);
        passosSound.setVolume(somPersonagem);
        fotoSound.setVolume(somPersonagem);
        escalandoSound.setVolume(somPersonagem);
        caindoChaoSound.setVolume(somPersonagem);
        caindoSound.setVolume(somPersonagem);
        pulandoSound.setVolume(somPersonagem);
        zoomSound.setVolume(somPersonagem);
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
    public void zoom(){
        zoomSound.start();
    }
    public void Passo(){
        passosSound.start();
    }
    public void Escalando(){
        escalandoSound.start();
    }
    public void CairNoChao(){
        caindoChaoSound.start();
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
