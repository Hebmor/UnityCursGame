using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyKeeper : MonoBehaviour
{
    public int keyID = 0;
    public GameObject text_take;
    private bool isTook = false;
    private float delayMes = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text_take.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (delayMes > 0f)
        {
            delayMes -= Time.deltaTime;
        }
        else if(delayMes != -1f)
        {
            delayMes = -1f;
            text_take.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && !isTook)
        {
            collision.GetComponent<PlayerController>().pickedKeys.Add(keyID);
            text_take.SetActive(true);
            isTook = true;
            delayMes = 2f;
        }
    }
}
