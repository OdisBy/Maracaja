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



    public FMODUnity.EventReference miadoGatoRef;
    public FMODUnity.EventReference passosSoundRef;
    public FMODUnity.EventReference fotoSoundRef;
    public FMODUnity.EventReference escalandoSoundRef;
    public FMODUnity.EventReference caindoChaoSoundRef;
    public FMODUnity.EventReference caindoSoundRef;
    public FMODUnity.EventReference pulandoSoundRef;
    public FMODUnity.EventReference zoomSoundRef;
    public FMODUnity.EventReference bgMusicaDiaSoundRef;
    public FMODUnity.EventReference bgSoundDiaSoundRef;
    public FMODUnity.EventReference bgMusicaNoiteSoundRef;
    public FMODUnity.EventReference bgSoundNoiteSoundRef;

    public FMOD.Studio.EventInstance miadoGato;
    public FMOD.Studio.EventInstance fotoSound;
    public FMOD.Studio.EventInstance escalandoSound;
    public FMOD.Studio.EventInstance caindoChaoSound;
    public FMOD.Studio.EventInstance caindoSound;
    public FMOD.Studio.EventInstance pulandoSound;
    public FMOD.Studio.EventInstance passosSound;
    public FMOD.Studio.EventInstance zoomSound;
    public FMOD.Studio.EventInstance bgMusicaDiaSound;
    public FMOD.Studio.EventInstance bgSoundDiaSound;
    public FMOD.Studio.EventInstance bgMusicaNoiteSound;
    public FMOD.Studio.EventInstance bgSoundNoiteSound;

    public GameObject player;

    public void Start(){
        atualizarSom();


        miadoGato = FMODUnity.RuntimeManager.CreateInstance(miadoGatoRef);
        passosSound = FMODUnity.RuntimeManager.CreateInstance(passosSoundRef);
        fotoSound = FMODUnity.RuntimeManager.CreateInstance(fotoSoundRef);
        escalandoSound = FMODUnity.RuntimeManager.CreateInstance(escalandoSoundRef);
        caindoChaoSound = FMODUnity.RuntimeManager.CreateInstance(caindoChaoSoundRef);
        caindoSound = FMODUnity.RuntimeManager.CreateInstance(caindoSoundRef);
        pulandoSound = FMODUnity.RuntimeManager.CreateInstance(pulandoSoundRef);
        zoomSound = FMODUnity.RuntimeManager.CreateInstance(zoomSoundRef);

        bgMusicaDiaSound = FMODUnity.RuntimeManager.CreateInstance(bgMusicaDiaSoundRef);
        bgSoundDiaSound = FMODUnity.RuntimeManager.CreateInstance(bgSoundDiaSoundRef);
        bgMusicaNoiteSound = FMODUnity.RuntimeManager.CreateInstance(bgMusicaNoiteSoundRef);
        bgSoundNoiteSound = FMODUnity.RuntimeManager.CreateInstance(bgSoundNoiteSoundRef);

        tocarDia();
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

        bgMusicaDiaSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        bgSoundDiaSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        bgMusicaNoiteSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));
        bgSoundNoiteSound.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(player));

    }
    public void diaNoite(){
        dayNight = PlayerPrefs.GetInt("fase", 0);
        atualizarSom();

        if(dayNight % 2 == 0){
            trocarNoiteParaDia();
        }else {
            trocarDiaParaNoite();
        }
    }
    public void atualizarSom(){
        getActualVolume();

        somPersonagem *= (somGeral / 1);
        somBG *= (somGeral / 1);
        //PERSONAGEM SONS

        miadoGato.setVolume(somPersonagem);
        passosSound.setVolume(somPersonagem);
        fotoSound.setVolume(somPersonagem);
        escalandoSound.setVolume(somPersonagem);
        caindoChaoSound.setVolume(somPersonagem);
        caindoSound.setVolume(somPersonagem);
        pulandoSound.setVolume(somPersonagem);
        zoomSound.setVolume(somPersonagem);

        bgMusicaDiaSound.setVolume(somBG);
        bgSoundDiaSound.setVolume(somBG);
        bgMusicaNoiteSound.setVolume(somBG);
        bgSoundNoiteSound.setVolume(somBG);
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

    public void tocarDia(){
        atualizarSom();
        bgMusicaDiaSound.start();
        bgSoundDiaSound.start();
    }
    public void tocarNoite(){
        atualizarSom();
        bgMusicaNoiteSound.start();
        bgSoundNoiteSound.start();
    }
    public void trocarDiaParaNoite(){
        atualizarSom();
        bgMusicaDiaSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bgSoundDiaSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        tocarNoite();
    }
    public void trocarNoiteParaDia(){
        bgMusicaNoiteSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        bgSoundNoiteSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        tocarDia();
    }

    public void pararSomConfig(){
        dayNight = PlayerPrefs.GetInt("fase", 0);
        atualizarSom();

        if(dayNight % 2 == 0){
            bgMusicaDiaSound.setPaused(true);
            bgSoundDiaSound.setPaused(true);
        }else {
            bgMusicaNoiteSound.setPaused(true);
            bgSoundNoiteSound.setPaused(true);
        }
    }
    public void voltarSomConfig(){
        dayNight = PlayerPrefs.GetInt("fase", 0);
        atualizarSom();

        if(dayNight % 2 == 0){
            bgMusicaDiaSound.setPaused(false);
            bgSoundDiaSound.setPaused(false);
        }else {
            bgMusicaNoiteSound.setPaused(false);
            bgSoundNoiteSound.setPaused(false);
        }
    }
}
