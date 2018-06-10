using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Crater : MonoBehaviour {

    GameObject world;

	void Start () {
        world = GameObject.FindGameObjectWithTag(scr_Tags.World);

        this.transform.LookAt(world.transform.position);
        this.transform.Rotate(-90, 0, 0);
        this.transform.Rotate(Vector3.up, Random.Range(0f, 360f));
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = (this.transform.position - world.transform.position).normalized;
        float length = world.transform.localScale.x / 2;

        this.transform.position = dir * length;
	}
}
