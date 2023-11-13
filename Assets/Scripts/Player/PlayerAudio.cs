using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz del sonido de colisión
public interface ICollision {
    void PlayCollision();
}

// Interfaz del sonido de salto
public interface IJump {
    void PlayJump();
}

public class PlayerAudio : MonoBehaviour, ICollision, IJump {
    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Referencia al Audio Source
    public AudioSource audioSource;

    // Obtener componente Audio Source
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Ejecuta sonido de salto
    public void PlayCollision() {
        if (audioSource.isPlaying) {
            return;
        }

        audioSource.PlayOneShot(playerProfile.CollisionSFX);
    }

    // Ejecuta sonido de colisión
    public void PlayJump() {
        if (audioSource.isPlaying) {
            return;
        }

        audioSource.PlayOneShot(playerProfile.JumpSFX);
    }

}
