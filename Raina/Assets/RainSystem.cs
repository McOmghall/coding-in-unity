using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RainSystem : MonoBehaviour
{
    public new ParticleSystem particleSystem;

    void Start ()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        System.Collections.Generic.List<ParticleSystem.Particle> particles = null;
        particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, particles);

        foreach (ParticleSystem.Particle particle in particles)
        {

        }
    }
}
