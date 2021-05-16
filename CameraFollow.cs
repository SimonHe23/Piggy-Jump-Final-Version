using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;//New Target to Track
    public float smoothSpeed = 0.3f;//The speed of smooth movement
    Vector3 speed;

    private void LateUpdate()//Bacause this is a tracking category, so we need to use late update.
    {
        if (target.position.y > transform.position.y)//If the y-component of the target position is greater than the y-component of its own position
        {
            Vector3 targetPos = new Vector3(0f, target.position.y, -10f);//target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothSpeed * Time.deltaTime);
        }
    }
}