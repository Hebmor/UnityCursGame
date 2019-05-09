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
	private float oldDirectionX = 0;
    private float oldDirectionY = 0;
	
	private bool isAction = false;
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

        //Если движемся по диагонали то скорость движения в sqrt(2) раз меньше.
        if (Math.Abs(axisHorizontal) > 0.5f && Math.Abs(axisVerical) > 0.5f)
            currently_moveSpeed = moveSpeed / (float) Math.Sqrt(2);
        else
            currently_moveSpeed = moveSpeed;
		
		//Движение по вертикали или горизонтале
		if (axisHorizontal > 0.5f || axisHorizontal < -0.5f || axisVerical > 0.5f || axisVerical < -0.5f)
        {
			if (axisHorizontal > 0.5f) //right
            {
                boxCollider.size = new Vector2(0.2115935f, 0.1778115f);
                boxCollider.offset = new Vector2(-0.004913501f, -0.2115334f);
            }
            else if (axisHorizontal < -0.5f) //left
            {
                boxCollider.size = new Vector2(0.2115935f, 0.1778115f);
                boxCollider.offset = new Vector2(0.004913501f, -0.2115334f);
            }
			else
			{
				boxCollider.size = new Vector2(0.300496f, 0.1778115f);
				boxCollider.offset = new Vector2(-0.0002823472f, -0.2115334f);
			}
			
			rigidBody.velocity = new Vector2(axisHorizontal * currently_moveSpeed, axisVerical * currently_moveSpeed); // Move(x,y)
			anim.SetFloat("old_MoveX", axisHorizontal);
			anim.SetFloat("old_MoveY", axisVerical);

            if (oldDirectionX != axisHorizontal || oldDirectionY != axisVerical)
            {
                anim.SetBool("IsMove", false);
                oldDirectionX = axisHorizontal;
                oldDirectionY = axisVerical;
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
        if (axisVerical == 0.0f && axisHorizontal == 0.0f)
            anim.SetBool("IsMove", false);

        anim.SetFloat("MoveX", axisHorizontal);
        anim.SetFloat("MoveY", axisVerical);
    }
}
