using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	[Header("Settings")]
	public Zones zone;
	public GameObject debri;

	private Debri debriScript;

	/// <summary>
	/// If there is no debri, cant use 
	/// </summary>
	private void Start()
	{
		//If no debri, disable spawner
		/*if (debri == null || !debri.GetComponent<Debri>())
		{
			gameObject.SetActive(false);
			Debug.LogError(ZombieModeManager.main.prefix + " Spawner " + gameObject.name + " is missing settings! Spawner will be disabled.");
			return;
		}*/

		//Add spawner to zones
		ZombieModeManager.main.zone.AddSpawnerToZone(this);

		debriScript = GetComponent<Debri>();
	}

	/// <summary>
	/// Spawn zombie by zombie spawner
	/// </summary>
	public void SpawnZombie()
	{
		GameObject zom = Instantiate(ZombieModeManager.main.zombie, transform);
		zom.GetComponent<ZombieAI>().SetHealth(ZombieModeManager.main.gameLogic.zombieHealth);
	}

	/// <summary>
	/// Get debri transform for first zombie target
	/// </summary>
	public Transform GetDebriTransform()
	{
		return debri.transform;
	}
}
