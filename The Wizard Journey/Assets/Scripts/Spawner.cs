using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    PlayerController player;
    CameraFollow theCamera;
    [SerializeField]
    Transform playerPosition;
    [SerializeField]
    Transform camPosition;

    public Vector2 facingDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        player = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();
       /* player.gameObject.GetComponent<Renderer>().sortingOrder.Equals(1);
        Debug.Log("layer: " + player.gameObject.GetComponent<Renderer>().sortingOrder);*/

        player.transform.position = new Vector3 (playerPosition.position.x, playerPosition.position.y, playerPosition.position.z);
        theCamera.transform.position = new Vector3(camPosition.position.x, camPosition.position.y, camPosition.position.z);
        player.lastMovement = facingDirection;
    }
}
