using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float projectileSpeed = 1.0f;
    public GameObject projectilePrefab;
    public GameObject player;

    private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fire());
    }

    // This is a temporary coroutine to make the enemy fire bullets
    IEnumerator fire()
    {
        while(true)
        {
            projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = new Vector3(transform.position.x, transform.position.y - 0.15f, 0);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, -1, 0) * projectileSpeed;

            yield return new WaitForSecondsRealtime(2);
        }
        
    }
}
