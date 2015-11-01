using UnityEngine;
using System.Collections;
using System.Collections.Generic; // System for Dictionary function

///////////////////////////////////////////////////////////////////////////////////////////////
///  Dictionary script creates an Array/Counts types of objects / tags in a provided scene  ///
///////////////////////////////////////////////////////////////////////////////////////////////
public class Spawns : MonoBehaviour {
    public Dictionary<string, Transform> PowerUpLocations; // Creating a dictionary
    public GameObject[] powerUp = new GameObject[5];

    // Use this for initialization
    void Start () {
        PowerUpLocations = new Dictionary<string, Transform>();

        Transform[] goPoint = Transform.FindObjectsOfType(typeof(Transform)) as Transform[]; // Look for specific type of objects

        foreach(Transform point in goPoint)
        {
        
            if (point.tag == "Spawn")
            {
                PowerUpLocations.Add(point.name, point);
            }
        }

        foreach (KeyValuePair<string, Transform> power in PowerUpLocations)
        {
            int boostsCreated = Random.Range(0, powerUp.Length);
            Instantiate(powerUp[boostsCreated], power.Value.position, power.Value.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
