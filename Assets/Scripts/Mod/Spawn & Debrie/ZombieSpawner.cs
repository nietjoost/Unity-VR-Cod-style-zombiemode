using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	[Header("Settings")]
	[SerializeField] private Zones zone;
	[SerializeField] private GameObject debri;

	private Debri debriScript;

	/// <summary>
	/// If there is no debri, cant use 
	/// </summary>
	private void Start()
	{
		//If no debri, disable spawner
		if (debri == null)
		{
			gameObject.SetActive(false);
			return;
		}

		//Add spawner to zones
		ZombieModeManager.main.zone.AddSpawnerToZone(zone, this);
	}
}
