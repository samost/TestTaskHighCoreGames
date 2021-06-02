using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]public Rigidbody rigidbody;
    [HideInInspector]public int bulletDamage;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }

    private IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<IVulnerable>().TakeDamage(bulletDamage);
        }
    }
}
