using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallplate : MonoBehaviour {

    public float timer;
   private IEnumerator countDown(float t)
    {

        yield return new WaitForSeconds(20);
        GetComponentInParent<Rigidbody>().useGravity = false;
    }
	// Use this for initialization
	void Start() { }
		
	
	
	// Update is called once per frame
	void Update () {
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {

            countDown(timer);
        }
    }
}
