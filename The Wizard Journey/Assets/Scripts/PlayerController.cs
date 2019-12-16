using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    bool walking = false;
    public Vector2 lastMovement = Vector2.zero;
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";
    const string attackState = "Attack";

    Animator animator;
    Rigidbody2D playerRigidBody;

    public string nextPlaceName; 

    bool attack = false;
    public float attackTime;
    float attackTimeCounter;

    public bool playerIsTalking;

    private SFXManager managerSFX; 

    public static bool playerCreated; 
    // Start is called before the first frame update
    void Start()
    {
        managerSFX = FindObjectOfType<SFXManager>();
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        PlayerCreated();
        playerIsTalking = false;
    }

    // Update is called once per frame
    void Update()
    {  
        CheckButtonMovements();
    }

    void PlayerCreated()
    {
        if(!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
            Destroy(gameObject);
    }

    void CheckButtonMovements()
    {
        //Desplazamiento: Espacio = Velocidad * Tiempo
        //Horizontal movement
        walking = false;

        if(playerIsTalking)
        {
            playerRigidBody.velocity = Vector2.zero;
            return;
        }
        if(Input.GetMouseButtonDown(0)||Input.GetKeyDown("joystick button 0"))
        {
            attack = true;
            attackTimeCounter = attackTime;
            playerRigidBody.velocity = Vector2.zero;
            animator.SetBool(attackState,true);

            managerSFX.playerAttack.Play();
        }

        if(attack)
        {
            attackTimeCounter -= Time.deltaTime;
            if(attackTimeCounter < 0)
            {
                attack = false;
                animator.SetBool(attackState, false);
            }
        }
        else
        {
            if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(horizontal),Input.GetAxisRaw(vertical));
                playerRigidBody.velocity = lastMovement.normalized * speed * Time.deltaTime;
            }
        }

        if(!walking)
        {
            playerRigidBody.velocity = Vector2.zero;
        }

        animator.SetFloat(horizontal,Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical,Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState,walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);

    }
}
