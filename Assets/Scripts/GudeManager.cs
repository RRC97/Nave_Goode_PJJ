using UnityEngine;
using System.Collections;

public class GudeManager : MonoBehaviour
{
	string playerTime = "Player1";

	[SerializeField]
	private bool isPlay;
	[SerializeField]
	private CameraLookController look;
	[SerializeField]
	private Inventory inventory;
	public Inventory Inventory
	{
		get
		{
			return inventory;
		}
	}
	private float time;
	void Update ()
	{
		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);

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
}
