using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawn;
    public Rigidbody bulletPrefab;
   
    [Range(10,100)]
    public float bulletForce = 50;

    public bool debug = false; //set true to display debug msgs
    //private variables
    public int totalAmmo = 60;
    public int clipSize = 10;
    public int clip = 0;

    public void Reload() {
        if(clip == clipSize) {                              
            if(debug) Debug.Log("Clip is already full.");
            return;
        }

        int partialClip = 0;
        if(clip > 0) partialClip = clip;    

        if(totalAmmo + clip >= clipSize) {       
            totalAmmo -= (clipSize - clip);       
            clip = clipSize;             
        } else {
            // throw the rest of the ammo into the clip
            clip = totalAmmo + clip;
            totalAmmo = 0;
        }  
    }

    public void Fire() {
        
        if(clip > 0) {
            if(debug) Debug.Log("Pow!");
            clip -= 1;
            // create a copy of the bullet prefab
            Rigidbody bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            // move the bullet in front of the gun
            bullet.transform.Translate(0,0,1);
            // add forward force to the gun
            bullet.AddRelativeForce(Vector3.forward * bulletForce, ForceMode.Impulse);
        } else {
            if(debug) Debug.Log("Out of Ammo!");
        }
    }
}
