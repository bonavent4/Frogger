using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField] TreeMovement astroidClump;
    public void Shatter()
    {
        astroidClump.isDeadly = true;
    }
    public void UnShatter()
    {
        astroidClump.isDeadly = false;
    }

}
