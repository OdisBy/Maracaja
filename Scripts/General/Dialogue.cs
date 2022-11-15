using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string nome;

    [TextArea(3, 10)]
    public string[] sentencas;
    public string recusouSentenca;
    public string inQuestSentenca;
    public string acceptSentenca;
    public string redencaoSentenca;
    public string concluiuSentenca;
}
