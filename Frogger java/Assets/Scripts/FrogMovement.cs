using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField]float jumpDistance;
    [SerializeField] float JumpSpeed;

    [SerializeField] Vector3 target;

    bool move;

    float highScore;

    FrogPoints frogP;

    private void Start()
    {
        target = gameObject.transform.position;
        highScore = gameObject.transform.position.y;
        frogP = FindObjectOfType<FrogPoints>();
    }
    private void Update()
    {
        Move();

        
    }
   
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.D) && move == false)
        {
            target = target += new Vector3(jumpDistance, 0, 0);
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && move == false)
        {
            target = target += new Vector3(-jumpDistance, 0, 0);
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && move == false)
        {
            target = target += new Vector3(0, -jumpDistance, 0);
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && move == false)
        {
            target = target += new Vector3(0, jumpDistance, 0);
            move = true;
        }

        if (move == true && gameObject.transform.position != target)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, JumpSpeed * Time.deltaTime);
            

        }
        else
        {
            move = false;
            if(gameObject.transform.position.y > highScore)
            {
                frogP.MovePoints();
                highScore = gameObject.transform.position.y;
            }
        }
    }

}
