using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBoundary
{
    public float xMin, xMax, zMin, zMax;
}


public class EnemyController : MonoBehaviour
{

    public float speed;
    public float tilt;
    public EnemyBoundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public Rigidbody rb;

    public float fireRate;

    private float nextFire;

    void Start()
    {
            rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * speed;        
    }

    //unity will execute this code just before updating the every frame
    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();

        }
    }

}


