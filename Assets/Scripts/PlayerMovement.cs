using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 20.0f;
    float originalSpeed;
    [SerializeField] float turnSpeed;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject kart;
    private float moveHorizontal;
    private float moveForward;
    
    int states;
    int stateNormal = 1;
    int stateGrinding = 2;
    bool boostReady = false;

    // Update is called once per frame
    void Start()
    {
        states = stateNormal;
        originalSpeed = speed;
    }
    void Update()
    {
        //Normal State Having Player Move forward and backwards
        if (states == stateNormal)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveForward = Input.GetAxis("Vertical");
            cube.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * speed * moveForward);
            cube.transform.Rotate(new Vector3(0,1,0) * moveHorizontal * turnSpeed);
            
            //Kart Follows Cube movement and rotation
            kart.transform.position = cube.transform.position;
            kart.transform.rotation = cube.transform.rotation;
        }
        if (states == stateGrinding)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveForward = Input.GetAxis("Vertical");
            cube.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * speed * moveForward);
            kart.transform.position = cube.transform.position;
            cube.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * moveHorizontal * 5);

        }
        
        
        //Boost Stuff
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            states = stateGrinding;
            kart.transform.Rotate(new Vector3(0,1,0) * moveHorizontal * turnSpeed*400);
            StartCoroutine(ShiftHoldTimer());
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            states = stateNormal;
            cube.transform.rotation = kart.transform.rotation;
            if (boostReady == true)
            {
                StartCoroutine(BoostCoroutine());
                boostReady = false;
            }

        }
    IEnumerator BoostCoroutine()
    {
        speed = 90;
        yield return new WaitForSeconds(1.0f);
        speed = originalSpeed;
    }
    // Whenever ShiftHoldTimer is called by "StartCoroutine" if counts down to 2 seconds. However if 3 seconds has not passed nothing is returned
    IEnumerator ShiftHoldTimer()
    {
        float timer = 0.0f;

        while (timer <= 2.0f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        boostReady = true;
        Debug.Log("Boost is ready");
    }
    }
}

