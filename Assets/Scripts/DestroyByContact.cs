using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null )
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Marks object to be destroyed. Destroyed at the end of the frame
        if(other.tag == "Boundary")
        {
            return;
        }
        
        Debug.Log("Destroying tag " + other.tag +" / collider "+other);
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player" || tag == "Player")
        {
            Debug.Log("Destroying If statement other.tag =" + other.tag + " / tag = " +tag);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}

