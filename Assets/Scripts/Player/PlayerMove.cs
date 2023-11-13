using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mover a la izquierda
public interface IMoveLeft {
    void MoveLeft();
}

// Mover a la derecha
public interface IMoveRight {
    void MoveRight();
}

// Quedarse quieto
public interface IStill {
    void StayStill();
}

public class PlayerMove : MonoBehaviour, IMoveLeft, IMoveRight, IStill {
    // Referencia al Player Profile
    public PlayerProfile playerProfile;

    // Sprite y partículas
    private ILeft left;
    private IRight right;
    private IIdle idle;
    private IParticles particles;

    // Rigidbody 2D
    private Rigidbody2D rb2D;

    // Agarra el componente "Rigidbody2D" del personaje
    private void OnEnable() {
        rb2D = GetComponent<Rigidbody2D>();
    }
    
    private void Start() {
        particles = GetComponent<IParticles>();
        left = GetComponent<ILeft>();
        right = GetComponent<IRight>();
        idle = GetComponent<IIdle>();
    }

    public void MoveLeft() {
        rb2D.velocity = new Vector2(-playerProfile.RunSpeed, rb2D.velocity.y);

        left.LeftAnim();

        if (CheckGround.isGrounded) {
            particles.PlayParticles();
        }
    }

    public void MoveRight() {
        rb2D.velocity = new Vector2(playerProfile.RunSpeed, rb2D.velocity.y);

        right.RightAnim();

        if (CheckGround.isGrounded) {
            particles.PlayParticles();
        }
    }

    public void StayStill() {
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        idle.IdleAnim();
    }

}
