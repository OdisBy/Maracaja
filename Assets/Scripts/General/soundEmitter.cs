using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEmitter : MonoBehaviour
{
    public AudioController AudioController;
    public FMODUnity.EventReference eventoAnimal;
    public FMOD.Studio.EventInstance instanceFMOD;
    public AnimalScript animal;

    public float somAnimais;
    float geralVolume;

    void Start(){
        instanceFMOD = FMODUnity.RuntimeManager.CreateInstance(eventoAnimal);
        instanceFMOD.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
            if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                tocarSom();
            }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                pararSom();
            }
    }

    void tocarSom(){
        if(!animal.jaDialogou){
            getActualVolume();
            instanceFMOD.setVolume(somAnimais);
            
            instanceFMOD.start();
        }
    }

    public void pararSom() {
        instanceFMOD.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void atualizarSom(){
        instanceFMOD.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        getActualVolume();
        instanceFMOD.start();
    }
    

    public void getActualVolume(){
        geralVolume = PlayerPrefs.GetFloat("somGeral", 100);
        somAnimais = PlayerPrefs.GetFloat("somAnimais", 100);
        Debug.Log(geralVolume);
        somAnimais *= (geralVolume / 1);
        Debug.Log(somAnimais);
        
    }
}
