using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	/// <summary>
	/// Add a zombie spawner to a zone
	/// </summary>
	[Header("Settings")]
	[SerializeField] private Zones zoneComingFrom;
	[SerializeField] private Zones zoneGoingTo;
	public int doorPrice;

	/// <summary>
	/// Disable door if the two zones have the same zone
	/// </summary>
	private void Start()
	{
		if(zoneComingFrom.Equals(zoneGoingTo))
		{
			Debug.LogError(ZombieModeManager.main.prefix + " Door " + gameObject.name + " has the same zones. Change the zones to the correct zone to enable this door.");
			gameObject.SetActive(false);
			return;
		}

		if (doorPrice == 0)
			Debug.LogWarning(ZombieModeManager.main.prefix + " Door " + gameObject.name + " has a door price of 0");
	}

	/// <summary>
	/// Open door and add zones to openZones and start animation
	/// </summary>
	public void OpenDoor()
	{
		//Add zones to open zones
		ZombieModeManager.main.zone.AddZoneToOpenZones(zoneComingFrom);
		ZombieModeManager.main.zone.AddZoneToOpenZones(zoneGoingTo);

		//Start door animation
		//TO-DO
	}	
}
