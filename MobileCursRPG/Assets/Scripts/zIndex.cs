using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zIndex : MonoBehaviour
{
    public float Parallax;
    public bool isActive = false;
    public Color currentColor = new Color(220, 220, 40, 160);

    private float px = 0f;
    private float speed = 1f;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (isActive)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            Color nextColor = spriteRenderer.color;

            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                speed = -1 * Math.Abs(speed);
            }
            else if (Input.GetKeyUp(KeyCode.LeftAlt))
            {
                speed = Math.Abs(speed);
            }

            nextColor.a += speed * Time.deltaTime * (1 - currentColor.a / 255);
            nextColor.r += speed * Time.deltaTime * (1 - currentColor.r / 255);
            nextColor.g += speed * Time.deltaTime * (1 - currentColor.g / 255);
            nextColor.b += speed * Time.deltaTime * (1 - currentColor.b / 255);
            px += speed * Time.deltaTime * 0.3f;

            nextColor.a = Mathf.Clamp(nextColor.a, currentColor.a / 255, 1);
            nextColor.r = Mathf.Clamp(nextColor.r, currentColor.r / 255, 1);
            nextColor.g = Mathf.Clamp(nextColor.g, currentColor.g / 255, 1);
            nextColor.b = Mathf.Clamp(nextColor.b, currentColor.b / 255, 1);
            px = Mathf.Clamp(px, -0.333f, 0f);
            spriteRenderer.color = nextColor;
        }

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y + Parallax + px);
    }
}
