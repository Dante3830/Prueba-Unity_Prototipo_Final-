using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // Referencia al texto de derrota 
    [SerializeField] public TextMeshProUGUI defeatText;

    // Posiciones de checkpoint en X e Y
    private float checkPointPositionX;
    private float checkPointPositionY;

    // Corazones del HUD
    public GameObject[] hearts;

    // Vidas del jugador
    private int lives;

    // Inicializa la posición
    void Start() {
        lives = hearts.Length;
        Debug.Log(lives.ToString());

        if (PlayerPrefs.GetFloat("checkPointPositionX")!=0) {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
    }

    // Chequea la vida del jugador y resta los corazones
    private void CheckLife() {
        if (lives < 1) {
            Destroy(hearts[0].gameObject);
        }
        else if (lives < 2) {
            Destroy(hearts[1].gameObject);
        }
        else if (lives < 3) {
            Destroy(hearts[2].gameObject);
        }
    }

    // Setea la posición para guardar
    public void ReachedCheckPoint(float x, float y) {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    // Resta una vida y llama al método Check Life
    public void PlayerDamaged() {
        lives--;
        Debug.Log(lives.ToString());
        CheckLife();
    }

    // Si el jugador colisiona con un enemigo,
    // al jugador se le resta un punto de vida
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Enemy")) {
            PlayerDamaged();

            // Si el jugador no tiene más vidas,
            if (lives <= 0) {
                Debug.Log("GAME OVER");

                // Elimina el objeto que colisiona (el jugador)
                Destroy(GetComponentInParent<SpriteRenderer>());

                // Muestra el texto de derrota
                defeatText.gameObject.SetActive(true);

                Time.timeScale = 0;

                // Y vuelve al menú principal
                ApplicationManager.Instance.GoToPreviousScene();
            }
        }
    }
}
