using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Progression : MonoBehaviour {
    // Puntaje del jugador
    private int highScore;
    public int HighScore { get => highScore; set => highScore = value; }

    // Referencia al script Score
    public Score score;

    // Referncia al Player Profile
    [SerializeField] private PlayerProfile playerProfile;
    public PlayerProfile PlayerProfile { get => playerProfile; set => playerProfile = value; }

    // Suma los puntos ganados
    public void WinPoints(int points) {
        //Averigua si Player Profile es null
        if (playerProfile == null) {
            Debug.LogError("Player Profile is null. Cannot win points.");
            return;
        }

        HighScore += points;

        GameManager.Instance.AddScore(points);

        // Actualiza texto del puntaje
        score.OnTextChanged.Invoke(GameManager.Instance.GetScore().ToString());

        Debug.Log("Score: " + HighScore);
    }
}