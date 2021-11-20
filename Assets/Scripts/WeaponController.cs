using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float projectileSpeed = 2.0f;
    public GameObject projectilePrefab;

    private GameObject projectile;

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
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 1, 0) * projectileSpeed;
    }
}
