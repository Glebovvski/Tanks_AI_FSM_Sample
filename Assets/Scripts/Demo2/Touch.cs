using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : Sense {

    private void OnTriggerEnter(Collider other)
    {
        Aspect aspect = other.GetComponent<Aspect>();
        if (aspect != null)
        {
            if (aspect.aspectName == Aspect.aspect.Enemy)
            {
                print("Enemy Touch Detected");
                Quaternion tarRot = Quaternion.LookRotation(other.GetComponent<Transform>().position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, tarRot, 2.0f * Time.deltaTime);
            }
        }
    }
}
