using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnCalculator
{
	/// <summary>
	/// Start variables
	/// </summary>
	public float betweenZombieTime = 8f;
	public int zombieCount = 5 + ZombieModeManager.main.numberOfPlayers;

	public int GetCalculatedZombieCount()
	{
		return zombieCount;
	}

	public void NextRoundCalculate()
	{
		zombieCount += ZombieModeManager.main.numberOfPlayers;

		betweenZombieTime -= 0.5f;
	}
}
