using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    // Arrays with prefabs atached for spawning
	public Transform [] spawnPlace;
	public GameObject [] enemyPrefab;
	public GameObject [] enemyClone;


	// Use this for initialization
	void Start () 
	{
		spawnViking ();
	}

    // Spawns enemy according to transform 
    // Since it is a child of the ground Game Object
    // It will spawn in correct transfrom according to Game Object
	void spawnViking ()
	{
		enemyClone [0] = Instantiate (enemyPrefab [0], spawnPlace [0].transform.position, Quaternion.Euler (0,0,0)) as GameObject;
	}
}
