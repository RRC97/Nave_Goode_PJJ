using UnityEngine;
using System.Collections;

public class GudeManager : MonoBehaviour
{
	[SerializeField]
	private bool isPlay;
	void Update ()
	{
		if (isPlay) rigidbody.constraints = RigidbodyConstraints.None;
		else rigidbody.constraints = RigidbodyConstraints.FreezeAll;

		rigidbody.AddForce (-rigidbody.velocity / 100, ForceMode.VelocityChange);
	}

	public void Play(Vector3 r, float f)
	{
		if(!isPlay)
		{
			rigidbody.constraints = RigidbodyConstraints.None;
			transform.eulerAngles = r;
			rigidbody.AddForce (transform.forward * f, ForceMode.Impulse);
			isPlay = true;
		}
	}
}
