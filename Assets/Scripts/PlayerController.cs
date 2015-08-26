using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private GudeManager gude;

	private float sensibility = 5, force;

	private Vector3 distance =new Vector3(0.5f, -0.5f, 1);

	public bool linked, isPlaying;

	void Update()
	{
		float rotateY = Input.GetAxis ("Mouse X") * sensibility;
		
		transform.Rotate (0, rotateY, 0);

		if(linked)
		{
			gude.enabled = false;
			gude.transform.parent = transform;
			gude.transform.localPosition = distance;
		}
		else
		{
			gude.enabled = true;
			gude.transform.parent = null;

			if(!gude.IsPlay)
			{
				transform.position = gude.transform.position - distance;
				linked = true;
				isPlaying = false;
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			gude.Play(transform.eulerAngles, force);
			linked = false;
			force = 0;
		}
		if (Input.GetMouseButton (0))
		{
			if(force < 30)
				force++;
		}
		
		gameObject.SetActive (isPlaying);
	}
	public void Play()
	{
		isPlaying = true;
		gameObject.SetActive (isPlaying);
	}
	public bool IsPlaying
	{
		get{ return isPlaying;}
	}
}
