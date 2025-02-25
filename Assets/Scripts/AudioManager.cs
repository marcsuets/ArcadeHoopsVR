using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip basket;
    public AudioClip timerFinished;
    public AudioClip newHighscore;
    public AudioClip button;
    
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes the AudioManager persist across scenes
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    public void PlayBasket()
    { 
        gameObject.GetComponent<AudioSource>().PlayOneShot(basket);
    }

    public void PlayTimerFinished()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(timerFinished);
    }

    public void PlayNewHighscore()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(newHighscore);
    }
    public void PlayButton()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(button);
    }
}