using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0;
    private float currently_moveSpeed = 0;
    private Animator anim;
    private Rigidbody2D rigidbody;
    private float oldDirectionX = 0;
    private float oldDirectionY = 0;

    private bool isAction = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Если движемся по диагонали то скорость движения в 2 раза меньше.
        if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Math.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            currently_moveSpeed = moveSpeed / 2.0f;
        else
            currently_moveSpeed = moveSpeed;

        //Движение по вертикали и горизонтале
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f || Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currently_moveSpeed, Input.GetAxisRaw("Vertical") * currently_moveSpeed); // Move(x,0)
            anim.SetFloat("old_MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("old_MoveY", Input.GetAxisRaw("Vertical"));

            if (oldDirectionX != Input.GetAxisRaw("Horizontal") || oldDirectionY != Input.GetAxisRaw("Vertical"))
            {
                anim.SetBool("IsMove", false);
                oldDirectionX = Input.GetAxisRaw("Horizontal");
                oldDirectionY = Input.GetAxisRaw("Vertical");
            }
            else
                anim.SetBool("IsMove", true);

            //   oldDirectionX = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            rigidbody.velocity = new Vector2(0f, 0f);
        }

        
        //Флаг определяющий движится игрок или нет
        if (Input.GetAxisRaw("Vertical") == 0.0f && Input.GetAxisRaw("Horizontal") == 0.0f)
            anim.SetBool("IsMove", false);

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}
