using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField]float LeftPoint;
    [SerializeField]float RightPoint;
    //[SerializeField]bool isGoingLeft;

    
    public bool isDeadly;

    
    void Update()
    {
        if(gameObject.transform.position.x <= LeftPoint && speed < 0)
        {
            gameObject.transform.position = new Vector3(RightPoint, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        if (gameObject.transform.position.x >= RightPoint && speed > 0)
        {
            gameObject.transform.position = new Vector3(LeftPoint, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        
    }
}
