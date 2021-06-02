using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    [SerializeField] private Transform bulletSpawnPoint2;
    public override void Shoot()
    {
        if (Time.time > NextShootTime && !IsReload)
        {

            NextShootTime = Time.time + 1f / rateOfFire;
            var bullet1 = BulletPuller.Instance.GetBullet();
            var bullet2 = BulletPuller.Instance.GetBullet();
            bullet1.bulletDamage = damage;
            bullet2.bulletDamage = damage;
            
            bullet1.gameObject.SetActive(true);
            bullet2.gameObject.SetActive(true);
            
            bullet1.transform.position = bulletSpawnPoint.position;
            bullet2.transform.position = bulletSpawnPoint.position;
            
            bullet1.rigidbody.useGravity = true;
            bullet2.rigidbody.useGravity = true;
            
            bullet1.rigidbody.AddForce(bulletSpawnPoint.forward * rageOfFire, ForceMode.Impulse);
            bullet2.rigidbody.AddForce(bulletSpawnPoint2.forward * rageOfFire, ForceMode.Impulse);

            Clip-=2;
            if (transform.parent.transform.parent.CompareTag("MainCamera")) // this for check who shootning player or enemy, sorry))))))
            {
                clipUI.text = Clip.ToString();
            }
            
            StartCoroutine(CheckReload());
        }
        
        
    }

    public override IEnumerator CheckReload()
    {
        if (Clip <= 0)
        {
            IsReload = true;
            Clip = countBullet;
            yield return new WaitForSeconds(timeReload);
            IsReload = false;
            if (transform.parent.transform.parent.CompareTag("MainCamera"))
            {
                clipUI.text = Clip.ToString();
            }
        }
    }
}
