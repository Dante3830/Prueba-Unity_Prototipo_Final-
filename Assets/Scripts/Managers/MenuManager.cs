using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MenuManager : MonoBehaviour {

    // Instancia del Menu Manager
    public static MenuManager Instance { get; private set; }

    // Sliders de volumen y brillo
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider brightSlider;

    // Toggle de pantalla comlpeta
    [SerializeField] private Toggle fullScreenToggle;

    // Panel de brillo
    [SerializeField] public Image brightPanel;

    // Asigna los valores iniciales
    void Start() {
        // Volumen
        volumeSlider.value = PersistenceManager.Instance.GetFloat("Volume", 0.5f);

        // Brillo
        brightSlider.value = PersistenceManager.Instance.GetFloat("Brightness", 0.1f);
        brightPanel.color = new Color(brightPanel.color.r, brightPanel.color.g, brightPanel.color.b, brightSlider.value);

        // Pantalla completa
        fullScreenToggle.isOn = PersistenceManager.Instance.GetBool("Fullscreen", false);

        // Si la pantalla está completa, el toggle está activado
        if (Screen.fullScreen){
            fullScreenToggle.isOn = true;
        } else {
            // De lo contrario, está desactivado
            fullScreenToggle.isOn = false;
        }
    }

    private void OnDisable() {
        PersistenceManager.Instance.Save();
    }

    private void OnEnable() {
        PersistenceManager.Instance.SetInt("Score", GameManager.Instance.GetScore());
    }

}
