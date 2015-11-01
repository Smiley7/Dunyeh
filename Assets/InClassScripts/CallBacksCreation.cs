using UnityEngine;
using System.Collections;

public class CallBacksCreation : MonoBehaviour {

    delegate void delegateCaller(); // Pointer to create called delegate
    delegateCaller caller = FunctionToCall;
	
    // Use this for initialization
	void Start () {
        caller();
	}
	
	// Update is called once per frame
	static void FunctionToCall () {
        Debug.Log("Function called.");
	}
}
