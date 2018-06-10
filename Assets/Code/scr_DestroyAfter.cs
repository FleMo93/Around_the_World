using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DestroyAfter : MonoBehaviour
{
    [SerializeField]
    private float _DestoryAfter = 5f;

	// Update is called once per frame
	void Update () {
        _DestoryAfter -= Time.deltaTime;

        if (_DestoryAfter <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
