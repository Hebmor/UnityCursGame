using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;
    // Start is called before the first frame update
    void Start()
    {
        dBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
        }
    }
    public void ShowBox(string dialogue)
    {
        dialogueActive = false;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
}
