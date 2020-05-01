using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
	[SerializeField] private ListBonus _listBonus;
	[SerializeField] private Transform _parent;

	private GameObject _bonus;
	private RectTransform _planeSize;
	private TextInformation _timeText;
	private int _timePeriodInstantiate;
	private int _timePeriodDestroy;

	private void Start()
	{
		_timePeriodInstantiate = 0;
		_timePeriodDestroy = 1;
		_timeText = GameObject.Find("TextResult").GetComponent<TextInformation>();
	}

	private void Update()
	{
		InstantiateBonus();
	}

	private void InstantiateBonus()
	{
		DestroyBonus();
		if (_timePeriodInstantiate == _timeText.Minute)
		{
			_planeSize = GameObject.Find("Space").GetComponent<RectTransform>();
			float positionXBonus = Random.Range(-(_planeSize.sizeDelta.x / 2), _planeSize.sizeDelta.x / 2);
			float positionYBonus = Random.Range(-(_planeSize.sizeDelta.y / 2), _planeSize.sizeDelta.y / 2);
			_bonus = Instantiate(_listBonus.BonusList[Random.Range(0, 3)], _parent);
			_bonus.transform.position = new Vector3(positionXBonus, positionYBonus, 0f);
			AddForceBonus();
			_timePeriodInstantiate += 2;
		}
	}

	private void AddForceBonus()
	{
		float bonusForceX = Random.Range(-5f, 5f);
		float bonusForsceY = Random.Range(-5f, 5f);
		Vector3 vectorForce = new Vector3(bonusForceX, bonusForsceY);
		_bonus.GetComponent<Rigidbody>().AddForce(vectorForce * 70f);
	}

	private void DestroyBonus()
	{
		if (_timePeriodDestroy == _timeText.Minute)
		{
			Destroy(_bonus);
			_timePeriodDestroy += 2;
		}
	}

}
