using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Bolts : MonoBehaviour
{
	public float enemySpeed;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * enemySpeed;
	}
}
