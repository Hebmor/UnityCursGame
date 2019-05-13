using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject tp;
    public GameObject text_press;

    // Start is called before the first frame update
    void Start()
    {
        text_press.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //button.enable
        text_press.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //button.disable
        text_press.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            collision.transform.localPosition = new Vector3(tp.transform.localPosition.x, tp.transform.localPosition.y - 0.33f, tp.transform.localPosition.z - 10);
        }
    }
}
