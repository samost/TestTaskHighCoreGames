using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    
    
    public void SwapWeapon(string keyCode, ref Gun currentGun)
    {
        foreach (Transform gun in transform)
        {
            if (gun.CompareTag(keyCode))
            {
                gun.gameObject.SetActive(true);
                currentGun = gun.gameObject.GetComponent<Gun>();
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
        }
    }
}
