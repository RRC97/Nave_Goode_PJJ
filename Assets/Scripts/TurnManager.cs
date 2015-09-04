using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
	[SerializeField]
	private PlayerController player1, player2;
	private int rounds;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (!player1.IsPlaying && !player2.IsPlaying)
			rounds++;

		if(rounds % 2 == 1)
			player1.Play();
		if(rounds % 2 == 0)
			player2.Play();
	}
}
