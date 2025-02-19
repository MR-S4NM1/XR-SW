using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    #region References

    public static BulletPool instance;
    [SerializeField] protected List<GameObject> _pooledBullets;
    [SerializeField] protected GameObject _bulletPrefab;

    #endregion

    #region Knobs

    [SerializeField] protected int _bulletsNumber;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        _pooledBullets = new List<GameObject>();

        for (int i = 0; i < _bulletsNumber; ++i)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _pooledBullets.Add(bullet);
        }
    }

    #endregion

    #region PublicMethods

    public GameObject GetPooledBullet()
    {
        for(int i = 0; i < _pooledBullets.Count; ++i)
        {
            if (!_pooledBullets[i].activeInHierarchy)
            {
                return _pooledBullets[i];
            }
        }

        return null;
    }

    #endregion
}
