using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUIController : MonoBehaviour
{

    public UIDocument main;
    public bool isButtonGreen = false;

    Button myButton;

    void Start()
    {
        VisualElement root = main.rootVisualElement;
        myButton = root.Q<Button>("MyButton");
        myButton.RegisterCallback<ClickEvent>(OnClick);
    }

    private void OnClick(ClickEvent ev)
    {
        isButtonGreen = !isButtonGreen;
        myButton.EnableInClassList(MainStyle.green, isButtonGreen);
    }

    private void OnDestroy()
    {
        myButton.UnregisterCallback<ClickEvent>(OnClick);
    }
}
