using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{
    // Instancia del Application Manager
    public static ApplicationManager Instance { get; private set; }

    // Inicializar el componente
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Abre la próxima escena
    public void GoToNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(nextSceneIndex);
        } else {
            Debug.LogWarning("No hay más escenas después de la actual en Build Settings");
        }
    }

    // Abre la escena anterior
    public void GoToPreviousScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0) {
            SceneManager.LoadScene(previousSceneIndex);
        } else {
            Debug.LogWarning("No hay más escenas después de la actual en Build Settings");
        }
    }

}
