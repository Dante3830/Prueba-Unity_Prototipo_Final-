using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

    // Referencia al texto de derrota 
    [SerializeField] public GameObject defeatText;

    // Referencia al Audio Source
    public AudioSource audioSource;

    // Sonido de daño
    public AudioClip hurtSFX;

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
}
