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
    Dictionary<Zones, ZombieSpawner> zombieSpawner = new Dictionary<Zones, ZombieSpawner>();

    /// <summary>
	/// Add a zombie spawner to a zone
	/// </summary>
    public void AddSpawnerToZone(Zones zone, ZombieSpawner zs)
	{
        zombieSpawner.Add(zone, zs);
	}
}
