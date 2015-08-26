using UnityEngine;
using System.Collections;

public class CameraLookController : MonoBehaviour
{
	public Transform focus;

	[SerializeField]
	private Vector3 distance;
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 position = transform.position;
		position = Vector3.Lerp (position, focus.position + distance, 0.1f);
		transform.position = position;

		transform.LookAt (focus);
	}
}
