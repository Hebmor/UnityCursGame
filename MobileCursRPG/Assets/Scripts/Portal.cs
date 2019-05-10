using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject tp;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            collision.transform.localPosition = new Vector3(tp.transform.localPosition.x, tp.transform.localPosition.y - 0.33f, tp.transform.localPosition.z - 10);
        }
    }
}
