using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FmodPlayer : MonoBehaviour
{
	Transform player;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Player_Footsteps(string path)

	{
		FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
	}
}