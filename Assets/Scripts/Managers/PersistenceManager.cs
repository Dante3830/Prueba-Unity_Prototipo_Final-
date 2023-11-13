using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class PersistenceManager : MonoBehaviour {
    // Instancia del Persistence Manager
    public static PersistenceManager Instance { get; private set; }

    // Llave de brillo, panel, volumen, full screen y puntaje
    public string KeyBright { get => Instance.keyBright; }
    public Image KeyPanel { get => Instance.keyPanel; }
    public static string KeyVolume { get => Instance.keyVolume; }
    public string KeyFullScreen { get => Instance.keyFullScreen; }
    public string KeyScore { get => Instance.keyScore; }

    [SerializeField] private string keyBright, keyVolume, keyFullScreen, keyScore;
    [SerializeField] private Image keyPanel;

    // Inicializar el componente
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Setear entero
    public void SetInt(string key, int value) {
        PlayerPrefs.SetInt(key, value);
    }

    // Tomar entero
    public int GetInt(string key, int defaultValue = 0) {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    // Setear float
    public void SetFloat(string key, float value) {
        PlayerPrefs.SetFloat(key, value);
    }

    // Tomar float
    public float GetFloat(string key, float defaultValue = 0.0f) {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    // Setear string
    public void SetString(string key, string value) {
        PlayerPrefs.SetString(key, value);
    }

    // Tomar string
    public string GetString(string key, string defaultValue = "") {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    // Setear booleano
    public void SetBool(string key, bool state) {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    // Tomar booleano
    public bool GetBool(string key, bool defaultValue = false) {
        int value = PlayerPrefs.GetInt(key, defaultValue ? 1 : 0);
        return value == 1;
    }

    // Guardar configuración
    public void Save() {
        PlayerPrefs.Save();
    }

    // Eliminar llave
    public void DeleteKey(string key) {
        PlayerPrefs.DeleteKey(key);
    }

    // Elimina todo
    public void DeleteAll() {
        PlayerPrefs.DeleteAll();
    }

    // Guardar configuración del brillo
    public void SaveBrightConfiguration(float bright) {
        SetFloat(keyBright, bright);
        Debug.Log("Brillo: " + bright);
        keyPanel.color = new Color(keyPanel.color.r, keyPanel.color.g, keyPanel.color.b, bright);
    }

    // Guardar configuración del volumen
    public void SaveVolumeConfiguration(float volume) {
        SetFloat(keyVolume, volume);
        Debug.Log("Volumen escogido: " + volume);
        AudioListener.volume = volume;
    }

    // Guardar configuración de la pantalla
    public void SaveFullScreen(bool state) {
        SetBool(keyFullScreen, state);
        Screen.fullScreen = state;
        Debug.Log("Pantalla completa: " + state);
    }
}
