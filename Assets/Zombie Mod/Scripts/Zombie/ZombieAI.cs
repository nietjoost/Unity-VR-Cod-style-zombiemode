using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class ZombieAI : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	private Animator animator;
	private NavMeshAgent agent;
	private Vector3 target;

	private bool passedDebri = false, iddle = false;

	/// <summary>
	/// Get components
	/// </summary>
	private void Awake()
	{
		//Get components
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		//Set first taget
		if (transform.parent.GetComponent<ZombieSpawner>().debri != null)
			target = transform.parent.GetComponent<ZombieSpawner>().GetDebriTransform().position;
		else
			target = GetClosestPlayer();

		agent.SetDestination(target);
	}

	/// <summary>
	/// Set start animation
	/// </summary>
	private void Start()
	{
		animator.SetBool("idle_walk", true);
	}

	/// <summary>
	/// Zombie AI logic
	/// </summary>
	private void FixedUpdate()
	{
		//Look at target
		Vector3 relativePos = target - transform.position;

		// the second argument, upwards, defaults to Vector3.up
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
		transform.rotation = rotation;

		if(passedDebri && !iddle)
		{
			agent.SetDestination(GetClosestPlayer());
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Bullet"))
		{
			ZombieModeManager.main.gameLogic.currentDeadZombies++;
			Destroy(other.gameObject);
			GetComponent<AudioSource>().Stop();
			Destroy(gameObject);
			return;
		}

		if (other.CompareTag("Debri"))
		{
			passedDebri = true;
			return;
		}

		if (other.CompareTag("Player"))
		{
			animator.SetBool("idle_walk", false);
			animator.SetBool("idle_attack", true);

			iddle = true;
			agent.ResetPath();
			other.GetComponent<PlayerStats>().RemoveHealth(45);
			return;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			iddle = false;
			animator.SetBool("idle_attack", false);
			animator.SetBool("idle_walk", true);
			agent.SetDestination(GetClosestPlayer());
		}
	}

	private Vector3 GetClosestPlayer()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform.position;
		return target;
	}


}