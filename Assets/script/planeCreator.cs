using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeCreator : MonoBehaviour {
    [Header("地板預置物")]
    public GameObject[] planes;

    [Header("移動速度")]
    public float speed;

    [Header("生成地板的間隔時間")]
    public float CD_time;
    
    [Header("左邊界")]
    public float L_Range;

    [Header("右邊界")]
    public float R_Range;

    [HideInInspector]
    public bool IsGoingRight;

    [HideInInspector]
    public bool CreatePlane;

    [HideInInspector]
    public float timer;
    
    
    void Start () {
        
    }

    void Update () {
        Movement();

        if(CreatePlane == true){
            Instantiate(planes[Random.Range(0,3)],transform.position,Quaternion.identity);
            CreatePlane = false;
        }

        // 計時器 timer

        // 計時器 時間到了->生成一個地板 -> 重新計時
        timer = timer + Time.deltaTime;

        if(timer >= CD_time){
            CreatePlane = true;
            timer = 0;
        }

        
        //timer += Time.deltaTime;
    }

    void Movement(){
        // 當超過右邊界的時候
        if(transform.position.x >= R_Range) IsGoingRight = false;

        // 當超過左邊界的時候
        if(transform.position.x <= L_Range) IsGoingRight = true;

        if(IsGoingRight == true){
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }else{
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }

        // transform.Translate(Vector2.right * Time.deltaTime * speed);
        // transform.Translate(Vector2.left * Time.deltaTime * speed);

        // 左邊界0 右邊界6.2
    }
}