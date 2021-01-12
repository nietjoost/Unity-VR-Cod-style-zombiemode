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
	public int currentHealth;

	public PlayerUI ui;

	private void Start()
	{
		currentMoney = ZombieModeManager.main.startMoney;
		currentHealth = ZombieModeManager.main.startHealth;

		ui.SetMoney(currentMoney);
		ui.SetRound(1);
		ui.SetHealth(currentHealth);
	}

	public void NextRound(int round)
	{
		ui.SetRound(round);
		ui.SetMoney(currentMoney);
	}

	public void AddMoney(int money)
	{
		currentMoney += money;
		ui.SetMoney(currentMoney);
	}

	public void RemoveMoney(int money)
	{
		currentMoney -= money;
		ui.SetMoney(currentMoney);
	}

	public void AddHealth(int health)
	{
		currentHealth += health;
		ui.SetHealth(currentHealth);
	}

	public void RemoveHealth(int health)
	{
		currentHealth -= health;
		ui.SetHealth(currentHealth);
	}
}
