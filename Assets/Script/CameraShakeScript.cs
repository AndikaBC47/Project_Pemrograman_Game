using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour
{
    [SerializeField] private float power = 0.05f;
    [SerializeField] private float duration = 1f;
    private float slowDownAmount = 1f;
    private bool needShake = false;
    public Transform camera;
    Vector3 startpos;
    float initialDuration;
    void Start()
    {
        camera = Camera.main.transform;
        startpos = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (needShake)
        {
            if (duration > 0)
            {
                camera.localPosition = startpos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                needShake = false;
                duration = initialDuration;
                camera.localPosition = startpos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InterObjectHeal" || other.tag == "InterObjectDamage" || other.tag == "Enemy")
        {
            needShake = true;
        }
    }
}
