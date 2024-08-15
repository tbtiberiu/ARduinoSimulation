using UnityEngine;

public class MeshToggler : MonoBehaviour
{
    public GameObject targetObject;
    private bool isActive = false;

    void Start()
    {
        if (targetObject != null)
        {
            isActive = targetObject.activeSelf;
            targetObject.GetComponent<ChangeColorBasedOnActiveState>().SetColors(isActive);
        }
    }

    public void Toggle()
    {
        isActive = !isActive;
        targetObject.SetActive(isActive);
        targetObject.GetComponent<ChangeColorBasedOnActiveState>().SetColors(isActive);
    }
}
