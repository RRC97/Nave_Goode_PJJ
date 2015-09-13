using UnityEngine;
using System.Collections;

public class GudeCollision : MonoBehaviour
{
	private Inventory parent;
	public Inventory Parent
	{
		get
		{
			return parent;
		}
	}
	private GudeInventory gude;
	void Awake()
	{
		gude = new GudeInventory (renderer.material.mainTexture);
	}

	public void Capture()
	{
		if(parent != null)
		{
			parent.Add(gude);
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.layer == 10)
		{
			parent = c.gameObject.GetComponent<GudeManager> ().Inventory;
		}
		if (c.gameObject.layer == 8)
		{
			Inventory inventory = c.gameObject.GetComponent<GudeCollision> ().Parent;
			if(inventory) parent = inventory;
		}
	}
}
