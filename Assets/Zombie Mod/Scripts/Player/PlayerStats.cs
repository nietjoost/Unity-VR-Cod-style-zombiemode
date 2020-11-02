using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	public int currentMoney;

	public PlayerUI ui;

	private void Start()
	{
		currentMoney = ZombieModeManager.main.startMoney;

		ui.SetMoney(currentMoney);
		ui.SetRound(1);
	}

	public void NextRound(int round)
	{
		ui.SetRound(round);
	}
}
