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

	private CharacterController VRRig;
	private XRRig XRRig;

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

	/// <summary>
	/// Get needed components
	/// </summary>
	private void Awake()
	{
		XRRig = GetComponent<XRRig>();
		VRRig = GetComponent<CharacterController>();
	}

	/// <summary>
	/// Controller input and move current VRRig
	/// </summary>
	private void SetAxisMovement(XRController controller, Vector2 axis)
	{
		Quaternion headYaw = Quaternion.Euler(0, XRRig.cameraGameObject.transform.eulerAngles.y, 0);
		Vector3 direction = headYaw * new Vector3(axis.x, 0, axis.y);
		VRRig.Move(direction * Time.fixedDeltaTime * ZombieModeManager.main.playerSpeed);
	}
}
