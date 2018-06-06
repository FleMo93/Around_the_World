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

    private Rigidbody myRigidbody;

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        SetRotation();
        

	}

    private void FixedUpdate()
    {
        SetPosition();
        lastPos = this.transform.position;

        Vector3 velocity = _MovementSpeed * this.transform.forward;
        myRigidbody.velocity = velocity;
    }

    private void SetPosition()
    {
        float length = (_World.transform.localScale.x / 2) + _CarHeightOffset;
        Vector3 startPoint = _World.transform.position;
        Vector3 dir = (_World.transform.position - this.transform.position).normalized * -1;

        Vector3 endPoint = startPoint + (dir * length);
        this.transform.position = endPoint;
    }

    Vector3? lastPos = null;
    private void SetRotation()
    {
        Vector3 dir = (_World.transform.position - this.transform.position).normalized;

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(this.transform.up, _RotationSpeed * Time.fixedDeltaTime * -1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(transform.InverseTransformDirection(transform.up), _RotationSpeed * Time.fixedDeltaTime);
        }

        Quaternion target = Quaternion.FromToRotation(transform.InverseTransformDirection(transform.up) * -1, dir);
        target *= Quaternion.FromToRotation(transform.InverseTransformDirection(transform.up) * -1, transform.InverseTransformDirection(transform.up) * -1);
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target, 50);
    }
}
