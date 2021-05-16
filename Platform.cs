using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatformType platformType;//announce for a variable: platform type
    public float bounceSpeed = 4f;//variable bounce speed

    private void OnCollisionEnter2D(Collision2D collision)//working on the collisionEnter 2D
    {
        if (collision.contacts[0].normal == Vector2.down) //if going down, if pig is touching the left/right edge of the platform, is is better not to count
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null) //if get rb on body
            {
                rb.velocity = Vector2.up * bounceSpeed; //give a vector upword
            }

            //Weak Platform
            if (platformType == PlatformType.weak)
            {
                if (GetComponent<Animator>() != null)//if touch the trigger
                {
                    GetComponent<Animator>().SetTrigger("Trigger");//play the animation
                    Invoke("HideGameObject", 0.4f);//destory the platform
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCamera"))//the trigger in the main camera
        {
            gameObject.SetActive(false);//hide game object
        }
    }

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }

    public enum PlatformType //Add a Type
    {
        normal, weak//normal and weak
    }

}
