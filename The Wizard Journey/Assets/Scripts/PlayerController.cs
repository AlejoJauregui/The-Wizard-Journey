using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    bool walking = false;
    Vector2 lastMovement = Vector2.zero;
    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    const string lastHorizontal = "LastHorizontal";
    const string lastVertical = "LastVertical";
    const string walkingState = "Walking";
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {  
        CheckButtonMovements();
    }

    void CheckButtonMovements()
    {
        //Desplazamiento: Espacio = Velocidad * Tiempo
        //Horizontal movement
        walking = false;
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
        {
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)* speed * Time.deltaTime,0,0));
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal),0);
        }
        //Vertical Movement
        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical) * speed * Time.deltaTime,0));
            walking = true; 
            lastMovement = new Vector2(0,Input.GetAxisRaw(vertical));
        }

        animator.SetFloat(horizontal,Input.GetAxisRaw(horizontal));
        animator.SetFloat(vertical,Input.GetAxisRaw(vertical));
        animator.SetBool(walkingState,walking);
        animator.SetFloat(lastHorizontal, lastMovement.x);
        animator.SetFloat(lastVertical, lastMovement.y);

    }
}
