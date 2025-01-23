using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip basket;
    public AudioClip timerFinished;
    public AudioClip newHighscore;
    
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
        Debug.Log("Playing basket");
        gameObject.GetComponent<AudioSource>().PlayOneShot(basket);
    }

    public void PlayTimerFinished()
    {
        Debug.Log("PlayTimerFinished called");
        gameObject.GetComponent<AudioSource>().PlayOneShot(timerFinished);
    }

    public void PlayNewHighscore()
    {
        Debug.Log("PlayNewHighscore called");
        gameObject.GetComponent<AudioSource>().PlayOneShot(newHighscore);
    }
}