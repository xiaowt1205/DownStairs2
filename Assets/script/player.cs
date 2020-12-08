using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;

    public float JumpForce;

    public int HP;

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

        if (other.gameObject.CompareTag("flip"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        if (other.gameObject.CompareTag("hurt"))
        {
            if (HP > 0)
            {
                Debug.Log(HP);
            }
            HP -=8;
            if (HP <= 0)
            {
                Debug.Log("死了哀哀哀");
            }
            else
            {
                Debug.Log("活著");
            }
        }
        else
        {
            if (HP < 12)
            {
                HP += 1;
            }
        }
        if (other.gameObject.CompareTag("deadzone"))
        {
            HP = 0;
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Debug.Log("碰到地板死亡");
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("conveyor_right"))
        {
            this.gameObject.transform.Translate(Vector2.right * Time.deltaTime);
        }
        if (other.gameObject.CompareTag("conveyor_left"))
        {
            this.gameObject.transform.Translate(Vector2.left * Time.deltaTime);
        }

        //Debug.Log("停留 " + other.gameObject.name);
    }

    // void OnCollisionExit2D(Collision2D other) {
    //     Debug.Log("離開 "+other.gameObject.name);
    // }
}



