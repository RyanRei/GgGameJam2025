using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image healthBarP1;
    public float healthAmountP1 = 100f;
    public Image healthBarP2;
    public float healthAmountP2 = 100f;

    private Color fullHealthColor = Color.green;
    private Color lowHealthColor = Color.red;
    public GameObject head;
    public GameObject body;
    public GameObject player1;
    public GameObject player2;
    private float emissiveIntensity = 5;
    private MeshRenderer objectRendererP1;
    public audiomanager audioM;
    public bool roundEnded = false;

    private RoundEnd roundEndManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public Material material;
    private void Awake()
    {   
        
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        material = head.GetComponent<MeshRenderer>().materials[1];
        roundEndManager=GameObject.Find("RoundEndManager").GetComponent<RoundEnd>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
        //material.SetColor("_EmissionColor", Color.red *emissiveIntensity);
        if (!roundEnded)
        {


            if (healthAmountP1 > 0 && healthAmountP2 <= 0)
            {
                roundEnded = true;
                player2.SetActive(false);
                audioM.StopMusic();
                audioM.PlaySFX(audioM.death);

               
                roundEndManager.player1Victory();

                
                Debug.Log("mat:");
                Debug.Log(emissiveIntensity);
            }
            else if (healthAmountP2 > 0 && healthAmountP1 <= 0)
            {
                roundEnded = true;
                player2.SetActive(false);
                audioM.PlaySFX(audioM.death);
                roundEndManager.player2Victory();
            }
        }
    }

    public void TakeDamage(float damage,int id)
    {
        if (id == 1)
        {
            healthAmountP1 -= damage;
            healthBarP1.fillAmount = healthAmountP1 / 100f;
            
     
        }
        else
        {
            healthAmountP2 -= damage;
            healthBarP2.fillAmount = healthAmountP2 / 100f;
            
        }
    }
    public void resetHealth()
    {
        healthAmountP1 = 0;
        healthAmountP2 = 0;
        roundEnded = false;
    }


    private void UpdateObjectColor(Renderer renderer, float healthPercent)
    {
        // Lerp between green and red based on health percentage
        Color newColor = Color.Lerp(lowHealthColor, fullHealthColor, healthPercent);
        renderer.materials[1].SetColor("_Color",newColor);
    }
  
}

