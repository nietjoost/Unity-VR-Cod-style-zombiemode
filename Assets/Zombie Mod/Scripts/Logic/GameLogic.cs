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

	private int currentSpawnedZombies = 0;

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
			currentTime += Time.deltaTime;

			if (currentTime > zsc.betweenZombieTime)
			{
				currentTime = 0;

				if (currentSpawnedZombies < zsc.GetCalculatedZombieCount())
				{
					SpawnZombie();
				}
				else
				{
					NextRound();
				}
			}
		}
	}

	public void StartRound1()
	{
		canSpawn = true;

		zsc.GetCalculatedZombieCount();
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

		//Set new current round
		currentRound++;

		//Calculate next zombie count
		zsc.NextRoundCalculate();

		Debug.Log("Start round " + currentRound + " + with " + zsc.GetCalculatedZombieCount() + " zombies!");

		//Start new round
		ZombieModeManager.main.playSounds.PlaySoundOnAllPlayers(ZombieModeManager.main.spawnSound);
		Invoke(nameof(SetCanSpawnToTrue), ZombieModeManager.main.timerBetweenRounds);
	}

	/// <summary>
	/// Only to set the variable canSpawn to true
	/// </summary>
	private void SetCanSpawnToTrue()
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
		ZombieSpawner[] spawners = getAvailableSpawners();

		//Get random spawner to spawn zombie
		spawners[Random.Range(0, spawners.Length)].SpawnZombie();
	}

	private ZombieSpawner[] getAvailableSpawners()
	{
		return ZombieModeManager.main.zone.zombieSpawners.Values.ToArray();
	}
}
