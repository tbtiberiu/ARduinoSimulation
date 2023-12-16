using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_script : MonoBehaviour
{
    public Material materialWithEmission;
    public Light pointLight;

    private bool isLightOn = false;

    void Start()
    {
        // Ensure the point light is initially off
        pointLight.enabled = false;

        // Ensure emission is initially turned off
        if (materialWithEmission != null)
        {
            Color initialColor = materialWithEmission.GetColor("_EmissionColor");
            materialWithEmission.SetColor("_EmissionColor", Color.black);
        }
    }

    void Update()
    {
        // Toggle the light on/off when spacebar is pressed
        if (Input.touchCount > 0)
        {
            isLightOn = !isLightOn;

            if (isLightOn)
            {
                TurnLightOn();
            }
            else
            {
                TurnLightOff();
            }
        }
    }

    void TurnLightOn()
    {
        // Enable the point light
        pointLight.enabled = true;

        // Enable emission by setting emission color to original color
        if (materialWithEmission != null)
        {
            Color originalColor = materialWithEmission.GetColor("_EmissionColor");
            materialWithEmission.SetColor("_EmissionColor", originalColor);
        }
    }

    void TurnLightOff()
    {
        // Disable the point light
        pointLight.enabled = false;

        // Disable emission by setting emission color to black
        if (materialWithEmission != null)
        {
            materialWithEmission.SetColor("_EmissionColor", Color.black);
        }
    }
}
