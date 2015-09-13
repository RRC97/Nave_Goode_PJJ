using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private Inventory player1, player2;
	[SerializeField]
	private TurnManager turnManager;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.FindObjectsOfType (typeof(GudeCollision)).Length <= 0)
			print (1);
	}

	void OnTriggerExit(Collider c)
	{
		if(c.gameObject.layer == 8)
		{
			c.GetComponent<GudeCollision>().Capture();
		} 
	}
}
