using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transport : MonoBehaviour
{
    [SerializeField]
    string levelNameToTransport; 
    public string goToPlaceName; 
    private void OnTriggerEnter2D(Collider2D objToTransport) 
    {
        if(objToTransport.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<PlayerController>().nextPlaceName = goToPlaceName;
            SceneManager.LoadScene(levelNameToTransport);   
        }  
    }
}
