using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float sensibility = 5, force;

	[SerializeField]
	private GudeManager gude;
	private bool isParentGude = true, isPlaying= true;

	void Update()
	{
		float rotateY = Input.GetAxis ("Mouse X") * sensibility;

		transform.Rotate (0, rotateY, 0);	

		if(Input.GetMouseButtonDown(0))
		{
			gude.Play(transform.eulerAngles, force);
			isParentGude = false;
		}
		
		if (isParentGude)
			gude.transform.parent = transform;
		else
			gude.transform.parent = null;

		gameObject.SetActive (isPlaying);
	}

	public void Time()
	{
		transform.position = gude.transform.position;
		isPlaying = true;
		gameObject.SetActive (isPlaying);
	}

	public bool IsPlaying
	{
		get { return isPlaying; }
	}
}
