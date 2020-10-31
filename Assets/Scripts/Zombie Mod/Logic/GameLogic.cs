using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	private int currentRound;
	private bool canSpawn = false;

	private void Update()
	{
		if(canSpawn)
		{

		}
	}

	/// <summary>
	/// Next round Logic
	/// </summary>
	private void NextRound()
	{
		canSpawn = false;

		currentRound++;

		Invoke(nameof(SetCanSpawnToTrue), ZombieModeManager.main.timerBetweenRounds);
	}

	/// <summary>
	/// Only to set the variable canSpawn to true
	/// </summary>
	private void SetCanSpawnToTrue()
	{
		canSpawn = true;
	}
}
