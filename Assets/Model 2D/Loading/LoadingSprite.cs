using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSprite : MonoBehaviour
{
    public Sprite[] animatedImage;
    public Image animatedImageObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animatedImageObj.sprite = animatedImage[(int)(Time.time * 10) % animatedImage.Length];
    }
}
