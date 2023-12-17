using UnityEngine;
using UnityEngine.UI;

public class ChangeColorBasedOnActiveState : MonoBehaviour
{
    public Button buttonElement;
    public Color activeColor;
    public Color activeColorDark;
    public Color inactiveColor;
    public Color inactiveColorDark;

    public void SetColors(bool isActive)
    {
        ColorBlock colorBlock = buttonElement.colors;
        colorBlock.normalColor = isActive ? activeColor : inactiveColor;
        colorBlock.highlightedColor = isActive ? activeColor : inactiveColor;
        colorBlock.pressedColor = isActive ? activeColorDark : inactiveColorDark;
        colorBlock.selectedColor = isActive ? activeColor : inactiveColor;
        colorBlock.disabledColor = isActive ? activeColorDark : inactiveColorDark;
        buttonElement.colors = colorBlock;
    }
}