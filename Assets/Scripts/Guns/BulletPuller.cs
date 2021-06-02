using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletPuller : MonoBehaviour
{
    public static BulletPuller Instance;

    [SerializeField] private int startCountBullet;
    [SerializeField] private GameObject bulletPrefab;

    private Bullet[] _bullets;
    private int _currentIndex = 0;
    private void Awake()
    {
        Instance = this;
        _bullets = new Bullet[startCountBullet];
    }

    private void Start()
    {
        for (int i = 0; i < startCountBullet; i++)
        {
            var o = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            o.SetActive(false);
            var b = o.GetComponent<Bullet>();
            _bullets[i] = b;
        }
    }

    public Bullet GetBullet()
    {
        if (_currentIndex + 2 == startCountBullet)
        {
            _currentIndex = 0;
        }
        
        return _bullets[_currentIndex++];
    }
}
