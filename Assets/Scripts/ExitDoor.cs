using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;   
using URPGlitch.Runtime.DigitalGlitch;  

public class ExitDoor : MonoBehaviour
{
    public Volume glitchVolume;
    public string nextSceneName;
    public float glitchDuration = 2f;

    private AnalogGlitchVolume analogGlitch;
    private DigitalGlitchVolume digitalGlitch;

    private bool isTriggered = false;

    private void Start()
    {
        if (glitchVolume != null && glitchVolume.profile != null)
        {
            glitchVolume.profile.TryGet(out analogGlitch);
            glitchVolume.profile.TryGet(out digitalGlitch);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isTriggered) return;

        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(TriggerGlitchTransition());
        }
    }

    private System.Collections.IEnumerator TriggerGlitchTransition()
    {
       
        if (analogGlitch != null)
        {
            analogGlitch.scanLineJitter.value = 0.8f;
            analogGlitch.verticalJump.value = 0.5f;
            analogGlitch.horizontalShake.value = 0.6f;
            analogGlitch.colorDrift.value = 0.9f;
        }

        if (digitalGlitch != null)
        {
            digitalGlitch.intensity.value = 0.85f;
        }

        
        yield return new WaitForSeconds(glitchDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}
