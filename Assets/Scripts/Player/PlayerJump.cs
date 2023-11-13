using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz del salto
public interface IJumping {
    void Jump();
}

public class PlayerJump : MonoBehaviour, IJumping {
    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Efecto de sonido de salto
    private IJump jump;

    // Rigidbody 2D
    private Rigidbody2D rb2D;

    // Iniciar componente del sonido de salto
    private void Start() {
        jump = GetComponent<IJump>();
    }

    // Llamar al componente Rigidbody2D
    private void OnEnable() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // El jugador salta
    public void Jump() {
        // Si presiona espacio o la tecla arriba, el personaje salta
        rb2D.velocity = new Vector2(rb2D.velocity.x, playerProfile.JumpSpeed);
        jump.PlayJump();        

        // En caso de que Better Jump sea true...
        if (playerProfile.BetterJump) {

            if (rb2D.velocity.y < 0) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.FallMultiplier) * Time.deltaTime;
            }
            else if (rb2D.velocity.y > 0 && !Input.GetKey("space")) {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (playerProfile.LowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
