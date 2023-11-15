using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneral : MonoBehaviour {

    // Interfaces para mover a la izquierda y derecha
    private IMoveLeft moveLeft;
    private IMoveRight moveRight;

    // Interfaz para quedarse quieto
    private IStill still;

    // Interfaz para saltar y realizar salto doble
    private IJumping jumping;
    private IDoubleJump doubleJump;

    // Referencia al Progression
    public Progression progressionPlayer;

    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Checkea si el jugador puede realizar el salto doble
    private bool canDoubleJump;

    private void Start() {
        // Inicia los movimientos del personaje
        moveLeft = GetComponent<IMoveLeft>();
        moveRight = GetComponent<IMoveRight>();
        still = GetComponent<IStill>();
        jumping = GetComponent<IJumping>();
        doubleJump = GetComponent<IDoubleJump>();

        // Inicia el puntaje en 0
        if (playerProfile != null) {
            Debug.Log("Player Profile is not null. Score: " + progressionPlayer.HighScore);
        } else {
            Debug.LogWarning("Player Profile is null. Make sure to assign it in the Unity Editor.");
        }
    }

    private void Update() {
        // Si presiona Espacio/arriba, el personaje salta
        if (Input.GetKey("space") || Input.GetKey("up")) {

            // Si el personaje está en el suelo, puede saltar
            if (CheckGround.isGrounded) {
                canDoubleJump = true;
                jumping.Jump();
            }
            else {

                // Si el personaje está en el aire, puede realizar un salto doble
                if (Input.GetKeyDown("space") || Input.GetKeyDown("up")) {

                    if (canDoubleJump) {
                        Debug.Log("Salto doble");
                        doubleJump.DoubleJumpAnim();
                        jumping.DoubleJump();
                        canDoubleJump = false;
                    }

                }

            }
            
        }
    }

    // Presta atención a las teclas
    private void FixedUpdate() {
        // Si presiona A/izquierda, se mueve a la izquierda
        if ((Input.GetKey("a")) || Input.GetKey("left")) {
            moveLeft.MoveLeft();
        }
        // Si presiona D/derecha, se mueve a la derecha
        else if ((Input.GetKey("d")) || Input.GetKey("right")) {
            moveRight.MoveRight();
        }
        else {
            // De lo contrario, se queda quieto
            still.StayStill();
        }

    }

}
