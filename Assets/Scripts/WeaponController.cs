using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float projectileSpeed = 2.0f;
    public GameObject projectilePrefab;

    private GameObject projectile;
    private Rigidbody2D rb;

    private void Start()
    {
        
    }

    private void Update()
    {
        // Left mouse click to fire weapon
        if (Input.GetMouseButtonUp(0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = new Vector3(transform.position.x, transform.position.y + 0.15f, 0);

        rb = projectile.GetComponent<Rigidbody2D>();

        Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float moveX = worldpos.x - transform.position.x;
        float moveY = worldpos.y - transform.position.y;

        rb.velocity = new Vector3(moveX, moveY, 0) * projectileSpeed;
    }
}
