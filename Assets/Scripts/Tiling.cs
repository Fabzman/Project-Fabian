using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    public int offsetX = 2;
    public bool rightPlatform = false;
    public bool leftPlatform = false;
    public bool background = false;
    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }

    // Use this for initialization
    void Start ()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (leftPlatform == false || rightPlatform == false)
        {
            //calculating what camera can see in world
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            ////calculating where camera can see edge of platform sprite
            float visibleEdgeRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float visibleEdgeLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;

            //checking if camera can see edge of platform sprite and calling NewPlatform if possible
            if (cam.transform.position.x >= visibleEdgeRight - offsetX && rightPlatform == false)
            {
                NewPlatform (1);
                rightPlatform = true;
            }

            else if (cam.transform.position.x <= visibleEdgeLeft + offsetX && leftPlatform ==false)
            {
                NewPlatform(-1);
                leftPlatform = true;
            }
        }
	}

    //function that creates a platform on the correct side
    void NewPlatform (int rightLeft)

        // calculating position for new platform
    {
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightLeft, myTransform.position.y, myTransform.position.z);
        //Instantiating a new platform and storing in a variable
        Transform newPlatform = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;

        //if not tilable reverse x to get rid of seams
        if (background == true)
        {
            newPlatform.localScale = new Vector3(newPlatform.localScale.x * -1, newPlatform.localScale.y, newPlatform.localScale.z);
        }

        newPlatform.parent = myTransform.parent;

        if (rightLeft > 0)
        {
            newPlatform.GetComponent<Tiling>().leftPlatform = true;
        }

        else
        {
            newPlatform.GetComponent<Tiling>().rightPlatform = true;
        }
    }

}
