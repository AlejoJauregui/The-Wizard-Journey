using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody2D npcRigidBody; 
    public bool isWalking, isTalking;

    public float walkTime;
    private float walkCounter;

    public float waitTime;
    float waitCounter; 

    int currentDirection;

    DialogManager manager;

    private Vector2 [] walkingDirection =
    {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };

    public BoxCollider2D movementZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();
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
        if(!manager.dialogActive)
        {
            isTalking = false;
        }
        if(isTalking)
        {
            StopWalking();
            return;
        }
        if(isWalking)
        {
            if(movementZone != null)
            {
                if(this.transform.position.x < movementZone.bounds.min.x || this.transform.position.x > movementZone.bounds.max.x || 
                this.transform.position.y < movementZone.bounds.min.y || this.transform.position.y > movementZone.bounds.max.y)
                {
                    StopWalking();
                }
            }


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
