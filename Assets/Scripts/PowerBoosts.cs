using UnityEngine;
using System.Collections;

public class PowerBoosts : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boost Activated");
        if (other.gameObject.tag == "Player1")
            Destroy(gameObject);
        if (other.gameObject.tag == "Player2")
            Destroy(gameObject);
    }
}
