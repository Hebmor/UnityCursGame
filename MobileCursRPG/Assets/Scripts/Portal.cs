using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int keyID = 0;
    public string nextScene;
    public GameObject text_not;
    private float delayMes = 0f;
    // Start is called before the first frame update
    void Start()
    {
        text_not.SetActive(false);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.GetComponent<PlayerController>().pickedKeys.Contains(keyID))
            {
                SceneManager.LoadScene(nextScene);
            }
            else
            {
                text_not.SetActive(true);
                delayMes = 3f;
            }
        }
    }
}
