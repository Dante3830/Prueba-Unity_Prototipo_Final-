using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour {

    // Referencia al texto para actualizar
    [SerializeField] TextMeshProUGUI appleCountText;
    [SerializeField] TextMeshProUGUI scoreCountText;

    // Referencia al menú
    [SerializeField] GameObject menuConfig;

    // Actualizar texto de manzanas
    public void UpdateApplesTextHUD(string numberText) {
        appleCountText.text = numberText;
    }

    // Actualizar texto de puntaje
    public void UpdateScoreTextHUD(string pointsText) {
        scoreCountText.text = pointsText;
    }

    // Activa la pausa/continuar
    private void OnEnable() {
        GameEvents.OnPause += Pause;
        GameEvents.OnResume += Resume;
    }

    // Desactiva la pausa/continuar
    private void OnDisable() {
        GameEvents.OnPause -= Pause;
        GameEvents.OnResume -= Resume;
    }

    // Activa el menú de pausa
    private void Pause() {
        menuConfig.SetActive(true);
    }

    // Desactiva el menú de pausa
    private void Resume() {
        menuConfig.SetActive(false);
    }

}
