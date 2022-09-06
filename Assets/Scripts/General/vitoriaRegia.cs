using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vitoriaRegia : MonoBehaviour
{
    public float respawnTime = 10.0f;
    public float delayTime = 3.0f;
    private Vector3 initialPosition;
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            Debug.Log("Player collision vitoria regia");
            StartCoroutine(Fall());

        }
    }

    IEnumerator Fall()
    {
        DropPlatform();
        yield return new WaitForSecondsRealtime(5f);
        respawnPlataform();

    }

    void DropPlatform()
    {
        rb.isKinematic = false;
    }

    void respawnPlataform()
    {
        rb.velocity = new Vector2(0, 0);
        Debug.Log("Respawn");
        rb.isKinematic = true;
        transform.position = initialPosition;
    }
}
