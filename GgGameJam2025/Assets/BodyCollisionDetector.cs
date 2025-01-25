using UnityEngine;

public class BodyCollisionDetector : MonoBehaviour
{
    private HealthManager healthManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        print("Collosuoss");
        if (other.CompareTag("Player2Body") && gameObject.CompareTag("Player1Sword")) // Enemy body
        {
            //Debug.Log("Player " + playerID + " hit Player " + (3 - playerID) + "!");
            healthManager.TakeDamage(5, 2);
        }
        else if (other.CompareTag("Player1Body") && gameObject.CompareTag("Player2Sword")) // Enemy body
        {
            //Debug.Log("Player " + playerID + " hit Player " + (3 - playerID) + "!");
            healthManager.TakeDamage(5, 1);
            print("Trigger");
        }

    }
}
