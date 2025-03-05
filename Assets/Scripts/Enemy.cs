using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
  public int points = 10;

  public float speed = 1f;
  private float currentSpeed; // Current speed of the enemies
  private Vector3 direction = Vector3.right; 

  public GameObject bullet;

  public Transform shottingOffset;
  public float shootingInterval = 2f; 
  public float bulletSpeed = 5f; 

  private float shootingTimer = 0f;
  public delegate void EnemyDied(int pointWorth);
  public static event EnemyDied OnEnemyDied;

  public AudioClip enemydeathsound;

  public AudioClip enemyShootSound;

  private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentSpeed = speed;
    }
    void Update()
    {
        // Move the enemy horizontally
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the enemy reaches the screen edges
        if (transform.position.x <= -5f || transform.position.x >= 5f)
        {
            // Change the direction when reaching the edges
            direction = -direction;
            // Move the enemy down
            transform.Translate(Vector3.down * 0.5f);
        }

        // Update shooting timer
        shootingTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootingTimer >= shootingInterval)
        {
            // Reset shooting timer
            shootingTimer = 0f;

            // Shoot a bullet
            Shoot();
        }
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      GetComponent<Animator>().SetTrigger("Die");
      audioSource.PlayOneShot(enemydeathsound);
      // Debug.Log("Ouch!");
      Destroy(collision.gameObject);

      OnEnemyDied.Invoke(points);

      IncreaseSpeed();
    }
    void DeathAnimationComplete()
    {
      Debug.Log("enemy died");
      
      Destroy(gameObject);
    }

    void Shoot()
    {
        // Instantiate a bullet at the position of the enemy
        audioSource.PlayOneShot(enemyShootSound);
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
    }

    void IncreaseSpeed()
    {
        currentSpeed += 0.1f; // Adjust the increment value as needed
    }
}
