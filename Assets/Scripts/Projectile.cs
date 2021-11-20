using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject temp = collision.gameObject;
        GameObject other = collision.otherCollider.gameObject;
        if (temp.tag == "Enemy")
        {
            Debug.Log("Enemy detected.");
            Destroy(temp);
        }

        Destroy(other);
    }
}
