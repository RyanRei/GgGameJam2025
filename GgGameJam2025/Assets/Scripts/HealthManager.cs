using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image healthBarP1;
    public Image healthBarP1_2;

    public float healthAmountP1 = 200f;
    public Image healthBarP2;
    public Image healthBarP2_2;
    public float healthAmountP2 = 200f;

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

    public P1SwordAttack attack1;
    public P2SwordAttack attack2;



    public float boosterP1 = 0;
    public float boosterP2 = 0;
    public Image booster1;
    public Image booster2;
    public float boosterRate = 0;

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
            if (boosterP1 >= 100)
            {
                attack1.ultimateActivate = true;
            }

            if (boosterP2 >= 100) { attack2.ultimateActivate = true; }


            if (healthAmountP1 > 0 && healthAmountP2 <= 0)
            {
                roundEnded = true;
                player2.SetActive(false);
                audioM.StopMusic();
                audioM.PlaySFX(audioM.death);
                StartCoroutine(Timegap1());
                

                

                Debug.Log("mat:");
                Debug.Log(emissiveIntensity);
            }
            else if (healthAmountP2 > 0 && healthAmountP1 <= 0)
            {
                roundEnded = true;
                player1.SetActive(false);
                audioM.StopMusic();
                audioM.PlaySFX(audioM.death);

                StartCoroutine( Timegap2());
                //yield()
            
            }
        }
    }


    private IEnumerator Timegap1()
    {
     
        yield return new WaitForSeconds(2f);
        roundEndManager.player1Victory();

    }
    private IEnumerator Timegap2()
    {

        yield return new WaitForSeconds(2f);
        roundEndManager.player2Victory();

    }

    public void TakeDamage(float damage,int id)
    {
        if (id == 1)
        {
            boosterP2 += 18;
            booster2.fillAmount = boosterP2 / 100f;
            healthAmountP1 -= damage;
            healthBarP1.fillAmount = healthAmountP1 / 200f;
            healthBarP1_2.fillAmount = healthAmountP1 / 200f;




        }
        else
        {
            
            boosterP1 += 18;
            booster1.fillAmount = boosterP1 / 100f;
            healthAmountP2 -= damage;
            healthBarP2.fillAmount = healthAmountP2 / 200f;
            healthBarP2_2.fillAmount = healthAmountP2 / 200f;

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

