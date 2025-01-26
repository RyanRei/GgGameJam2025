using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("-------- Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip menu;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip walk;
    public AudioClip slash1;
    public AudioClip slash2;
    public AudioClip slash3;
    public AudioClip swing1;
    public AudioClip swing2;
    public AudioClip swing3;

    public void Start(){
        musicSource.clip = background;
        musicSource.Play();
    }


    public void StartMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }



    public void playRandomSwing()
    {
        int range = UnityEngine.Random.Range(1, 3);
        if (range == 1)
        {
            SFXSource.PlayOneShot(swing1);
        }
        else if (range == 2)
        {
            SFXSource.PlayOneShot(swing2);
        }
        else
        {
            SFXSource.PlayOneShot(swing3);
        }
    }


    public void playRandomSlash()
    {
        int range = UnityEngine.Random.Range(1, 3);
        if (range == 1)
        {
            SFXSource.PlayOneShot(slash1);
        }
        else if (range == 2)
        {
            SFXSource.PlayOneShot(slash2);
        }
        else
        {
            SFXSource.PlayOneShot(slash3);
        }
    }
}

