using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    // Update is called once per frame
    void Open()
    {
        transform.LeanScale(Vector2.one, 0.8f);
    }

    void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
