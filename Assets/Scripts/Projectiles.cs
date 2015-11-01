using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	// Use this for initialization
	void Start () 
{
        Destroy(gameObject, 5f);
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
            Destroy(gameObject);
        if (other.gameObject.tag == "Enemy")
            Destroy(other.gameObject, 5f);
    }
}
