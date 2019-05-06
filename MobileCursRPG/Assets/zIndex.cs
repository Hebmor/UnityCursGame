using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zIndex : MonoBehaviour
{
    public float Parallax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.y + Parallax);
    }
}
