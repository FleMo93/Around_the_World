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
    [SerializeField]
    private float _CarHeightOffset = 0.5f;
    [SerializeField]
    private Rigidbody _MyRigidbody;

	// Update is called once per frame
	void Update ()
    {
        //SetRotation();
        Physics.gravity = (_World.transform.position - this.transform.position).normalized * 100;

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.InverseTransformDirection(transform.transform.up), _RotationSpeed * Time.fixedDeltaTime * -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.InverseTransformDirection(transform.transform.up), _RotationSpeed * Time.fixedDeltaTime);
        }

        Vector3 fwd = this.transform.forward * _MovementSpeed;
        Vector3 vel = fwd;
        _MyRigidbody.velocity = vel;
    }
}
