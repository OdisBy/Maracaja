using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public List<AnimalScript> animais = new List<AnimalScript>();
    public void picture()
    {
        foreach(AnimalScript animal in animais)
        {
            return;
        }
    }
}
