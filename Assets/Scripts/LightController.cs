using UnityEngine;

public class LightController : MonoBehaviour
{
    public Material materialWithEmission;
    public Light pointLight;
    public GameObject groundWire;
    public GameObject pinWire;

    private Color originalColor;
    private bool isLightOn = false;

    void Start()
    {
        if (materialWithEmission != null)
        {
            originalColor = materialWithEmission.GetColor("_EmissionColor");
            InvokeRepeating(nameof(ToggleLight), 2f, 1f);
        }
    }

    void ToggleLight()
    {
        bool areWiresActive = (groundWire != null && groundWire.activeSelf) && (pinWire != null && pinWire.activeSelf);

        if (areWiresActive)
        {
            if (!isLightOn)
            {
                TurnLightOn();
            } else
            {
                TurnLightOff();
            }
        }
        else
        {
            if (isLightOn)
            {
                TurnLightOff();
            }
        }
    }

    void TurnLightOn()
    {
        pointLight.enabled = true;
        if (materialWithEmission != null)
        {
            
            materialWithEmission.SetColor("_EmissionColor", originalColor);
        }
        isLightOn = true;
    }

    void TurnLightOff()
    {
        pointLight.enabled = false;
        if (materialWithEmission != null)
        {
            materialWithEmission.SetColor("_EmissionColor", Color.black);
        }
        isLightOn = false;
    }
}
