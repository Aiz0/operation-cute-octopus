using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    public static ScreenShakeController instance;

    private Transform transform;

    private float shakeDuration = 0f;

    [SerializeField]
    private float shakePower = 0.7f;

    [SerializeField]
    private float dampingSpeed = 1f;

    Vector3 initialPosition;

    private void Start()
    {
        instance = this;
    }

    private void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if(shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakePower;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        } else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float shakeTime)
    {

        shakeDuration = shakeTime;
        Handheld.Vibrate();

    }
}
