using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstatiateShip : MonoBehaviour
{
	[SerializeField] private GameObject _ship;
	[SerializeField] private Transform _parent;

	private TextInformation _life;

	private void Start()
	{
		_life = GameObject.Find("TextResult").GetComponent<TextInformation>();
	}

	private void Update()
	{
		InstantiateShip();
	}

	private void InstantiateShip()
	{
		if (_life.LifeShip > 0 && GameObject.Find("Ship(Clone)") == false && GameObject.Find("ZoneStart").GetComponent<TriggerZoneStart>().ZoneStart)
		{
			GameObject newShip = Instantiate(_ship, _parent);
			newShip.transform.position = new Vector3(0f, 0f, -1f);
		}
	}


}
