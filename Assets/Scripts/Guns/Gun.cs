using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected float rateOfFire;
    [SerializeField] protected float timeReload;
    [SerializeField] protected float rageOfFire;
    
    [SerializeField] protected int damage;
    [SerializeField] protected int countBullet;

    [SerializeField] protected Transform bulletSpawnPoint;

    [SerializeField] protected Text clipUI;

    protected int Clip;

    protected float NextShootTime;
    protected bool IsReload = false;

    private void Start()
    {
        Clip = countBullet;
        clipUI.text = Clip.ToString();
    }

    public abstract void Shoot();
    public abstract IEnumerator CheckReload();

    private void OnDisable()
    {
        Clip = countBullet;
        IsReload = false;
    }
}
