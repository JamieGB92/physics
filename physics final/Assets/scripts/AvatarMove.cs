using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMove : MonoBehaviour {

    // Use this for initialization
    private Rigidbody m_rb = null;
    public float m_movementSpeed = 0.0f;
    public float m_jumpSpeed = 7.0f;
    public float m_angularSpeed = 1.57f;

    private float m_timeElapsed = 0.0f;
	void Start () {
        m_rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        bool isInAir = Mathf.Abs(m_rb.velocity.y) > 0.001f;
        float jumpSpeed = Input.GetKeyDown(KeyCode.Space) && !isInAir ? m_jumpSpeed : m_rb.velocity.y;
        Vector3 jumpVelocity = jumpSpeed * transform.up;

        float forwardSpeed = Input.GetKey(KeyCode.W) ? m_movementSpeed : 0.0f;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            forwardSpeed *= 2;
        }
        float backwardSpeed = Input.GetKey(KeyCode.S) ? -m_movementSpeed : 0.0f;
        float totalSpeed = forwardSpeed + backwardSpeed;
        
        Vector3 horizontalVelocity = totalSpeed * transform.forward;
        m_rb.velocity = horizontalVelocity + jumpVelocity;

        float rightAngularSpeed = Input.GetKey(KeyCode.D) ? m_angularSpeed : 0.0f;
        float leftAngularSpeed = Input.GetKey(KeyCode.A) ? -m_angularSpeed : 0.0f;
        float totalAngularSpeed = rightAngularSpeed + leftAngularSpeed;
        Vector3 angularVelocity = totalAngularSpeed * transform.up;
        m_rb.angularVelocity = angularVelocity;
    }

}
