using UnityEngine;
using System.Collections;

public class GudeManager : MonoBehaviour
{
	string playerTime = "Player1";

	[SerializeField]
	private bool isPlay;
	[SerializeField]
	private CameraLookController look;
	void Update ()
	{
		if (isPlay)rigidbody.constraints = RigidbodyConstraints.None;
		else rigidbody.constraints = RigidbodyConstraints.FreezeAll;

		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);

		if (rigidbody.velocity == Vector3.zero)
			isPlay = false;
		
		look.gameObject.SetActive(isPlay);
	}

	public void Play(Vector3 r, float f)
	{
		if(!isPlay)
		{
			rigidbody.constraints = RigidbodyConstraints.None;
			transform.eulerAngles = r;
			rigidbody.AddForce (transform.forward * f, ForceMode.Impulse);
			isPlay = true;
			look.focus = transform;
		}
	}
}
