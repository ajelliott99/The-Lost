using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject player;
    public float EnemyProjDamage = 10f;
    public float PlayerProjDamage = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), gameObject.GetComponent<BoxCollider2D>());
        StartCoroutine(destroyProjectile());
    }

    void Update()
    {
        
    }

    // Detects when the projectile makes a collision. If it hits an enemy and originates from player it damages enemy, if it hits player and originates from enemy then it damages player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        GameObject projectile = collision.otherCollider.gameObject;

        // First thing we do when a collision occurs is set velocity to 0 to stop any weird sliding/movements
        if (other.tag != "Player")
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        

       
        if (other.tag == "Enemy" && projectile.tag == "PlayerProjectile")
        {
            Debug.Log("Enemy detected.");
            Destroy(projectile);

            other.GetComponent<EnemyController>().TakeDamage(PlayerProjDamage);
        }
        else if(other.tag == "Player" && projectile.tag == "EnemyProjectile")
        {
            Debug.Log("Player detected.");
            Destroy(projectile);

            other.GetComponent<PlayerController>().TakeDamage(EnemyProjDamage);
        }
    }

    // Coroutine for deleting projectile if no collision within 3 seconds
    IEnumerator destroyProjectile()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
    }
}
