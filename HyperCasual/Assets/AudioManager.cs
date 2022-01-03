using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    
    public AudioMixerGroup EffetMixer, MusiqueMixer;
    public AudioSource audioSources;


    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("il y a plus d'une instance de audiomanager dans la scene ");
            return;
        }

        instance = this;
    }


    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
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
        audioSource.outputAudioMixerGroup = EffetMixer;
        //on joue le clip
        audioSource.Play();
        //on detruis tempGo apres la fin du clip
        Destroy(tempGO, clip.length);

        return audioSource;
    }
}
