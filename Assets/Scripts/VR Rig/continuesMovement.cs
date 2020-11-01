using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
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

	private float gravity = -9.81f;
	private float fallingSpeed;

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

	private void FixedUpdate()
	{
		CapsuleFollowHeadset();

		//Gravity
		if (CheckIfGrounded())
			fallingSpeed = 0;
		else
			fallingSpeed += gravity * Time.fixedDeltaTime;

		VRRig.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
	}

	private bool CheckIfGrounded()
	{
		Vector3 rayStart = transform.TransformPoint(VRRig.center);
		float rayLength = VRRig.center.y + 0.01f;
		return Physics.SphereCast(rayStart, VRRig.radius, Vector3.down, out RaycastHit hitInfo, rayLength, ZombieModeManager.main.groundLayer);
	}

	private void CapsuleFollowHeadset()
	{
		VRRig.height = XRRig.cameraInRigSpaceHeight + 0.2f;
		Vector3 capsuleCenter = transform.InverseTransformPoint(XRRig.cameraGameObject.transform.position);
		VRRig.center = new Vector3(capsuleCenter.x, VRRig.height/2 + VRRig.skinWidth, capsuleCenter.z);
	}
}
