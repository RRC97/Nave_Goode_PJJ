using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	private Inventory player1, player2;
	[SerializeField]
	private TurnManager turnManager;
	[SerializeField]
	private List<GudeCollision> gudesPlayer1, gudesPlayer2;
	private bool player1InCircle,player2InCircle;
	private static int winner;
	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
		gudesPlayer1 = new List<GudeCollision> ();
		gudesPlayer2 = new List<GudeCollision> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.FindObjectsOfType (typeof(GudeCollision)).Length <= 0)
		{
			if(player1.Count > player2.Count)
				winner = 1;
			else if(player2.Count > player1.Count)
				winner = 2;
			Application.LoadLevel("GOVER");
		}

		if(!player1InCircle)
		{
			foreach(GudeCollision gude in gudesPlayer1)
			{
				gude.Capture();
				gudesPlayer1.Remove(gude);
				break;
			}
		}
		if(!player2InCircle)
		{
			foreach(GudeCollision gude in gudesPlayer2)
			{
				gude.Capture();
				gudesPlayer2.Remove(gude);
				break;
			}
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.layer == 10)
		{
			if(c.GetComponent<GudeManager>().Inventory == player1)
			{
				player1InCircle = true;
			}
			
			if(c.GetComponent<GudeManager>().Inventory == player2)
			{
				player2InCircle = true;
			}
		}
	}

	void OnTriggerStay(Collider c)
	{
		if(c.gameObject.layer == 10)
		{
			if(c.GetComponent<GudeManager>().Inventory == player1
			&& !c.GetComponent<GudeManager>().IsPlay && player1InCircle)
			{
				if(gudesPlayer1.Count > 0)
				{
					Vector3 position = c.transform.position;
					c.transform.position = gudesPlayer1[0].transform.position;
					gudesPlayer1[0].transform.position = position;
					
					Vector3 velocity = c.rigidbody.velocity;
					c.rigidbody.velocity = gudesPlayer1[0].rigidbody.velocity;
					gudesPlayer1[0].rigidbody.velocity = velocity;
					
					Vector3 euler = c.transform.eulerAngles;
					c.transform.eulerAngles = gudesPlayer1[0].transform.eulerAngles;
					gudesPlayer1[0].transform.eulerAngles = euler;
					
					GudeInventory gude = c.GetComponent<GudeManager>().Gude;
					c.GetComponent<GudeManager>().Gude = gudesPlayer1[0].Gude;
					gudesPlayer1[0].Gude = gude;
					
					gudesPlayer1.Remove(gudesPlayer1[0]);
				}
				else if(player1.Count > 0)
				{
					GameObject gudeOff = (GameObject)Instantiate(Resources.Load ("GudeOff"));
					GudeManager gude = c.GetComponent<GudeManager>();
					gudeOff.transform.position = gude.transform.position;
					gudeOff.GetComponent<GudeCollision>().Gude = gude.Gude;
					gude.Reset();
					gude.Gude = player1.Get(0);
					player1.Remove(gude.Gude);

					Vector3 velocity = c.rigidbody.velocity;
					c.rigidbody.velocity = gudeOff.rigidbody.velocity;
					gudeOff.rigidbody.velocity = velocity;
				}
				else
				{
					winner = 2;
					Application.LoadLevel("GOVER");
				}
			}

			
			if(c.GetComponent<GudeManager>().Inventory == player2
		   	&& !c.GetComponent<GudeManager>().IsPlay && player2InCircle)
			{
				if(gudesPlayer2.Count > 0)
				{
					Vector3 position = c.transform.position;
					c.transform.position = gudesPlayer2[0].transform.position;
					gudesPlayer2[0].transform.position = position;
					
					Vector3 velocity = c.rigidbody.velocity;
					c.rigidbody.velocity = gudesPlayer2[0].rigidbody.velocity;
					gudesPlayer2[0].rigidbody.velocity = velocity;
					
					Vector3 euler = c.transform.eulerAngles;
					c.transform.eulerAngles = gudesPlayer2[0].transform.eulerAngles;
					gudesPlayer2[0].transform.eulerAngles = euler;

					GudeInventory gude = c.GetComponent<GudeManager>().Gude;
					c.GetComponent<GudeManager>().Gude = gudesPlayer2[0].Gude;
					gudesPlayer2[0].Gude = gude;

					gudesPlayer2.Remove(gudesPlayer2[0]);
				}
				else if(player2.Count > 0)
				{
					GameObject gudeOff = (GameObject)Instantiate(Resources.Load ("GudeOff"));
					GudeManager gude = c.GetComponent<GudeManager>();
					gudeOff.transform.position = gude.transform.position;
					gudeOff.GetComponent<GudeCollision>().Gude = gude.Gude;
					gude.Reset();
					gude.Gude = player2.Get(0);
					player2.Remove(gude.Gude);
					
					Vector3 velocity = c.rigidbody.velocity;
					c.rigidbody.velocity = gudeOff.rigidbody.velocity;
					gudeOff.rigidbody.velocity = velocity;
				}
				else
				{
					winner = 1;
					Application.LoadLevel("GOVER");
				}
			}
		}
	}
	void OnTriggerExit(Collider c)
	{
		if(c.gameObject.layer == 8)
		{
			if(c.GetComponent<GudeCollision>().Parent == player1)
			{
				gudesPlayer1.Add(c.GetComponent<GudeCollision>());
			}
			if(c.GetComponent<GudeCollision>().Parent == player2)
			{
				gudesPlayer2.Add(c.GetComponent<GudeCollision>());
			}
		}
		
		if(c.gameObject.layer == 10)
		{
			if(c.GetComponent<GudeManager>().Inventory == player1)
			{
				player1InCircle = false;
				print ("Player 1 se salvou");
			}
			
			if(c.GetComponent<GudeManager>().Inventory == player2)
			{
				player2InCircle = false;
				print ("Player 2 se salvou");
			}
		}
	}
	public static int Winner
	{
		get
		{
			return winner;
		}
	}
}
