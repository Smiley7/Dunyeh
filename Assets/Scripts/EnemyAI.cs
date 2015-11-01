using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float playerDistance;
    public float rotationSpeed;
    public float moveSpeed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.visible)
        {
            Debug.Log("He's in sight");
            playerDistance = Vector3.Distance(-1 * player.position, transform.position);
            if (playerDistance < 15f)
                runFromPlayer();
            if (playerDistance < 12f)
                chase();
        }
        else
        {
            Debug.Log("He's not in sight");
            playerDistance = Vector3.Distance(player.position, transform.position);
            lookAtPlayer();
            chase();
            if (playerDistance < 2f)
            {
                attack();
            }
        }
    }

    void runFromPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player1")
            {

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Dead");
        if (other.gameObject.tag == "Player1")
            Destroy(other.gameObject);
    }
}
