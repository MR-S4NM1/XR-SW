using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsaberCode : MonoBehaviour
{
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected ParticleSystem _particleSystem;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected AudioClip _hitClip;
    [SerializeField] protected AudioClip _swingClip;

    private void FixedUpdate()
    {
        if(_rb.velocity.magnitude >= 0.5f)
        {
            _audioSource.PlayOneShot(_swingClip);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _particleSystem.Play();
            _audioSource.PlayOneShot(_hitClip);
        }
    }
}
