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
	public int playerSpeed;
	[SerializeField] private float startZombieModeDelay;
	public float timerBetweenRounds;

	[Header("Setup")]
	public LayerMask groundLayer;

	[Header("Objects")]
	public GameObject zombie;

	[Header("Sounds")]
	public AudioClip spawnSound;

	//Singleton objects
	[HideInInspector] public ZoneManager zone;
	[HideInInspector] public PlayersManager playerManager;
	[HideInInspector] public GameLogic gameLogic;
	[HideInInspector] public PlaySounds playSounds;

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

		//Load Singleton Objects
		zone = GetComponentInChildren<ZoneManager>();
		playerManager = GetComponentInChildren<PlayersManager>();
		gameLogic = GetComponentInChildren<GameLogic>();
		playSounds = GetComponentInChildren<PlaySounds>();
	}

	/// <summary>
	/// Load all singleton objects and start the game with an delay
	/// </summary>
	private void Start()
	{
		//Start the zombie mode
		playSounds.PlaySoundOnAllPlayers(spawnSound);
		Invoke(nameof(StartZombieMode), startZombieModeDelay);
	}

	private void StartZombieMode()
	{
		//Start Game Logic
		gameLogic.SetCanSpawnToTrue();
	}
}
