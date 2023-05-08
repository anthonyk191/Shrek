using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 offset = new Vector3(0 , 4, -20);
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = player.transform.position + offset;
        // float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z)* Mathf.Rad2Deg + transform.eulerAngles.y;
        // Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;


        // transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime);
        // moveHorizontal = Input.GetAxis("Horizontal"); //Stuff

        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, player.transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.position = player.transform.position;
        Quaternion rot = transform.rotation;
        Quaternion player_rot = player.transform.rotation;
        Quaternion goal_rot = Quaternion.Euler(rot.eulerAngles.x, player_rot.eulerAngles.y, rot.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(rot, goal_rot, Time.deltaTime*rotationSpeed);
        // transform.RotateAround(player.transform.position, Vector3.up, slerp_rotation.eulerAngles.y); //Stuff


        // transform.rotation = Quaternion.Lerp(transform.rotation, player.transform.rotation, Time.deltaTime);
        // transform.rotation = 
    }
}