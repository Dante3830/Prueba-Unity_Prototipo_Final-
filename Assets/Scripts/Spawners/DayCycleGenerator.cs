using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleGenerator : MonoBehaviour {

    // Referencia a la cámara
    [SerializeField] public Camera _camera;

    // Color de la noche (Ajustable)
    [SerializeField] public Color NightColor;

    // Duración del día (Ajustable)
    [SerializeField] [Range(4, 128)] public int DayDuration;

    // Cantidad de días (Ajustable)
    [SerializeField] [Range(4, 24)] public int Days;

    // Color de la cámara
    private Color DayColor;

    // Inicializa la rutina con el color de día
    void Start() {
        DayColor = _camera.backgroundColor;
        StartCoroutine(ChangeColor(DayDuration));
    }
    
    // Cambia el color del día dependiendo de cuántos segundos pasen 
    IEnumerator ChangeColor(float time) {
        // Color del fondo de la cámara
        Color ColorDestinyBackground = _camera.backgroundColor == DayColor ? NightColor : DayColor;

        // Duración del ciclo
        float CycleDuration = time * 0.6f;

        // Cambiar duración del día
        float ChangeDuration = time * 0.4f;

        // Proceso de la transición de colores por la cantidad de días ajustada
        for (int i = 0; i < Days; i++) {
            yield return new WaitForSeconds(DayDuration);

            float ElapsedTime = 0f;

            while (ElapsedTime < ChangeDuration) {
                ElapsedTime += Time.deltaTime;
                float t = ElapsedTime / ChangeDuration;

                float smoothT = Mathf.SmoothStep(0f, 1f, t);

                _camera.backgroundColor = Color.Lerp(_camera.backgroundColor, ColorDestinyBackground, smoothT);

                yield return null;
            }

            ColorDestinyBackground = _camera.backgroundColor == DayColor ? NightColor : DayColor;
        }
    }
}
