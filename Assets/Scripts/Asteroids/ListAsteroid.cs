using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "List", menuName = "ListAsteroid/List")]
public class ListAsteroid : ScriptableObject
{
	public List<GameObject> AsteroidList;
}
