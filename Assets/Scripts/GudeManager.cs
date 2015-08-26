using UnityEngine;
using System.Collections;

public class GudeManager : MonoBehaviour
{
	string playerTime = "Player1";

	[SerializeField]
	private bool isPlay;
	[SerializeField]
	private CameraLookController look;
	private float time;
	void Update ()
	{
		if (isPlay)
		{
			rigidbody.constraints = RigidbodyConstraints.None;
			time += Time.deltaTime;
		}
		else rigidbody.constraints = RigidbodyConstraints.FreezeAll;

		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);

		if (time > 2f && (int)rigidbody.velocity.magnitude < 1)
		{
			isPlay = false;
			time = 0;
			rigidbody.velocity = Vector3.zero;
		}
		
		look.gameObject.SetActive(isPlay);
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
