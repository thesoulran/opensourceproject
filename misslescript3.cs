using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misslescript3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        /*
        var hit = col.gameObject;
        var health = hit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(playerFrom, 10);
        }
        */



        if (col.gameObject.name == "TerrainCollider")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.name == "player 1(Clone)")
        {
            Destroy(gameObject);
        }

    }
}
