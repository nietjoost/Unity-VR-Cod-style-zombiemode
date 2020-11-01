using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class continuesMovement : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	[Header("Settings")]
	public AxisHandler2D inputAxisController;

	/// <summary>
	/// Onenable and Disable controller input event
	/// </summary>
	public void OnEnable()
	{
		inputAxisController.OnValueChange += SetAxisMovement;
	}

	public void OnDisable()
	{
		inputAxisController.OnValueChange -= SetAxisMovement;
	}

	private void Update()
	{
		
	}

	private void SetAxisMovement(XRController controller, Vector2 axis)
	{
		Debug.Log(axis);
	}
}
