using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Comet : MonoBehaviour {

    [SerializeField]
    private float _Speed = 20;
    [SerializeField]
    private GameObject[] _GameObjectsToDetatch;
    [SerializeField]
    private GameObject _MeshHolder;
    [SerializeField]
    private float _RotationSpeed = 5;
    [SerializeField]
    private GameObject _CraterPrefab;

    Vector3 rotation;

	// Use this for initialization
	void Start () {
        Vector3 dir = (Vector3.zero - this.transform.position).normalized;
        GetComponent<Rigidbody>().velocity = dir * _Speed;
        transform.LookAt(Vector3.zero);

        rotation = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
            ).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        _MeshHolder.transform.Rotate(rotation * _RotationSpeed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        foreach(GameObject go in _GameObjectsToDetatch)
        {

            ParticleSystem ps = go.GetComponent<ParticleSystem>();
            var emission = ps.emission;
            emission.rateOverTime = 0;
            go.transform.SetParent(null);
            //go.AddComponent<scr_DestroyAfter>();
        }

        if(collision.gameObject == GameObject.FindGameObjectWithTag(scr_Tags.World))
        {
            Instantiate(_CraterPrefab).transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
