using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioSource sfxSource;

    public AudioClip _background;
    public AudioClip _walk;
    public AudioClip _talk;
    public AudioClip _door;
    public AudioClip _kill;
    public AudioClip _death;
    public AudioClip _skelSound;
    public AudioClip _crafting;
    public AudioClip _pickupFragment;
    public AudioClip _lockOpened;
    public AudioClip _backgroundSchool;
    public AudioClip _potionClass;
    public AudioClip _library;
    public AudioClip _theory;
    public AudioClip _basement;
    public AudioClip _Bedroom;
    public AudioClip _Wc;
    public AudioClip _paper;
    public AudioClip _apBgm;

    private void Start()
    {
        string[] apScenes = { "apBasement", "apSchoolInside", "apTheoryClass", "apPotionLab", "apLibrary", "ApSchoolEntrance", "apBedroom", "apWc", };
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "SchoolEntrance")
        {
            SetBackGroundMusic(_background);
        }
        else if (sceneName == "SchoolInsideEntrance")
        {
            SetBackGroundMusic(_backgroundSchool);
        }
        else if (sceneName == "PotionLab")
        {
            SetBackGroundMusic(_potionClass);
        }
        else if (sceneName == "library")
        {
            SetBackGroundMusic(_library);
        }
        else if (sceneName == "TheoryClass")
        {
            SetBackGroundMusic(_theory);
        }
        else if (sceneName == "Basement")
        {
            SetBackGroundMusic(_basement);
        }
        else if (System.Array.Exists(apScenes, element => element == sceneName))
        {
            SetBackGroundMusic(_apBgm);
        }
        else if (sceneName == "Bedroom")
        {
            SetBackGroundMusic(_Bedroom);
        }
        else if (sceneName == "Wc" || sceneName == "Wc_Vision")
        {
            SetBackGroundMusic(_Wc);
        }
        else if (sceneName == "MainMenu")
        {
            SetBackGroundMusic(_background);
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.loop = true;
        sfxSource.Play();
    }

    public void SetBackGroundMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = 0.05f;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSFX()
    {
        Debug.Log("Stopping SFX");
        sfxSource.loop = false;
        sfxSource.Stop();
    }

    public void PlayOneTimeSFX(AudioClip clip)
    {
        Debug.Log("Playing " + clip.name);
        sfxSource.PlayOneShot(clip);
    }

}
