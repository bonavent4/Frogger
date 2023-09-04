using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrogHealth : MonoBehaviour
{
    int health = 3;

    [SerializeField] GameObject[] healthUI;

    public void LoseHealth()
    {
        health--;
        healthUI[health].SetActive(false);
    }
}
