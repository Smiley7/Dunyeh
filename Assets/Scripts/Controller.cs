using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))] // Prevents from removing said objects and or destroying

public class Controller : MonoBehaviour {

    ////////////////////////////////////////////////////////////////////////////////////////////
    ////// NOTE: You can have a pause effect by setting Time = 0 preventing player controls ////
    ////// NOTE: Player/Objects move towards the blue/Z-axis direction as forward           ////
    ////////////////////////////////////////////////////////////////////////////////////////////

    public static bool visible;
    public Transform enemy;
    public float speed = 6.0f; // Movement speed
    public float jumpSpeed = 8.0f; // Jump speed
    public float rotateSpeed = 5.0f; // Rotate speed
    public float gravity = 9.8f; // Gravity force
    Vector3 moveDirection = Vector3.zero; // Creating move direction

    public int type = 0; // Test for simple move or default move

    CharacterController playerControls; // reference function to reuse the controller script

    // Bullet variables
    public Rigidbody projectilePrefab; // Creating Bullet prefab
    public Transform projectileSpawnPoint; // Spawning prefab in current destination
    public float fireSpeed = 50.0f;

	// Use this for initialization
	void Start () {
        // Grab a component and keep a reference to it
        playerControls = GetComponent<CharacterController>();
        if (!playerControls)
            Debug.Log("No control script found");
        visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        Insight();
        // SimpleMove()
        if(type == 1)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0); // Rotates along the y axis

            Vector3 forward = transform.TransformDirection(Vector3.forward); // Figure out the forward direction of character

            float curSpeed = speed * Input.GetAxis("Vertical"); // Movements in the vertical direction

            playerControls.SimpleMove(forward * curSpeed); // SimpleMove prevents jumping
        }
        // Move()
        else if(type == 0)
        {
           if(playerControls.isGrounded)
            {
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); // Straffing

                transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

                moveDirection = transform.TransformDirection(moveDirection); // Moving object

                moveDirection *= speed; // Speed implemented

                if (Input.GetButton("Jump")) // Adding jump mechanic
                    moveDirection.y = jumpSpeed;
            }

            moveDirection.y -= gravity * Time.deltaTime; // Implementing gravity

            playerControls.Move(moveDirection * Time.deltaTime); // This Move() implements jumping mechanics
        }

        // Key Press Stuff
        if(Input.GetButtonDown("Fire1")) // Using innate naming convention
        {
            Debug.Log("Shots Fired!");
            if (projectilePrefab)
            {
                Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation)
                    as Rigidbody; // Forcing the instantiated object into being a Rigidbody to add force to it
                temp.AddForce(projectileSpawnPoint.transform.forward * fireSpeed, ForceMode.Impulse); // Adds the force to the instantiated object
            }
            else
            {
                Debug.Log("No shots fired");
            }
        }
	}

    public void Insight()
    {
        Vector3 enemyDirection = enemy.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(enemyDirection, forward);
        if (angle > 60)
            visible = false;
        else
            visible = true;
    }
}
