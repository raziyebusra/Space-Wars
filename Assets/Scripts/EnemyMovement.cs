using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float inputDelay = 0.5f;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    public bool missedEnemy = false;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        else if (other.CompareTag("BottomBorder"))
        {
            gameManager.Reducescore();
        }
    }


}

