using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public float speed;
    void Start()
    {
        Destroy(this.gameObject,5.0f);
    }

    void Update()
    {
        this.gameObject.transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
