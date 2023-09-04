using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FrogPoints : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI pointsUI;
    int points;


    public void MovePoints()
    {
        points++;
        pointsUI.text = "Score: " + points.ToString();
    }
}
