using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Animación del sprite a la izquierda
public interface ILeft {
    void LeftAnim();
}

// Animación del sprite a la derecha
public interface IRight {
    void RightAnim();
}

// Animación del sprite quieto
public interface IIdle {
    void IdleAnim();
}

public class PlayerSprite : MonoBehaviour, ILeft, IRight, IIdle {
    // Referencia al Sprite Renderer
    public SpriteRenderer spriteRenderer;

    // Referencia al Animator
    public Animator animator;

    // Update is called once per frame
    void FixedUpdate() {
        // Si no está en el suelo, mostrará animación de salto (Jump)
        if (!CheckGround.isGrounded) {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else {
            // De lo contrario, no se muestra
            animator.SetBool("Jump", false);
        }
    }

    // Mostrar animación de mover a la izquierda
    public void LeftAnim() {
        spriteRenderer.flipX = true;
        animator.SetBool("Run", true);
    }

    // Mostrar animación de mover a la derecha
    public void RightAnim() {
        spriteRenderer.flipX = false;
        animator.SetBool("Run", true);
    }

    // Mostrar animación de estar quieto
    public void IdleAnim() {
        animator.SetBool("Run", false);
    }
}
