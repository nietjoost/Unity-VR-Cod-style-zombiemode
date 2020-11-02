using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
	/// <summary>
	/// Variables
	/// </summary>
	private Animator animator;
	private NavMeshAgent agent;
	private Vector3 target;

	private bool passedDebri;

	/// <summary>
	/// Get components
	/// </summary>
	private void Awake()
	{
		//Get components
		animator = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		//Set first taget
		target = transform.parent.GetComponent<ZombieSpawner>().GetDebriTransform().position;
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

		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Debri"))
		{
			target = GameObject.FindGameObjectWithTag("Player").transform.position;
			agent.SetDestination(target);
			return;
		}

		if (other.CompareTag("Player"))
		{
			animator.SetBool("idle_walk", false);
			agent.ResetPath();
		}
	}
}
