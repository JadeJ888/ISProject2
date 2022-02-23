using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody bulletPrefab;

    public bool debug = false; //set true to display debug msgs

    public void Fire() {
        if(debug) Debug.Log("Pow!");
        // create a copy of the bullet prefab
        Rigidbody bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // move the bullet in front of the gun
        bullet.transform.Translate(0,0,1);
        // add forward force to the gun
        bullet.AddRelativeForce(Vector3.forward * 20, ForceMode.Impulse);
    }
}
