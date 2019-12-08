using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float enemySpeed = 1;
    Rigidbody2D enemyRigidBody;
    bool isMoving;

    public float timeBetweenSteps;
    float timeBetweenStepsCounter;

    public float timeToMakeStep;
    float  timeToMakeStepCounter;

    public Vector2 dicrectionToMakeStep;
    Animator enemyAnimator; 
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();

        timeBetweenStepsCounter = timeBetweenSteps * Random.Range(0.5f,1.5f);
        timeToMakeStepCounter = timeToMakeStep * Random.Range(0.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheEnemy();
    }

    void MoveTheEnemy()
    {
        if(isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRigidBody.velocity = dicrectionToMakeStep;
            if(timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timeBetweenStepsCounter = timeBetweenSteps;
                enemyRigidBody.velocity = Vector2.zero; 
            }
        }
        else
        {
            timeBetweenStepsCounter -= Time.deltaTime;
            if(timeBetweenStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                dicrectionToMakeStep = new Vector2(Random.Range(-1,2),Random.Range(-1,2)) * enemySpeed;
            }
        }
        enemyAnimator.SetFloat(horizontal,dicrectionToMakeStep.x);
        enemyAnimator.SetFloat(vertical, dicrectionToMakeStep.y);
    }
}
