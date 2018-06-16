using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Camera : MonoBehaviour {

    [SerializeField]
    private GameObject _CameraPosition;
    [SerializeField]
    private GameObject _CameraLooktAtPosition;
    [SerializeField]
    private GameObject _Car;
    [SerializeField]
    private float _LookSpeed = 10;


    private void Start()
    {
        this.transform.LookAt(_CameraLooktAtPosition.transform.position);   
    }

    void Update()
    {
        //this.transform.position = _CameraPosition.transform.position;

        this.transform.LookAt(_CameraLooktAtPosition.transform.position);
        //this.transform.rotation = Quaternion.Euler(
        //    this.transform.rotation.eulerAngles.x,
        //    0,
        //    this.transform.rotation.eulerAngles.z
        //    );
        //Vector3 dir = (this.transform.position - _CameraLooktAtPosition.transform.position).normalized * -1;
        //Quaternion target = Quaternion.FromToRotation(transform.InverseTransformDirection(this.transform.up * -1), dir);
        ////target *= Quaternion.FromToRotation(transform.InverseTransformDirection(this.transform.forward), 
        ////    (this.transform.position - _Car
        ////    );
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, target, Time.deltaTime * _LookSpeed);
    }
}
