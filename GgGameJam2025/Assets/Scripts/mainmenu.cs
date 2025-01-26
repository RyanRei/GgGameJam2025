using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{
    private HealthManager healthManager;
    private void Awake()
    {
    }
    private void Start()
    {
        
        
    }
    public void Play()
    {
        SceneManager.LoadScene("gameplay");
        Time.timeScale = 1;
    }
    public void Options()
    {
        SceneManager.LoadScene("options");
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
