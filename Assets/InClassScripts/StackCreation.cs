using UnityEngine;
using System.Collections;

public class StackCreation : MonoBehaviour {
    //////////////////////////////////////
    /// ADDS TO THE START OF THE ARRAY ///
    //////////////////////////////////////
    public GameObject[] HitList;
    Stack HitStack; // Storing objects

	// Use this for initialization
	void Start () {
        HitStack = new Stack();
	}
	
	// Update is called once per frame
	void Update () {
        // Adding this to the container / stack
        if (HitStack.Count > 0) // Checking to see if there's anything inside the stack
        {
            GameObject lastObject = HitStack.Peek() as GameObject; // Adding the object into the stack

            Debug.DrawLine(transform.position, lastObject.transform.position, Color.red); // Last object added gets a line drawn onto it

            if(HitList[0] == lastObject)
            {
                StartCoroutine("popTheStack");
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.gameObject.tag);

        if (!HitStack.Contains(other.gameObject))
        {
            HitStack.Push(other.gameObject); // If the game object is not in the stack it will be added

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);
        }
    }

    IEnumerator popTheStack()
    {
        yield return new WaitForSeconds(2); // Creates a pause for x amount of time

        if (HitStack.Count > 0) // As long as there are objects in the stack
        {
            HitStack.Pop(); // Removes the value;
            HitList = new GameObject[HitStack.Count]; // Updates the new stack
            HitList.CopyTo(HitList, 0);
            StopCoroutine("popTheStack"); // Ends the IEnumerator
        }
    }
}
