using UnityEngine;
using System.Collections;

public class PlayerTextView : MonoBehaviour
{
	[SerializeField]
	private Camera player1, player2;
	[SerializeField]
	private Transform follow;
	[SerializeField]
	private int number;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Transform look = null;
		int cameraNumber = 0;
		if(player1.gameObject.activeInHierarchy)
		{
			look = player1.transform;
			cameraNumber = 1;
		}
		else if(player2.gameObject.activeInHierarchy)
		{
			look = player2.transform;
			cameraNumber = 2;
		}

		if(look != null)
		{
			transform.LookAt(look);

			Vector3 euler = transform.eulerAngles;
			euler.x = euler.z = 0;
			euler.y += 90;
			transform.eulerAngles = euler;
			transform.position = follow.position + new Vector3(0, 2, 0);
		}
		if(cameraNumber == number)
		{
			for(int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				child.gameObject.SetActive(false);
			}
		}
		else
		{
			for(int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				child.gameObject.SetActive(true);
			}
		}
	}
}
