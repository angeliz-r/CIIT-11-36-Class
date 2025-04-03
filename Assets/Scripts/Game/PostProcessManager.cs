using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    private Volume _globalVolume;

    Vignette vignetteSettings;

    // Start is called before the first frame update
    void Awake()
    {
        _globalVolume = GetComponent<Volume>();
        _globalVolume.profile.TryGet<Vignette>(out vignetteSettings);
    }

    public void SetDangerPostProcess(bool isInDanger)
    {
        if (isInDanger) //if life is in danger add vignette
        {
            vignetteSettings.intensity.value = 0.311f;
            vignetteSettings.smoothness.value = 0.557f;
            vignetteSettings.rounded.value = true;
        }
        else
        {
            vignetteSettings.intensity.value = 0f;
            vignetteSettings.smoothness.value = 0f;
            vignetteSettings.rounded.value = false;
        }
    }
}
