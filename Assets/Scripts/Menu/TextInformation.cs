using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInformation : MonoBehaviour
{
	public Text ScoreText;
	public int Minute;
	public int LifeShip = 3;
	public int NumScore = 0;
	public float Second = 0;
	public int Hour;


	private void Update()
	{
		TimeController();
		ScoreText.text = "Score : " + NumScore + "\nTime " + Hour + " : " + Minute + " : " + Second+"\nLife "+ LifeShip;
	}

	private void TimeController()
	{
		Second += 1*Time.deltaTime;
		if (Second >= 60)
		{
			Minute += 1;
			Second = 0;
		}
		if (Minute == 60)
		{
			Hour += 1;
			Minute = 0;
		}
	}
		
}
