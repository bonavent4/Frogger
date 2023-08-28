using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [SerializeField]float jumpDistance;
    [SerializeField] float JumpSpeed;

    [SerializeField] Vector3 target;

    [SerializeField]bool move;
    bool onObject;

    float highScore;

    FrogPoints frogP;

    GameObject Tree;

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
           // Debug.Log("Moving");

        }
        else
        {
            move = false;
            if(gameObject.transform.position.y > highScore)
            {
                frogP.MovePoints();
                highScore = gameObject.transform.position.y;
            }
            if (onObject == true)
            {
                gameObject.transform.parent = Tree.transform;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TreeMovement>())
        {
            //gameObject.transform.parent = collision.gameObject.transform;
            Tree = collision.gameObject;
            onObject = true;

           // Debug.Log("Hit");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<TreeMovement>())
        {
            //gameObject.transform.parent = collision.gameObject.transform;
            gameObject.transform.parent = null;
            onObject = false;
            Debug.Log("Hit");
        }
    }

}
