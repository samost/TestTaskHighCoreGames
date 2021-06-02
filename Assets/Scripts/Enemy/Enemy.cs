using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IVulnerable
{
    private Transform _target;
    [SerializeField] private int health;
    
    [SerializeField] private Gun gun;

    [SerializeField] private float shootDelay;

    private void Start()
    {
        _target = FindObjectOfType<Player>().transform;
        StartCoroutine(Shooting());
    }

    private void Update()
    {
        transform.LookAt(_target);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            gun.Shoot();
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
