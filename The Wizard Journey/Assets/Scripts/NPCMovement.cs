using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody2D npcRigidBody; 
    public bool isWalking;

    public float walkTime;
    private float walkCounter;

    public float waitTime;
    float waitCounter; 

    int currentDirection;

    private Vector2 [] walkingDirection =
    {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };

    // Start is called before the first frame update
    void Start()
    {
        npcRigidBody = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        NPCIsWalking();
    }
    void NPCIsWalking()
    {
        if(isWalking)
        {
            npcRigidBody.velocity = walkingDirection[currentDirection] * speed;
            walkCounter -= Time.deltaTime;
            if(walkCounter < 0)
                StopWalking();
        }
        else
        {
            npcRigidBody.velocity = Vector2.zero;
            waitCounter -= Time.deltaTime;
            if(waitCounter < 0)
                StartWalking();
        }
    }
    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0,4);
        walkCounter = walkTime;
    }
    private void StopWalking()
    {
        isWalking = false;
        waitCounter = waitTime;
        npcRigidBody.velocity = Vector2.zero;
    }

}
