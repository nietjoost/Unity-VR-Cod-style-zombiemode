using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieModeManager : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	public static ZombieModeManager main { get; private set; }

	[Header("Settings")]
	[SerializeField] private int numberOfPlayers;
	[SerializeField] private float startZombieModeDelay;

	[Header("Sounds")]
	[SerializeField] private AudioClip spawnSound;

	//Singleton objects
	public ZoneManager zone;
	public PlayerManager playerManager;

	/// <summary>
	/// Awake for singleton
	/// </summary>
	private void Awake()
	{
		if(main == null)
		{
			main = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Load all singleton objects and start the game with an delay
	/// </summary>
	private void Start()
	{
		//Load Singleton Objects
		zone = GetComponentInChildren<ZoneManager>();
		playerManager = GetComponentInChildren<PlayerManager>();

		//Start the zombie mode
		Invoke(nameof(StartZombieMode), startZombieModeDelay);
	}

	private void StartZombieMode()
	{
		playerManager.SpawnPlayers(numberOfPlayers);
	}
}
