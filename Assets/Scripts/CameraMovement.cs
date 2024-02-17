using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed = 10f;

    void Update()
    {
        if (target != null)
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        //transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
    }
}
