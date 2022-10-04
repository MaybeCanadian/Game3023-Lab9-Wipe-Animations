using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireEffect : MonoBehaviour
{
    public Light2D lightComponent;
    public float flickerRate = 1.0f;

    public Vector2 intensityRange = new Vector2(0.5f, 1.5f);
    public Vector2 rangeRange = new Vector2(0.7f, 1.3f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetIntensity = UnityEngine.Random.Range(intensityRange.x, intensityRange.y);

        lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, targetIntensity, flickerRate * Time.deltaTime);

        float targetRange = UnityEngine.Random.Range(rangeRange.x, rangeRange.y);

        lightComponent.pointLightOuterRadius = Mathf.Lerp(lightComponent.pointLightOuterRadius, targetRange, flickerRate * Time.deltaTime);
    }
}
