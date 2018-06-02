using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Car : MonoBehaviour {

    [SerializeField]
    private GameObject _World;
    [SerializeField]
    private float _RotationSpeed = 20;
    [SerializeField]
    private float _MovementSpeed = 20;

    private Rigidbody myRigidbody;

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    	
	}

    private void FixedUpdate()
    {
        myRigidbody.AddForce(_MovementSpeed * Time.fixedDeltaTime * this.transform.forward);
        
    }
}
