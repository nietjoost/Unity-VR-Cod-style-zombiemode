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
	public string prefix;
	public Zones startZone;
	public int numberOfPlayers;
	public int startMoney;
	[SerializeField] private float startZombieModeDelay;
	public float timerBetweenRounds;

	[Header("Sounds")]
	[SerializeField] private AudioClip spawnSound;

	//Singleton objects
	[HideInInspector] public ZoneManager zone;
	[HideInInspector] public PlayerManager playerManager;
	[HideInInspector] public GameLogic gameLogic;

	//Other variables
	[HideInInspector] public GameObject[] playerSpawns;

	/// <summary>
	/// Awake for singleton
	/// </summary>
	private void Awake()
	{
		//Create a singleton
		if (main == null)
		{
			main = this;
		}
		else
		{
			Destroy(gameObject);
		}

		//Get player Spawns
		playerSpawns = GameObject.FindGameObjectsWithTag("Player spawn");

		//Stop Zombie Mode if the requirements are missing
		if(playerSpawns.Length == 0)
		{
			Debug.LogError(prefix + " Requirements for the mod to work are missing!");
			gameObject.SetActive(false);
			return;
		}

		//Load Singleton Objects
		zone = GetComponentInChildren<ZoneManager>();
		playerManager = GetComponentInChildren<PlayerManager>();
		gameLogic = GetComponentInChildren<GameLogic>();
	}

	/// <summary>
	/// Load all singleton objects and start the game with an delay
	/// </summary>
	private void Start()
	{
		//Start the zombie mode
		Invoke(nameof(StartZombieMode), startZombieModeDelay);
	}

	private void StartZombieMode()
	{
		//Spawn players in Scene
		//playerManager.SpawnPlayers(numberOfPlayers);

		//Start Game Logic
		gameLogic.StartRound1();
	}
}
