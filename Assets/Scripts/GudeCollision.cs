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
		gude = new GudeInventory (renderer.material);
	}

	public void Capture()
	{
		if(parent != null)
		{
			parent.Add(gude);
			Destroy (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);
		if(rigidbody.velocity.magnitude < 0.2f)
		{
			rigidbody.rotation = Quaternion.identity;
		}
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
			if(inventory != null) parent = inventory;
		}
	}
	
	public GudeInventory Gude
	{
		get
		{
			return gude;
		}
		set
		{
			gude = value;
			renderer.material = gude.Material;
		}
	}
}
