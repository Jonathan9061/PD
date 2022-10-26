using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralMovement : MonoBehaviour
{
    public float AccelerationCoeficcient;
    public float MaxSpeed;
    public float drag;
    public float prevmovingval;
    bool executedrag = true;
    public float IsMoving;
    public bool onground;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsMoving = Input.GetAxisRaw("Horizontal");
        Move(IsMoving);
        if (onground)
        {

            Drag(IsMoving);
        }
        Freeze(IsMoving);



        //Debuglog();
    }

    void Move(float IM)
    {
        if (IM > 0 && GetComponent<Rigidbody2D>().velocity.x < MaxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * AccelerationCoeficcient / 10);
            prevmovingval = IM;
        }
        else if (IM < 0 && GetComponent<Rigidbody2D>().velocity.x > -MaxSpeed)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.right * AccelerationCoeficcient / 10);
            prevmovingval = IM;
        }
    }

    void Drag(float IM)
    {
        if (IM == 0)
        {
            Debug.Log("Stopped Input");

            if (GetComponent<Rigidbody2D>().velocity.x * prevmovingval >= 0.01f * prevmovingval)
            {
                Debug.Log("Above Speed");
                if (executedrag)
                    GetComponent<Rigidbody2D>().AddForce(transform.right * -prevmovingval * drag);
            }

        }
    }

    void Freeze(float IM)
    {
        if (IM == 0 && Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) < 0.01f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0f, GetComponent<Rigidbody2D>().velocity.y);
            executedrag = false;
        }
        else
        {
            executedrag = true;
        }
    }



    void Debuglog()
    {
        Debug.Log("Drag Activated");
    }
}
