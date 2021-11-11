using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MenuButtonScript menuButtonScript;
    
    void PlaySound(AudioClip whichSound)
    {
        menuButtonScript.audioSource.PlayOneShot(whichSound);
    }
}
