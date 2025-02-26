using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    #region References

    [SerializeField] protected Rigidbody _rb;

    #endregion

    #region Knobs

    [SerializeField] protected float _bulletSpeed;

    #endregion

    #region RuntimeVariables

    public Vector3 _bulletDirection;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }
    }

    private void FixedUpdate()
    {
        _rb.velocity = _bulletDirection * _bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lightsaber"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall") ||
            other.gameObject.CompareTag("Lightsaber"))
        {
            gameObject.SetActive(false);
        }
    }

    #endregion
}
