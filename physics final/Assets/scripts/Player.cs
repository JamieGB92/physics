using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    public GameObject player;
    private Rigidbody pRb;
    public float torque;
    private float rotationSpeed;

    private bool turnLeft = false;
    private bool turnRight = false;
	void Start () {
        player = this.gameObject;
        pRb = player.GetComponent<Rigidbody>();
        rotationSpeed = torque;
	}
	
	// Update is called once per frame
	void Update () {
	   
       
        


    }

    private void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.A))
        {
            pRb.AddTorque(transform.up * rotationSpeed * turn*-1);
        }
        if(Input.GetKey(KeyCode.D))
        {
            pRb.AddTorque(transform.up * -rotationSpeed * turn);
        }
       
        if(Input.GetKeyDown(KeyCode.W))
        {
            Vector3 Accel = 50 * this.transform.right;

            pRb.AddForce( Accel,ForceMode.Acceleration);
        }
        
           
    }



}
