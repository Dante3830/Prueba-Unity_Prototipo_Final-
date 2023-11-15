using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Referencia al Audio Source
    public AudioSource audioSource;

    // Sonido de daño
    public AudioClip hurtSFX;

    // Inicia invocando al método Disable Object
    void Start() {
        Invoke("DisableObject", 5f);
    }

    // Si el personaje se colisiona con el enemigo,
    // el personaje se transporta al check point
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Player")) {
            Debug.Log("Player Damaged");

            if (audioSource.isPlaying) {
                return;
            }

            // Dar play al sonido de lastimar al jugador
            audioSource.PlayOneShot(hurtSFX);

            collision.gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
    }

    // Desactiva el objeto del enemigo
    private void DisableObject () {
        gameObject.SetActive(false);
    }
}
