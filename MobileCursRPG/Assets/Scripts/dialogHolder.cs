using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogHolder : MonoBehaviour
{ 
    public string dialogue;
    private DialogueManager pDMan;
    // Start is called before the first frame update
    void Start()
    {
        pDMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                pDMan.ShowBox(dialogue);
            }
        }
    }
}
