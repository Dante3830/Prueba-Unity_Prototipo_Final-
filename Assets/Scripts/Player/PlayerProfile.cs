using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewPlayerProfile", menuName = "Scriptable Objects/Player Profile", order = 1)]

public class PlayerProfile : ScriptableObject {
    // Puntos de experiencia para llegar al siguiente nivel
    [Header("Configuraciones de Progresión")]
    
    [SerializeField]
    [Tooltip("Cantidad de puntos ganados por agarrar manzanas")]
    [Range(100, 200)]
    private int pointsApple = 100;
    public int PointsApple { get => pointsApple; set => pointsApple = value; }

    // Configuraciones de Movimiento (salto y velocidad)
    [Header("Configuraciones de Movimiento")]

    [SerializeField]
    [Tooltip("Velocidad de correr")]
    private float runSpeed = 2f;
    public float RunSpeed { get => runSpeed; set => runSpeed = value; }

    [SerializeField]
    [Tooltip("Velocidad del salto")]
    private float jumpSpeed = 3f;
    public float JumpSpeed { get => jumpSpeed; set => jumpSpeed = value; }

    [SerializeField]
    [Tooltip("Si se activa, el personaje salta de acuerdo a qué " +
             "tan presionado esté el botón de salto")]
    private bool betterJump = false;
    public bool BetterJump { get => betterJump; set => betterJump = value; }

    [SerializeField]
    [Tooltip("Como aumenta la gravedad de la caída " +
        "(Sólo si Better Jump está activado)")]
    private float fallMultiplier = 0.5f;
    public float FallMultiplier { get => fallMultiplier; set => fallMultiplier = value; }

    [SerializeField]
    [Tooltip("Como aumenta la gravedad del salto " +
        "(Sólo si Better Jump está activado)")]
    private float lowJumpMultiplier = 1f;
    public float LowJumpMultiplier { get => lowJumpMultiplier; set => lowJumpMultiplier = value; }

    // Configuraciones de efectos de sonido
    [Header("Configuraciones SFX")]
    
    [SerializeField] private AudioClip jumpSFX;
    public AudioClip JumpSFX { get => jumpSFX; }

    [SerializeField] private AudioClip collisionSFX;
    public AudioClip CollisionSFX { get => collisionSFX; }

    [SerializeField] private AudioClip hurtSFX;
    public AudioClip HurtSFX { get => hurtSFX; }
}
