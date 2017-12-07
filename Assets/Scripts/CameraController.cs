using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // floats for the max and min values for how far the camera can travel
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    private Vector3 offset;

    // Use this for initialization
    void Start ()
    {
        offset = transform.position - player.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void LateUpdate ()
    {
        // Everyframe the camera is moved to the player position
        transform.position = player.transform.position + offset;

        // Clamps the camera values horizontally so the level doesn't continue infinitely
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);

        // Clamps the camera values vertically so when the player jumps he doesn't show what's behind the background
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
