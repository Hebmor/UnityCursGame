using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0;
    private float currently_moveSpeed = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Если движемся по диагонали то скорость движения в 2 раза меньше.
        if (Math.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Math.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            currently_moveSpeed = moveSpeed / 2.0f;
        else
            currently_moveSpeed = moveSpeed;

        //Движение по вертикали или горизонтале
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * currently_moveSpeed * Time.deltaTime, 0f, 0f)); // Translate(x,y,z)
            anim.SetFloat("old_MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetBool("IsMove", true);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * currently_moveSpeed * Time.deltaTime, 0f)); // Translate(x,y,z)
            anim.SetFloat("old_MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("IsMove", true);
        }
        //Флаг определяющий движится игрок или нет
        if (Input.GetAxisRaw("Vertical") == 0.0f && Input.GetAxisRaw("Horizontal") == 0.0f)
            anim.SetBool("IsMove", false);

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }
}
