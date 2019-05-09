using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0;

    private float currently_moveSpeed = 0;
    private Animator anim;
    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        float axisVerical = Input.GetAxisRaw("Vertical");

        //Если движемся по диагонали то скорость движения в 2 раза меньше.
        if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Math.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            currently_moveSpeed = moveSpeed / (float) Math.Sqrt(2);
        else
            currently_moveSpeed = moveSpeed;

        //Движение по вертикали или горизонтале
        if (axisHorizontal > 0.5f || axisHorizontal < -0.5f)
        {
            if (axisHorizontal > 0.5f) //right
            {
                boxCollider.size = new Vector2(0.2115935f, 0.1778115f);
                boxCollider.offset = new Vector2(-0.004913501f, -0.2115334f);
            }
            else //left
            {
                boxCollider.size = new Vector2(0.2115935f, 0.1778115f);
                boxCollider.offset = new Vector2(0.004913501f, -0.2115334f);
            }

            rigidBody.velocity = new Vector2(axisHorizontal * currently_moveSpeed, rigidBody.velocity.y); // Move(x,0)
            anim.SetFloat("old_MoveX", axisHorizontal);
            anim.SetBool("IsMove", true);
        }
        else
        {
            rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
        }

        if (axisVerical > 0.5f || axisVerical < -0.5f)
        {
            boxCollider.size = new Vector2(0.300496f, 0.1778115f);
            boxCollider.offset = new Vector2(-0.0002823472f, -0.2115334f);

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, axisVerical * currently_moveSpeed); // Move(0,y)
            anim.SetFloat("old_MoveY", axisVerical);
            anim.SetBool("IsMove", true);
        }
        else
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
        }
        //Флаг определяющий движится игрок или нет
        if (axisVerical == 0.0f && axisHorizontal == 0.0f)
            anim.SetBool("IsMove", false);

        anim.SetFloat("MoveX", axisHorizontal);
        anim.SetFloat("MoveY", axisVerical);
    }
}
