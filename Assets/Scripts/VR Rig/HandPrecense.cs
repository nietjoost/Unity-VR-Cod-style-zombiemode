using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPrecense : MonoBehaviour
{
    /// <summary>
	/// Variables
	/// </summary>
    public GameObject handModelPrefab;
    private GameObject spawnHandModel;

    /// <summary>
	/// Spawn hand model
	/// </summary>
    void Start()
    {
        spawnHandModel = Instantiate(handModelPrefab, transform);
    }

    
    void Update()
    {
        
    }
}
