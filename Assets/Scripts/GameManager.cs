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
	
	}

	void OnTriggerExit(Collider c)
	{
		if(c.gameObject.layer == 8)
		{
			if(turnManager.rounds % 2 == 1)
				player1.Add(new GudeInventory(c.renderer.material.mainTexture));
			if(turnManager.rounds % 2 == 0)
				player2.Add(new GudeInventory(c.renderer.material.mainTexture));
			c.gameObject.SetActive(false);
		} 
	}
}
