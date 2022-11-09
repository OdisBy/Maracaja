using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vitoriaRegia : MonoBehaviour
{
    float respawnTime = 5.0f;
    private Vector3 initialPosition;
    private Rigidbody2D rb;
    public string currentState;
    public Animator anim;
    

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());

        }
    }

    IEnumerator Fall()
    {
        ChangeState("vitoriaRegiaDescendo");
        yield return new WaitForSecondsRealtime(1.30f);
        DropPlatform();
        yield return new WaitForSecondsRealtime(respawnTime);
        respawnPlataform();

    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }

    void respawnPlataform()
    {
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
        transform.position = initialPosition;
        ChangeState("vitoriaRegia");
    }


    //MAQUINA DE ESTADOS ANIMAÇÃO
    internal void ChangeState(string newState)
    {
        if (newState != currentState)
        {
            anim.Play(newState);
            currentState = newState;
        }
    }
}
