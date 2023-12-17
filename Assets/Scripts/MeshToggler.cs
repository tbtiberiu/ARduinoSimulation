using UnityEngine;

public class MeshToggler : MonoBehaviour
{
    public GameObject gameObject;
    private bool isActive = true;

    public void Toggle() {
        isActive = !isActive;
        gameObject.SetActive(isActive);
    }
}
