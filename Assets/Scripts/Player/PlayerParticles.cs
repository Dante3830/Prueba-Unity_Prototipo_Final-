using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interfaz de la clase
public interface IParticles {
    void PlayParticles();
}

public class PlayerParticles : MonoBehaviour, IParticles {
    // Referencia al Particle System
    public ParticleSystem _particles;

    // Ejecuta las partículas
    public void PlayParticles() {
        _particles.Play();
    }
}
