using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float EnemyProjDamage = 10f;
    public float PlayerProjDamage = 10f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        GameObject projectile = collision.otherCollider.gameObject;
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy detected.");
            Destroy(projectile);
        }else if(other.tag == "Player" && projectile.tag == "EnemyProjectile")
        {
            Debug.Log("Player detected.");
            Destroy(projectile);

            other.GetComponent<PlayerController>().TakeDamage(EnemyProjDamage);
        }

        
    }
}
