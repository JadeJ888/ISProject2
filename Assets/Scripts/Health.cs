using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 10;
    public AudioClip death;
    private AudioSource aud;
    private int numberParts;
    float timer = 0;
    
    [Tooltip("Check this box if this object is just an object, not an enemy")]
    public bool isObject = false;

    void Start() {
        aud = this.gameObject.GetComponent<AudioSource>();
        aud.spatialBlend = 1;  //make audio 3d instead of 2d
        numberParts = Random.Range(1, 10);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            //health -= 2;

            // Debug.Log("Magnitude: " + other.relativeVelocity.magnitude);

            // health -= (int)(other.relativeVelocity.magnitude * 0.03f);

            health -= other.gameObject.GetComponent<Bullet>().damage;


            if (health <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        if(isObject)
        {
            Destroy(this.GetComponent<Collider>());
            Destroy(this.GetComponent<Renderer>());
            for(int i = 0; i < numberParts; i++)
            {
                GameObject part = GameObject.CreatePrimitive(PrimitiveType.Cube);
                part.transform.localScale = Vector3.one * Random.Range(0.5f, 0.8f);
                part.transform.position = this.transform.position;
                part.transform.Translate(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
                part.transform.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                part.AddComponent<Rigidbody>();
            }
            Destroy(this.gameObject, 1);
            aud.PlayOneShot(death);
        } else
        {
            this.gameObject.AddComponent<Rigidbody>();
            //trying to make enemy smaller over 3-4 seconds
            //ask teacher later
            this.gameObject.transform.localScale -= new Vector3(-.1f, -.1f, -.1f) * Time.deltaTime;
            Debug.Log(this.transform.localScale);
            Destroy(this.gameObject, 5);
        }
    }

}
