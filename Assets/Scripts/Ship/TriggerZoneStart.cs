using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneStart : MonoBehaviour
{
	public bool ZoneStart = true;

	private void Start()
	{
		GameObject.Find("GamePanel(Clone)").GetComponent<InstatiateShip>();
	}

	private void OnTriggerStay(Collider other)
	{
		ZoneStart = false;
	}

	private void OnTriggerExit(Collider other)
	{
		ZoneStart = true;
	}
}
