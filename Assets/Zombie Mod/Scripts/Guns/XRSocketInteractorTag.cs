using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketInteractorTag : XRSocketInteractor
{
    public string targetName;

	public override bool CanSelect(XRBaseInteractable interactable)
	{
		return base.CanSelect(interactable) && interactable.name.Contains(targetName);
	}
}
