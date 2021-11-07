using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 move;
    private float deltaX;
    private float deltaY;

    private void Update()
    {
        deltaX = Input.GetAxisRaw("Horizontal");
        deltaY = Input.GetAxisRaw("Vertical");

        move = new Vector3(deltaX, deltaY, 0);

        transform.Translate(move * Time.deltaTime);

    }
}
