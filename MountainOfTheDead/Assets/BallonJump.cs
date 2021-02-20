using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonJump : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }
    }
}
