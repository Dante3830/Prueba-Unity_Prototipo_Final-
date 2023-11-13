using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIController : MonoBehaviour {
    // Carga la siguiente escena
    public void loadNextScene() {
        ApplicationManager.Instance.GoToNextScene();
    }
}
