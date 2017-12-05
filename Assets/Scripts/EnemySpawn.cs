using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public Transform [] spawnPlace;
	public GameObject [] enemyPrefab;
	public GameObject [] enemyClone;


	// Use this for initialization
	void Start () 
	{
		spawnViking ();
	}

	void spawnViking ()
	{
		enemyClone [0] = Instantiate (enemyPrefab [0], spawnPlace [0].transform.position, Quaternion.Euler (0,0,0)) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
