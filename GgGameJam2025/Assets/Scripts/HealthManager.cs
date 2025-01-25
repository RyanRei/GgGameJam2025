using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Image healthBarP1;
    public float healthAmountP1 = 100f;
    public Image healthBarP2;
    public float healthAmountP2 = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
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


    /*public void Heal(float damage)
    {
        healthAmount += damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;

    }*/
}

