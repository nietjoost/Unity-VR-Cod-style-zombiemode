using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	/// <summary>
	/// Variables needed for player manager script
	/// </summary>
	[Header("Objects")]
	[SerializeField] private GameObject player;

	[HideInInspector] public List<GameObject> players = new List<GameObject>();

	/// <summary>
	/// Spawn players need for the game and add to list
	/// </summary>
	public void SpawnPlayers(int numberOfPlayers)
	{
		for(int i=0; i<numberOfPlayers; i++)
		{
			players.Add(Instantiate(player, transform));
		}
	}
}
