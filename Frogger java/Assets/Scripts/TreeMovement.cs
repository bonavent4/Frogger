using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    void Update()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
