using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IVulnerable
{
    public Gun gun;
    public int health = 1000;

    [SerializeField] private WeaponHolder _weaponHolder;
    [SerializeField] private Text _helthUI;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
        }
        
        SelectGun();
    }

    private void SelectGun()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _weaponHolder.SwapWeapon("1", ref gun);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _weaponHolder.SwapWeapon("2",ref gun);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _weaponHolder.SwapWeapon("3",ref gun);
        }
        
    }

    private void Start()
    {
        _helthUI.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        _helthUI.text = health.ToString();
    }
}
