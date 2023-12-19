using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource destroySound;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //  deactivate the projectile and destroy the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            destroySound.Play();
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            gameManager.Updatescore();
        }
    }


}
