using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayStates
{
    moving,
    stationary
}

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float gridSize = 0.3f;
    public Transform movePoint;


    PlayStates playState;

    // Start is called before the first frame update
    void Start()
    {
        playState = PlayStates.moving;
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Input.GetAxisRaw("Horizontal") != 0f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * gridSize, 0f, 0f);
            }
            if (Input.GetAxisRaw("Vertical") != 0f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * gridSize, 0f);
            }
        }
    }
}