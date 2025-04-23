using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class GlitchFadeOut : MonoBehaviour
{
    public Volume glitchVolume;
    public float fadeDuration = 1.5f;

    private AnalogGlitchVolume analogGlitch;
    private DigitalGlitchVolume digitalGlitch;
    private float timer;

    
    private float startScanLineJitter = 0.4f;
    private float startColorDrift = 0.19f;
    private float startDigitalIntensity = 0.12f;

    void Start()
    {
        if (glitchVolume != null && glitchVolume.profile != null)
        {
            glitchVolume.profile.TryGet(out analogGlitch);
            glitchVolume.profile.TryGet(out digitalGlitch);
            timer = fadeDuration;
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            float t = timer / fadeDuration;

            if (analogGlitch != null)
            {
                analogGlitch.scanLineJitter.value = Mathf.Lerp(0f, startScanLineJitter, t);
                analogGlitch.colorDrift.value = Mathf.Lerp(0f, startColorDrift, t);
            }

            if (digitalGlitch != null)
            {
                digitalGlitch.intensity.value = Mathf.Lerp(0f, startDigitalIntensity, t);
            }
        }
    }
}
