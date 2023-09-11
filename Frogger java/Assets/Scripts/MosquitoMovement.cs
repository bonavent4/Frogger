using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMovement : MonoBehaviour
{
    [SerializeField]GameObject[] endPoints;

    [SerializeField] float maxTime;
    float timer;

    int someNumber;
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            endPoints[someNumber].GetComponent<EndPoints>().hasMosquito = false;
            someNumber = Random.Range(0, 4);
            gameObject.transform.position = endPoints[someNumber].transform.position;
            timer = 0;

            endPoints[someNumber].GetComponent<EndPoints>().hasMosquito = true;
        }
    }
}
