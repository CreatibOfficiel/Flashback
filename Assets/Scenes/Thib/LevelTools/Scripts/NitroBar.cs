using UnityEngine;
using UnityEngine.UI;

public class NitroBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public static NitroBar instance;

    float lerpSpeed;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a une double instance de NitroBar");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    private void Update()
    {
        lerpSpeed = 8f * Time.deltaTime;
    }

    public void setNitro(float nitro)
    {
        slider.value = Mathf.Lerp(slider.value, nitro, lerpSpeed);
    }

    public void resetSlider()
    {
        slider.value = 0;
    }
}

