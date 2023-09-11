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
    bool losingLife;
    bool reachedEndPoint;

    [SerializeField] float highScore;
    [SerializeField] float minimumDeathZone;
    [SerializeField] float maximumDeathZone;

    FrogPoints frogP;
    FrogHealth frogH;

    GameObject Tree;
    [SerializeField]Transform start;

    EndPoints endpoint;

    private void Start()
    {
        target = gameObject.transform.position;
        highScore = gameObject.transform.position.y;
        frogP = FindObjectOfType<FrogPoints>();
        frogH = gameObject.GetComponent<FrogHealth>();
    }
    private void Update()
    {
        Move();
    }
   
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.D) && move == false)
        {
            target =  new Vector3(jumpDistance + gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -90));
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && move == false)
        {
            target =  new Vector3(-jumpDistance + gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 90));
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && move == false)
        {
            target =  new Vector3(gameObject.transform.position.x, -jumpDistance + gameObject.transform.position.y, gameObject.transform.position.z);
            
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 180));
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && move == false)
        {
            target =  new Vector3(gameObject.transform.position.x, jumpDistance + gameObject.transform.position.y, gameObject.transform.position.z);
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
            move = true;
        }

        if (move == true && gameObject.transform.position != target)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, JumpSpeed * Time.deltaTime);
            // Debug.Log("Moving");
            gameObject.transform.parent = null;
        }
        else
        {
            move = false;
            
            if(gameObject.transform.position.y > highScore && !losingLife)
            {
                frogP.MovePoints(10);
                highScore = gameObject.transform.position.y;
            }
            if (onObject == true && !losingLife)
            {
                gameObject.transform.parent = Tree.transform;
            }
            if (losingLife)// || (gameObject.transform.position.y > minimumDeathZone && gameObject.transform.position.y < maximumDeathZone && !onObject) && !reachedEndPoint)
            {
                frogH.LoseHealth();
                gameObject.transform.position = new Vector3(start.transform.position.x, start.transform.position.y, 0);
                losingLife = false;
                highScore = gameObject.transform.position.y;
            }
            if (reachedEndPoint && endpoint.faceHugger.activeSelf != true)
            {
                endpoint.faceHugger.SetActive(true);
                gameObject.transform.position = new Vector3(start.transform.position.x, start.transform.position.y, 0);
                highScore = gameObject.transform.position.y;

                frogP.MovePoints(500);

                if (endpoint.hasMosquito)
                {
                    frogP.MovePoints(200);
                }


                gameObject.transform.parent = null;
                onObject = false;
                reachedEndPoint = false;
            }
           /* else if (reachedEndPoint)
            {
                losingLife = true;
                reachedEndPoint = false;
            }*/

        
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TreeMovement>() && collision.gameObject.tag == "Tree")
        {
            //gameObject.transform.parent = collision.gameObject.transform;
            Tree = collision.gameObject;
            onObject = true;

           // Debug.Log("Hit");
        }
        else if(collision.GetComponent<TreeMovement>() && collision.gameObject.tag == "Car")
        {
            losingLife = true;
        }
        if (collision.GetComponent<EndPoints>())
        {
            endpoint = collision.gameObject.GetComponent<EndPoints>();

            reachedEndPoint = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<TreeMovement>() && collision.gameObject == Tree)
        {
            //gameObject.transform.parent = collision.gameObject.transform;
            gameObject.transform.parent = null;
            onObject = false;
           // Tree = null;
            Debug.Log("Hit");
        }
    }

}
