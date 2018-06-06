using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CometSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject _World;
    [SerializeField]
    private GameObject _CometPrefab;
    [SerializeField]
    private float _SpawnHeight = 40f;
    [SerializeField]
    private float _SpawnRateInSeconds = 1f;

    private float timeToSpawn;

	void Start ()
    {
        timeToSpawn = _SpawnRateInSeconds;	
	}
	
	void Update () {
        timeToSpawn -= Time.deltaTime;

        if(timeToSpawn <= 0)
        {
            GameObject comet = Instantiate(_CometPrefab);

            Vector3 direction = Vector3.zero;

            while(direction == Vector3.zero)
            {
                direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            }

            Vector3 position = direction * (_SpawnHeight + _World.transform.localScale.x);

            comet.transform.position = position;

            timeToSpawn = _SpawnRateInSeconds;
        }
	}
}
