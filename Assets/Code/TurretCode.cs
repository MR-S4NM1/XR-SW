using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCode : MonoBehaviour
{
    #region References

    [SerializeField] protected Transform _bulletPos;
    [SerializeField] protected Transform _turretOrigin;
    [SerializeField] protected AudioSource _audioSource;
    [SerializeField] protected Light _light;

    #endregion

    #region RuntimeMethods

    protected GameObject _bullet;

    #endregion

    #region UnityMethods

    void Start()
    {
        if (_audioSource == null)
        {
            _audioSource = GetComponent<AudioSource>();
        }
        _light.gameObject.SetActive(false);
    }

    #endregion

    #region LocalMethods

    protected virtual void Shoot()
    {
        _bullet = BulletPool.instance.GetPooledBullet();

        if (_bullet != null)
        {
            _bullet.transform.position = _bulletPos.position;
            _bullet.GetComponent<BulletCode>()._bulletDirection = 
                (_bulletPos.position - _turretOrigin.position).normalized;
            _bullet.SetActive(true);
            _audioSource.Play();
        }
    }

    protected IEnumerator ShootingCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        Shoot();
        StartCoroutine(ShootingCoroutine());
    }

    #endregion

    #region PublicMethods

    public void ShootingRoutine()
    {
        StopAllCoroutines();
        StartCoroutine(ShootingCoroutine());
        _light.gameObject.SetActive(true);
    }


    #endregion
}
