using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public float JumpForce;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.RightArrow)){   
            gameObject.transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("jump")){
            rb.AddForce(transform.up * JumpForce);
        }
    }

    // void OnCollisionStay2D(Collision2D other) {
    //     Debug.Log("停留 "+other.gameObject.name);    
    // }

    // void OnCollisionExit2D(Collision2D other) {
    //     Debug.Log("離開 "+other.gameObject.name);
    // }
}



