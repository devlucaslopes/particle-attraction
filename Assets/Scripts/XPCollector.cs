using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPCollector : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private SphereCollider Collector;
    [SerializeField] private Player Player;
    
    private ParticleSystem _particleSystem;
    private List<ParticleSystem.Particle> _particles = new List<ParticleSystem.Particle>();

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.trigger.AddCollider(Collector);
    }

    private void OnParticleTrigger()
    {
        int triggeredParticles = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);

        for (int i = 0; i < triggeredParticles; i++)
        {
            ParticleSystem.Particle particle = _particles[i];
            particle.remainingLifetime = 0;

            Player.AddXP();

            _particles[i] = particle;
        }
        
        _particleSystem.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, _particles);
    }
}
