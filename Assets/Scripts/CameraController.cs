// This script was created by Epitome on YouTube (https://www.youtube.com/channel/UCsaXQNLxeHvwJdDUrICGufA)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY = 0.05f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        // This is to check if we're within the bounds on the x-axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX) // If true, means the player is trying to go out of bounds
        {
            // If the center of the camera is smaller than the lookAt, then the player is on the right and the focus of the camera is on the left, so we add to delta
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        // This is to check if we're within the bounds on the y-axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY) // If true, means the player is trying to go out of bounds
        {
            // If the center of the camera is smaller than the lookAt, then the player is on the right and the focus of the camera is on the left, so we add to delta
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);
    }
}
