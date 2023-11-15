using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    // Referencia al Progression del jugador
    public Progression progressionPlayer;

    // Texto del puntaje en pantalla
    [SerializeField] private UnityEvent<int> OnPointsChanged;
    [SerializeField] public UnityEvent<string> OnTextChanged;

    // Convierte a string el puntaje del jugador
    private void Start() {
        OnPointsChanged.Invoke(progressionPlayer.HighScore);
        OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());
    }

}
