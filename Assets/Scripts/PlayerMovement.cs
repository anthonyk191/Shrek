using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    [SerializeField] float turnSpeed;
    private float moveHorizontal;
    private float moveForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveForward = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(0,0,1) * Time.deltaTime * speed * moveForward);
        transform.Rotate(new Vector3(0,1,0) * moveHorizontal * turnSpeed);
    }
}
