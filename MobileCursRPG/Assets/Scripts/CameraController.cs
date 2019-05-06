using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject followTarget; //Отслеживаемый камерой объект
    private Vector3 targetPos;  
    public float camera_moveSpeed; // > 0 тогда будет двигаться
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Получаем координаты объекта который отслеживает камера и присваемаем эти координаты камере
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,targetPos, camera_moveSpeed * Time.deltaTime);
    }
}
