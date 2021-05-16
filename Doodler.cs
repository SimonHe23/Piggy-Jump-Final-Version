using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Doodler : MonoBehaviour
{
    public float moveSpeed;//setting a new parameter move speed
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //keep rb on pig
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");//Let go and change the value instantaneously
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);//keep velocity for position y

        if (h != 0)//if not 0
        {
            transform.localScale = new Vector3(-h, 1, 1);//could let pig to turning while you press the key Left ore Right
        }
        
    }
}
