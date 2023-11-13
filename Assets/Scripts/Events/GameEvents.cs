using System;

public static class GameEvents {

    // Eventos de pausar, reanudar, derrota y victoria
    public static event Action OnPause;
    public static event Action OnResume;
    public static event Action OnGameOver;
    public static event Action OnVictory;

    // Trigger de pausa
    public static void TriggerPause() => OnPause?.Invoke();

    // Trigger de reanudar
    public static void TriggerResume() => OnResume?.Invoke();

    // Trigger de derrota
    public static void TriggerGameOver() => OnGameOver?.Invoke();

    // Trigger de victoria
    public static void TriggerVictory() => OnVictory?.Invoke();

}
