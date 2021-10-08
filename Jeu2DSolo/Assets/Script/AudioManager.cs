using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

   
    public AudioClip[] playListe;
    public AudioSource audioSources;
    private int musicIndex;
    public AudioMixerGroup soundEffetMixer;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de AudioManager dans cette scene");
            return;
        }

        instance = this;
    }
    void Start()
    {
        audioSources.clip = playListe[0];
        audioSources.Play();
    }


    void Update()
    {
        if (!audioSources.isPlaying)
        {
            PlayNextSound();
        }
    }

    private void PlayNextSound()
    {
        musicIndex = (musicIndex + 1) % playListe.Length;
        audioSources.clip = playListe[musicIndex];
        audioSources.Play();

    }

    public  AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        //genère un nouveau gameobject temporaire 
        GameObject tempGO = new GameObject("TempAudio");
        //on reposition l'object avec pos
        tempGO.transform.position = pos;
        // on ajoute un audio source au gameObject
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        //on passe en parametre le clip
        audioSource.clip = clip;

        //on change l'output de audiosource
        audioSource.outputAudioMixerGroup = soundEffetMixer;
        //on joue le clip
        audioSource.Play();
        //on detruis tempGo apres la fin du clip
        Destroy(tempGO, clip.length);

        return audioSource;
    }
}
