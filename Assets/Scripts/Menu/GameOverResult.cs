using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverResult : MonoBehaviour
{
	[SerializeField] private TextInformation _gameOverResultt;
	[SerializeField] private Text _endResult;

	private void Start()
	{
		_endResult.text = "Score : " + _gameOverResultt.NumScore + "Time " + _gameOverResultt.Hour + " : " + _gameOverResultt.Minute + " : " + _gameOverResultt.Second;
		_gameOverResultt.LifeShip = 3;
	}
}
