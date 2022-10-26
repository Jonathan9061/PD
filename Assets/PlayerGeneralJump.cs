using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralJump : MonoBehaviour
{
    public float speedmult;
    public float JumpHeight;
    public PlayerGeneralMovement pgm;
    public void JumpReg()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) * speedmult * pgm.IsMoving, JumpHeight);
    }
}
