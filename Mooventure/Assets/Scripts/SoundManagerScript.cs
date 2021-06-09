using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip buttonPressedSound, turkeySound, EDSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        buttonPressedSound = Resources.Load<AudioClip> ("all-click-button");
        turkeySound = Resources.Load<AudioClip> ("level-turkey-gobble");
        EDSound = Resources.Load<AudioClip> ("level-get-energy");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "all-click-button":
                audioSrc.PlayOneShot(buttonPressedSound);
                break;
            case "level-turkey-gobble":
                audioSrc.PlayOneShot(turkeySound);
                break;
            case "level-get-energy":
                audioSrc.PlayOneShot(EDSound);
                break;

        }
    }
}
