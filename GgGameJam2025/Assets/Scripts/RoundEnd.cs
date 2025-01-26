using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundEnd : MonoBehaviour
{

    public GameObject endPanel;
    public GameObject player1VicText;
    public GameObject player2VicText;
    private HealthManager healthManager;


    public void Start()
    {
        healthManager=GameObject.Find("HealthManager").GetComponent<HealthManager>();
    }
    public void end()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        healthManager.resetHealth();
        endPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void MainMenu(){
        endPanel.SetActive(false);
        SceneManager.LoadScene("mainmenu");
    }
    public void Exit(){
        Application.Quit();
        Debug.Log("Player has quit the game");
    }

    public void player1Victory()
    {
        end();
        player1VicText.SetActive(true);
        
    }

    public void player2Victory()
    {
        end();
        player2VicText.SetActive(true);

    }

}

