using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_World : MonoBehaviour {

    [SerializeField]
    private float _DecreasePerSecond = 0.3f;
    [SerializeField]
    private float _MinRadius = 10f;

    void Update () {
        if (!scr_Game.Get.GameRunning)
        {
            return;
        }

        float decrease = _DecreasePerSecond * Time.deltaTime;

        if (transform.lossyScale.x - decrease < _MinRadius)
        {
            this.transform.localScale = new Vector3(_MinRadius, _MinRadius, _MinRadius);
        }
        else
        {
            this.transform.localScale -= new Vector3(decrease, decrease, decrease);
        }
	}
}
