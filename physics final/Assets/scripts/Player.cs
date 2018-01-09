using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    public GameObject player;
    private Rigidbody pRb;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpForce;
    private bool isJumping=false;
    private bool isWalking = false;
   
	void Start () {
        player = this.gameObject;
        pRb = player.GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            Debug.Log("pressing w");
            if(Input.GetKey(KeyCode.LeftShift))
            {
                walkSpeed+=1;
            }
        }
      else
        {
            isWalking = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
        else
        {
           
            isJumping = false;
        }



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
       
        if(isWalking)
        {
            Debug.Log("isWalking=" + isWalking);
            // Vector3 dir = ne
            pRb.AddRelativeForce(Vector3.right*walkSpeed);
        }
        
        if(isJumping)
        {
            pRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }
        
           
}



