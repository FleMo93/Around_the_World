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
    [SerializeField]
    private float _GravityMultiplier = 300;
    [SerializeField]
    private bool _Move = true;
    [SerializeField]
    private GameObject _Model;
    [SerializeField]
    private float _ModelRotation = 15f;
    [SerializeField]
    private float _ModelRotationSpeed = 5f;

    Vector3 ovel;

    private void Update()
    {
        Quaternion tar = Quaternion.identity;
        //_Model.transform.rotation = this.transform.rotation;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.InverseTransformDirection(transform.transform.up), _RotationSpeed * Time.deltaTime * -1);

            tar = GetModelTargetRot(-_ModelRotation);
            _Model.transform.rotation = Quaternion.RotateTowards(_Model.transform.rotation, tar, _ModelRotationSpeed * Time.deltaTime);

            //_Model.transform.rotation. (_Model.transform.up, -_ModelRotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.InverseTransformDirection(transform.transform.up), _RotationSpeed * Time.deltaTime);
            tar = GetModelTargetRot(_ModelRotation);
        }
        else
        {
            tar = this.transform.rotation;
        }

        _Model.transform.rotation = Quaternion.RotateTowards(_Model.transform.rotation, tar, _ModelRotationSpeed * Time.deltaTime);

        SetPosition();
    }

    private Quaternion GetModelTargetRot(float rot)
    {
        Quaternion org = _Model.transform.rotation;
        _Model.transform.rotation = this.transform.rotation;
        _Model.transform.Rotate(_Model.transform.InverseTransformDirection(_Model.transform.up), rot);

        Quaternion target = _Model.transform.rotation;
        _Model.transform.rotation = org;

        return target;
    }

    private void FixedUpdate()
    {
        Physics.gravity = (_World.transform.position - this.transform.position).normalized * _GravityMultiplier;

        Vector3 vel = this.transform.forward * _MovementSpeed;
        Vector3 avel = _MyRigidbody.velocity - ovel;
        avel += vel;

        ovel = vel;

        if (_Move)
        {
            _MyRigidbody.velocity = vel;
        }
        else
        {
            _MyRigidbody.velocity = Vector3.zero;
        }

    }

    private void SetPosition()
    {
        float length = (_World.transform.localScale.x / 2) + _CarHeightOffset;
        Vector3 startPoint = _World.transform.position;
        Vector3 dir = (_World.transform.position - this.transform.position).normalized * -1;

        Vector3 endPoint = startPoint + (dir * length);
        this.transform.position = endPoint;
    }
}
