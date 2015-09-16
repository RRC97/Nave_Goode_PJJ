using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoverManager : MonoBehaviour
{
	[SerializeField]
	private Text text;
	void Awake ()
	{
		Time.timeScale = 1;
		Screen.showCursor = true;
		Screen.lockCursor = false;
	}
	void Update ()
	{
		if(GameManager.Winner == 1)
			text.text = "Player 1 wins!";
		if(GameManager.Winner == 2)
			text.text = "Player 2 wins!";
	}
}
