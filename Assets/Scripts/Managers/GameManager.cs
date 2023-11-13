using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Instancia del Game Manager
    public static GameManager Instance { get; private set; }
    
    // Puntaje
    private int score;

    // Inicializar el componente
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            score = Mathf.Max(PlayerPrefs.GetInt("Score"), 0);
        } else {
            Destroy(gameObject);
        }
    }

    // Activa la pausa/continuación
    private void OnEnable() {
        GameEvents.OnPause += Pause;
        GameEvents.OnResume += Resume;
    }

    // Desactiva la pausa/continuación
    private void OnDisable() {
        GameEvents.OnPause -= Pause;
        GameEvents.OnResume -= Resume;
    }

    // Pausa el juego
    private void Pause() {
        Time.timeScale = 0;
        Debug.Log("PAUSADO");
    }

    // Reanuda el juego
    private void Resume() {
        Time.timeScale = 1;
        Debug.Log("REANUDADO");
    }

    // Recibe la tecla Escape para pausar
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale != 0) {
                GameEvents.TriggerPause();
            } else {
                GameEvents.TriggerResume();
            }
        }
    }

    // Sumar puntos obtenidos
    public void AddScore(int points) {
        score += points;

        if (score < 0) {
            score = 0;
        }

        PlayerPrefs.SetInt("Score", score);
    }

    // Resetear puntaje
    public void ResetScore() {
        score = 0;
    }

    // Obtener puntos
    public int GetScore() {
        return score;
    }
}
