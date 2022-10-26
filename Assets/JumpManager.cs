using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    public float upgravity;
    public float downgravity;
    public PlayerGeneralJump pgj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = upgravity;
        }else if(GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = downgravity;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pgj.JumpReg();
        }
    }
}
