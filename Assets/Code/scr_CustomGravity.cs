using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CustomGravity : MonoBehaviour {

    [SerializeField]
    public float _GravityStrength = -9.81f;
    [SerializeField]
    private GameObject _GravityCenter;

    private Rigidbody myRigidbody;

	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        Vector3 direction = (_GravityCenter.transform.position - this.transform.position).normalized;

        Vector3 velocity = myRigidbody.velocity + (direction * myRigidbody.mass * Time.fixedDeltaTime);

        //velocity.y -= myRigidbody.mass * Time.fixedDeltaTime;

        myRigidbody.velocity = velocity;

        //Vector3 newVelocity = direction * myRigidbody.velocity.magnitude;
        //myRigidbody.velocity = newVelocity;
        //myRigidbody.AddForce(_GravityStrength * (direction * -1) * Time.fixedDeltaTime * _Mass);

        //Debug.Log(myRigidbody.velocity.magnitude);
    }
}
