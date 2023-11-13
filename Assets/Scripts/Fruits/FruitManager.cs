using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class FruitManager : MonoBehaviour {

    // Manzanas del nivel
    private int apples = 30;
    public int Apples { get => apples; set => apples = value; }

    // Manzanas restantes en pantalla
    [SerializeField] private UnityEvent<int> OnApplesChanged;
    [SerializeField] public UnityEvent<string> OnTextChanged;

    // Referencia al texto de victoria
    [SerializeField] public TextMeshProUGUI victoryText;

    // Inicia la cantidad de manzanas
    private void Start() {
        OnApplesChanged.Invoke(Apples);
        OnTextChanged.Invoke(Apples.ToString());
    }

    // Chequea todo el tiempo si todas las frutas fueron recolectadas
    private void Update() {
        AllFruitsCollected();
    }

    // Si todas las frutas del nivel fueron recolectadas,
    // se muestra texto de victoria
    public void AllFruitsCollected() {
        if (transform.childCount == 0) {
            Debug.Log("No apples left. VICTORY!");

            victoryText.gameObject.SetActive(true);

            Time.timeScale = 0;

            // Y luego abre el menú principal
            ApplicationManager.Instance.GoToPreviousScene();
        }
    }

}