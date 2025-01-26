using System;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class BodyCollisionDetector : MonoBehaviour
{
    private HealthManager healthManager;
    public audiomanager audioM;



    public float emissiveIntensity = 10f; // Initial intensity
    public float transitionSpeed = 0.5f; // Speed of the transition
    public float minIntensity = 0f;   // Minimum intensity limit

    public float emissiveIntensity2 = 10f; // Initial intensity
    public float transitionSpeed2 = 0.5f; // Speed of the transition
    public float minIntensity2 = 0f;   // Minimum intensity limit
    private Color targetColor = Color.red;

    public GameObject head1;
    public GameObject head2;
    public GameObject body1;
    public GameObject body2;

    private Material headMat1;
    private Material bodyMat2;
    private Material headMat2;
    private Material bodyMat1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();

        headMat1=head1.GetComponent<MeshRenderer>().materials[1];
        bodyMat1=body1.GetComponent<MeshRenderer>().materials[1];
        headMat2=head2.GetComponent<MeshRenderer>().materials[1];
        bodyMat2=body2.GetComponent<MeshRenderer>().materials[1];



        //meterialPlater1 = GameObject.FindGameObjectsWithTag("Player1Body");

    }

    // Update is called once per frame
    void Update()
    {

    }

   

    private void OnTriggerEnter(Collider other)
    {

        print("Collosuoss");
        if (other.CompareTag("Player2Body") && gameObject.CompareTag("Player1Sword")) // Enemy body
        {
            emissiveIntensity = Mathf.Max(emissiveIntensity - 2f, minIntensity); // Reduce intensity by 2
            ChangeEmissionColor(headMat2,emissiveIntensity);
            ChangeEmissionColor(bodyMat2,emissiveIntensity);

            audioM.playRandomSlash();
            //Debug.Log("Player " + playerID + " hit Player " + (3 - playerID) + "!");
            healthManager.TakeDamage(5, 2);
        }
        else if (other.CompareTag("Player1Body") && gameObject.CompareTag("Player2Sword")) // Enemy body
        {
            emissiveIntensity2 = Mathf.Max(emissiveIntensity2 - 2f, minIntensity); // Reduce intensity by 2
            ChangeEmissionColor(headMat1,emissiveIntensity2);
            ChangeEmissionColor(bodyMat1,emissiveIntensity2);
            audioM.playRandomSlash();
            healthManager.TakeDamage(5, 1);
            print("Trigger");
        }

    }

    private void ChangeEmissionColor(Material mat,float ems)
    {
        // Get the current emission color
        Color currentEmissionColor = mat.GetColor("_EmissionColor") / ems;

        // Transition to red
        Color newColor = Color.Lerp(currentEmissionColor, targetColor, transitionSpeed);

        // Apply new emission color with updated intensity
        mat.SetColor("_EmissionColor", newColor * ems);
        mat.EnableKeyword("_EMISSION");
    }
}
