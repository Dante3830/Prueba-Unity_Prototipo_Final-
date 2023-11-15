using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz del salto
public interface IJumping {
    void Jump();
    void DoubleJump();
}

public class PlayerJump : MonoBehaviour, IJumping {
    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Efecto de sonido de salto
    private IJump jump;

    // Animación de caída
    private IFalling fall;

    // Rigidbody 2D
    private Rigidbody2D rb2D;

    private void Start() {
        // Iniciar componente del sonido de salto
        jump = GetComponent<IJump>();

        // Iniciar componente de animación de caída
        fall = GetComponent<IFalling>();

        // Llamar al componente Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        // Si el jugador está cayendo, se activa la animación de caída
        if (rb2D.velocity.y < 0)  {
            fall.FallAnimTrue();
        }
        else if (rb2D.velocity.y > 0) {
            // De lo contrario, se desactiva
            fall.FallAnimFalse();
        }
    }

    // El jugador salta
    public void Jump() {
        // Si presiona espacio o la tecla arriba, el personaje salta
        rb2D.velocity = new Vector2(rb2D.velocity.x, playerProfile.JumpSpeed);
        jump.PlayJump();

        // En caso de que Better Jump sea true...
        if (playerProfile.BetterJump) {
            // El jugador caerá con la velocidad del multiplicador de caída
            if (rb2D.velocity.y < 0) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.FallMultiplier) * Time.deltaTime;
            }
            else if (rb2D.velocity.y > 0 && (!Input.GetKey("space") || !Input.GetKey("up"))) {
                // De lo contrario, el jugador saltará dependiendo de cuánto presione la tecla de salto
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.LowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    // El jugador realiza un salto doble
    public void DoubleJump() {
        // Si presiona espacio o la tecla arriba mientras está en el aire,
        // el personaje realizará el segundo salto
        rb2D.velocity = new Vector2(rb2D.velocity.x, playerProfile.DoubleJumpSpeed);
        jump.PlayJump();

        // En caso de que Better Jump sea true...
        if (playerProfile.BetterJump) {
            // El jugador caerá con la velocidad del multiplicador de caída
            if (rb2D.velocity.y < 0) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.FallMultiplier) * Time.deltaTime;
            }
            else if (rb2D.velocity.y > 0 && (!Input.GetKey("space") || !Input.GetKey("up"))) {
                // De lo contrario, el jugador saltará dependiendo de cuánto presione la tecla de salto
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.LowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

}

