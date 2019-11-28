using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            this.transform.Translate(new Vector3(Input.GetAxisRaw(horizontal)* speed * Time.deltaTime,0,0));
        //Vertical Movement
        if(Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            this.transform.Translate(new Vector3(0,Input.GetAxisRaw(vertical) * speed * Time.deltaTime,0));
    }
}
