using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public PlayerGeneralMovement pgm;
    public Transform WallPoint1;
    public float WallPointRadius;
    public Transform WallPoint2;
    public LayerMask WhatIsWall;
    public float walldrag;
    public float launchspeed;
    public JumpManager jm;
    Collider2D lastwall;
    bool josw;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForWall();
    }

    void CheckForWall()
    {

        Collider2D detectedwall = Physics2D.OverlapCircle(WallPoint1.position, WallPointRadius, WhatIsWall);
        Collider2D detectedwall2 = Physics2D.OverlapCircle(WallPoint2.position, WallPointRadius, WhatIsWall);
        if(detectedwall != null || detectedwall2 != null)
        {
            if (josw)
            {
                if (detectedwall != lastwall && detectedwall2 != lastwall)
                {
                    jm.enabled = false;
                }
            }
            else
            {
                jm.enabled = false;
            }


            if (detectedwall != null)
            {
                lastwall = detectedwall;
                Jump(-1f);
            }
            else
            {
                lastwall = detectedwall2;
                Jump(1f);
            }

            Debug.Log("wall detected");
            GetComponent<Rigidbody2D>().drag = walldrag;
            Time.timeScale = 1;
        }
        else
        {
            GetComponent<Rigidbody2D>().drag = 0;
            jm.enabled = true;
        }
    }

    void Jump(float dir)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(dir);
            GetComponent<Rigidbody2D>().velocity = new Vector2(dir * launchspeed, launchspeed * 1.5f);
            jm.enabled = true;
        }
    }

    IEnumerator JumpOffSameWall()
    {
        josw = false;
        yield return new WaitForSeconds(0.1f);
        josw = true;
    }
}
