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
		rounds = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(rounds % 2 == 1)
			player1.Time ();
		if(rounds % 2 == 0)
			player2.Time ();

		if (!player1.IsPlaying && !player2.IsPlaying)
			rounds++;
	}
}
