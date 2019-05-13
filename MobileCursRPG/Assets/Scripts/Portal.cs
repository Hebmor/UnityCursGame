using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int keyID = 0;
    public GameObject tp;
    public GameObject text_press;
    public GameObject text_not;
    private float delayMes = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text_press.SetActive(false);
        //text_not.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (delayMes > 0f)
        {
            delayMes -= Time.deltaTime;
        }
        else if (delayMes != -1f)
        {
            delayMes = -1f;
            text_not.SetActive(false);
        }
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
        if (Input.GetKey(KeyCode.F))
        {
            if (collision.GetComponent<PlayerController>().pickedKeys.Contains(keyID))
            {
                collision.transform.localPosition = new Vector3(tp.transform.localPosition.x, tp.transform.localPosition.y - 0.33f, tp.transform.localPosition.z - 10);
            }
            else
            {
                text_not.SetActive(true);
                delayMes = 2f;
            }
        }
    }
}
