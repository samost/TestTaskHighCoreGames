using System.Collections;
using UnityEngine;

public class AK : Gun
{
    public override void Shoot()
    {
        if (Time.time > NextShootTime && !IsReload)
        {

            NextShootTime = Time.time + 1f / rateOfFire;
            var bullet = BulletPuller.Instance.GetBullet();
            
            bullet.bulletDamage = damage;
            bullet.gameObject.SetActive(true);
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.rigidbody.useGravity = true;
            bullet.rigidbody.AddForce(bulletSpawnPoint.forward * rageOfFire, ForceMode.Impulse);

            Clip--;
            if (transform.parent.transform.parent.CompareTag("MainCamera"))
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
