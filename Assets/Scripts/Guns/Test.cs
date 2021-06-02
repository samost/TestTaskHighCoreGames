using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            var o = gameObject.GetComponent<Rigidbody>();
            o.useGravity = true;
            o.AddForce(Vector3.forward * 5f, ForceMode.Impulse);
        }
    }
}
