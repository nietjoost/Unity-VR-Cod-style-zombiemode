using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{
	public void PlaySoundOnAllPlayers(AudioClip clip)
	{
		foreach(GameObject p in GameObject.FindGameObjectsWithTag("Player"))
		{
			AudioSource local = p.GetComponent<AudioSource>();
			local.clip = clip;
			local.Play();
		}
	}

	public void PlaySoundOnPlayer(AudioClip clip, GameObject player)
	{
		AudioSource local = player.GetComponent<AudioSource>();
		local.clip = clip;
		local.Play();
	}
}
