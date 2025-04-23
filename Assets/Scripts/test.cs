using UnityEngine;
using UnityEngine.Rendering;

public class GlitchInspector : MonoBehaviour
{
    public Volume volume;

    void Start()
    {
        if (volume != null && volume.profile != null)
        {
            foreach (var component in volume.profile.components)
            {
                Debug.Log("Volume Override: " + component.name + " | Type: " + component.GetType());
            }
        }
    }
}
