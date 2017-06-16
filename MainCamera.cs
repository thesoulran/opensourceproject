using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform target; //새
    public float xOffset;
    public float yOffset;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            this.transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset,
                transform.position.z);
        }
    }
}
