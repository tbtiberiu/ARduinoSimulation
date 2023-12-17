using UnityEngine;

public class MeshToggler : MonoBehaviour
{
    public GameObject gameObject;
    private bool isActive = false;

    void Start()
    {
        if (gameObject != null)
        {
            isActive = gameObject.activeSelf;
            gameObject.GetComponent<ChangeColorBasedOnActiveState>().SetColors(isActive);
        }
    }

    public void Toggle() {
        isActive = !isActive;
        gameObject.SetActive(isActive);
        gameObject.GetComponent<ChangeColorBasedOnActiveState>().SetColors(isActive);
    }
}
