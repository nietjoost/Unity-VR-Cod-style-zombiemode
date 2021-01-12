using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of usable zones
/// </summary>
public enum Zones
{
    One,
    Two,
    Three,
    Four,
    Five
}

public class ZoneManager : MonoBehaviour
{
    /// <summary>
	/// Variables
	/// </summary>
    public HashSet<ZombieSpawner> zombieSpawners = new HashSet<ZombieSpawner>();
    public HashSet<Zones> openZones = new HashSet<Zones>();

	/// <summary>
	/// On start add zone to the open zones, otherwise there will be no zone to start with
	/// </summary>
	private void Start()
	{
		openZones.Add(ZombieModeManager.main.startZone);
	}

	/// <summary>
	/// Add a zombie spawner to a zone
	/// </summary>
	public void AddSpawnerToZone(ZombieSpawner zs)
	{
        zombieSpawners.Add(zs);
	}

	/// <summary>
	/// Add a zone to openZones
	/// </summary>
	public void AddZoneToOpenZones(Zones addZone)
	{
		openZones.Add(addZone);
	}

	/// <summary>
	/// Remove a zone to openZones
	/// </summary>
	public void RemoveZoneToOpenZones(Zones removeZone)
	{
		openZones.Remove(removeZone);
	}
}
