using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
	/// <summary>
	/// Variables needed for player manager script
	/// </summary>
	private GameObject player;
	private PlayerStats stats;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = player.GetComponent<PlayerStats>();
	}

	/// <summary>
	/// Set current round on UI
	/// </summary>
	public void SetNextRoundOnUI(int round)
	{
		stats.NextRound(round);
	}
}
