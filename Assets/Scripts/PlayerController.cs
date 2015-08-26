using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float sensibility = 5, force;

	[SerializeField]
	private GudeManager gude;
	private bool isParentGude = true;

	[SerializeField]
	private CameraLookController camera;

	void Update()
	{
		float rotateY = Input.GetAxis ("Mouse X") * sensibility;

		transform.Rotate (0, rotateY, 0);	

		if(Input.GetMouseButtonDown(0))
		{
			gude.Play(transform.eulerAngles, force);
			isParentGude = false;
			camera.gameObject.SetActive(true);
			camera.focus = gude.transform;
		}
		
		if (isParentGude)
			gude.transform.parent = transform;
		else
			gude.transform.parent = null;
	}
}
