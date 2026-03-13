using UnityEngine;
using TMPro;

public class FPScounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;

    void Start()
    {
        InvokeRepeating("Counter", 0f, 1f);
    }

    void Counter()
    {
        float fps = 1f/Time.deltaTime;
        fpsText.text = fps.ToString("F0");
    }
}
