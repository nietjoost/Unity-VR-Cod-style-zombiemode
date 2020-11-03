using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	private int currentRound = 1;
	private bool canSpawn = false;

	private ZombieSpawnCalculator zsc;

	private float currentTime;

	public int currentSpawnedZombies = 0;
	public int currentDeadZombies = 0;

	/// <summary>
	/// Initialize zombie calculator
	/// </summary>
	private void Start()
	{
		zsc = new ZombieSpawnCalculator();
	}

	/// <summary>
	/// Only Update function for game logic
	/// </summary>
	private void FixedUpdate()
	{
		if (canSpawn)
		{
			//Spawn zombie after few seconds
			currentTime += Time.deltaTime;

			if (currentTime > zsc.betweenZombieTime)
			{
				currentTime = 0;
				//Spawn zombie
				if (currentSpawnedZombies < zsc.GetCalculatedZombieCount())
				{
					SpawnZombie();
				}
			}

			//Next round calculator
			if(currentDeadZombies == zsc.GetCalculatedZombieCount())
			{
				NextRound();
			}
		}
	}

	/// <summary>
	/// Next round Logic
	/// </summary>
	private void NextRound()
	{
		//Reset update script for next round
		canSpawn = false;
		currentTime = 0;
		currentSpawnedZombies = 0;
		currentDeadZombies = 0;

		//Set new current round
		currentRound++;

		//Calculate next zombie count
		zsc.NextRoundCalculate();

		Debug.Log("Start round " + currentRound + " + with " + zsc.GetCalculatedZombieCount() + " zombies!");

		//Start new round
		ZombieModeManager.main.playSounds.PlaySoundOnAllPlayers(ZombieModeManager.main.spawnSound);
		ZombieModeManager.main.playerManager.SetNextRoundOnUI(currentRound);
		Invoke(nameof(SetCanSpawnToTrue), ZombieModeManager.main.timerBetweenRounds);
	}

	/// <summary>
	/// Only to set the variable canSpawn to true
	/// </summary>
	public void SetCanSpawnToTrue()
	{
		canSpawn = true;
	}

	/// <summary>
	/// Spawn zombie Logic
	/// </summary>
	private void SpawnZombie()
	{
		currentSpawnedZombies++;

		//Get available spawners
		List<ZombieSpawner> spawners = getAvailableSpawners();

		//Get random spawner to spawn zombie
		spawners[Random.Range(0, spawners.Count)].SpawnZombie();
	}

	/// <summary>
	/// Get all zombie spawners in active zones
	/// </summary>
	private List<ZombieSpawner> getAvailableSpawners()
	{
		List<ZombieSpawner> local = new List<ZombieSpawner>();
		foreach(ZombieSpawner zs in ZombieModeManager.main.zone.zombieSpawners)
		{
			if(ZombieModeManager.main.zone.openZones.Contains(zs.zone))
			{
				local.Add(zs);
			}
		}
		return local;
	}
}
