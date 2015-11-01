using UnityEngine;
using System.Collections;

public class QueuesCreation : MonoBehaviour
{
    ////////////////////////////////////
    /// ADDS TO THE END OF THE ARRAY ///
    ////////////////////////////////////
    public GameObject[] HitList;
    Queue HitStack; // Storing objects

    // Use this for initialization
    void Start()
    {
        HitStack = new Queue();
    }

    // Update is called once per frame
    void Update()
    {
        // Adding this to the container / stack
        if (HitStack.Count > 0) // Checking to see if there's anything inside the stack
        {
            GameObject lastObject = HitStack.Peek() as GameObject; // Adding the object into the stack

            Debug.DrawLine(transform.position, lastObject.transform.position, Color.red); // Last object added gets a line drawn onto it

            if (HitList[0] == lastObject)
            {
                StartCoroutine("DequeueTheStack");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger" + other.gameObject.tag);

        if (!HitStack.Contains(other.gameObject))
        {
            HitStack.Enqueue(other.gameObject); // If the game object is not in the stack it will be added

            HitList = new GameObject[HitStack.Count];

            HitStack.CopyTo(HitList, 0);
        }
    }

    IEnumerator DequeueTheStack()
    {
        yield return new WaitForSeconds(2); // Creates a pause for x amount of time

        if (HitStack.Count > 0) // As long as there are objects in the stack
        {
            HitStack.Dequeue(); // Removes the value;
            HitList = new GameObject[HitStack.Count]; // Updates the new stack
            HitList.CopyTo(HitList, 0);
            StopCoroutine("DequeueTheStack"); // Ends the IEnumerator
        }
    }
}
