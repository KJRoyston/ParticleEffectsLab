using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour {

	public List<GameObject> prefabs;
    public float fireDelay;
    float timer;
	void Start () {
        timer = fireDelay;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = fireDelay;
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
	}
}
