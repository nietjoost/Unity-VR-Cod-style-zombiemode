using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour
{
    public ButtonHandler primaryAxisClickHandler = null;
    public ButtonHandler primaryButtonHandler = null;
    public AxisHandler2D primaryAxisHandler = null;
    public AxisHandler triggerHandler = null;
    public ButtonHandler gripHandler = null;


    public void OnEnable()
    {
        primaryAxisClickHandler.OnButtonDown += PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp += PrintPrimaryButtonUp;
        primaryButtonHandler.OnButtonDown += PrintPrimaryButtonDown;
        primaryButtonHandler.OnButtonUp += PrintPrimaryButtonUp;
        primaryAxisHandler.OnValueChange += PrintPrimaryAxis;
        triggerHandler.OnValueChange += PrintTrigger;
        gripHandler.OnButtonDown += PrintGripButtonDown;
        gripHandler.OnButtonUp += PrintGripButtonUp;
    }

    public void OnDisable()
    {
        primaryAxisClickHandler.OnButtonDown -= PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp -= PrintPrimaryButtonUp;
        primaryButtonHandler.OnButtonDown -= PrintPrimaryButtonDown;
        primaryButtonHandler.OnButtonUp -= PrintPrimaryButtonUp;
        primaryAxisHandler.OnValueChange -= PrintPrimaryAxis;
        triggerHandler.OnValueChange -= PrintTrigger;
        gripHandler.OnButtonDown -= PrintGripButtonDown;
        gripHandler.OnButtonUp -= PrintGripButtonUp;
    }

    private void PrintPrimaryButtonDown(XRController controller)
    {
        print("Primary button down");
    }

    private void PrintPrimaryButtonUp(XRController controller)
    {
        print("Primary button up");
    }

    private void PrintPrimaryAxis(XRController controller, Vector2 value)
    {
        print("Primary axis:" + value);
    }

    private void PrintTrigger(XRController controller, float value)
    {
        print("Trigger: " + value);
    }

    private void PrintGripButtonDown(XRController controller)
    {
        print("Grip button down");
    }

    private void PrintGripButtonUp(XRController controller)
    {
        print("Grip button up");
    }
}
