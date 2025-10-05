using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody rigidbody;

    float minSpeed = 12;
    float maxSpeed = 16;
    float maxTorque = 10;
    float xRange = 4;
    float ySpawn = -3;

    [Header("Score Value")]
    [SerializeField] int pointValue;
    GameManager gameManager;


    [Header("Particle")]
    [SerializeField] ParticleSystem explosionParticle;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Move();
    }

    private void Move()
    {
        rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawn();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawn);
    }


    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Good"))
        {
            gameManager.live--;
            gameManager.liveText.text = "Lives: " + gameManager.live;
            gameManager.GameOver();
        }
        
    }
}
