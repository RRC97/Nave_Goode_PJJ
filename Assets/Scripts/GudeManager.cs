using UnityEngine;
using System.Collections;

public class GudeManager : MonoBehaviour
{
	[SerializeField]
	private bool isPlay;
	[SerializeField]
	private CameraLookController look;
	[SerializeField]
	private Inventory inventory;
	private float time;
	private GudeInventory gude;
	private Vector3 lastPosition;
	void Awake()
	{
		gude = new GudeInventory (renderer.material);
	}
	void FixedUpdate ()
	{
		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);
	}
	void Update ()
	{
		if (isPlay && time > 2f && rigidbody.velocity.magnitude < 0.2f)
		{
			isPlay = false;
			time = 0;
		}
		
		look.gameObject.SetActive(isPlay);

		if (isPlay)
		{
			time += Time.deltaTime;
		}
	}
	public bool IsPlay
	{
		get{ return isPlay;}
	}
	
	public Inventory Inventory
	{
		get
		{
			return inventory;
		}
	}
	public void Play(Vector3 r, float f)
	{
		if(!isPlay)
		{
			look.transform.position = transform.position;
			look.focus = transform;
			rigidbody.constraints = RigidbodyConstraints.None;
			transform.eulerAngles = r;
			rigidbody.AddForce (transform.forward * f, ForceMode.Impulse);
			isPlay = true;
		}
	}

	public void Reset()
	{
		transform.position = lastPosition;
	}

	public void SetLastPosition(Vector3 pos)
	{
		lastPosition = pos;
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
