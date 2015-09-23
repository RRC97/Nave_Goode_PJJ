using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnManager : MonoBehaviour
{
	[SerializeField]
	private PlayerController player1, player2;

	[SerializeField]
	private Text countPlayer1, countPlayer2;
	public int rounds;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (!player1.IsPlaying && !player2.IsPlaying)
			rounds++;

		if(player1.IsPlaying)
		{
			countPlayer1.color = Color.red;
			countPlayer2.color = Color.black;
		}
		else if(player2.IsPlaying)
		{
			countPlayer2.color = Color.red;
			countPlayer1.color = Color.black;
		}

		if(rounds % 2 == 1)
			player1.Play();
		if(rounds % 2 == 0)
			player2.Play();
	}
}
