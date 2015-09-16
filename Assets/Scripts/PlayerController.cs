using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private GudeManager gude;
	[SerializeField]
	private Scrollbar scrollbar;
	[SerializeField]
	private Text crosshair;

	private float sensibility = 5, force;

	private Vector3 distance = new Vector3(0.5f, -0.5f, 1);

	private bool linked, isPlaying;

	void Awake()
	{
		linked = true;
		gude.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
		scrollbar.size = (float)force / 40;
		gude.enabled = false;
		gude.transform.parent = transform;
		gude.gameObject.layer = 9;
		gude.transform.localPosition = distance;
		crosshair.gameObject.SetActive(true);
		scrollbar.gameObject.SetActive(true);
	}

	void FixedUpdate()
	{
		float rotateY = Input.GetAxis ("Mouse X") * sensibility;
		transform.Rotate (0, rotateY, 0);
		if(linked)
		{
			gude.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
			scrollbar.size = (float)force / 40;
			gude.enabled = false;
			gude.transform.parent = transform;
			gude.gameObject.layer = 9;
			gude.transform.localPosition = distance;
			crosshair.gameObject.SetActive(true);
			scrollbar.gameObject.SetActive(true);
		}
		else
		{
			crosshair.gameObject.SetActive(false);
			scrollbar.gameObject.SetActive(false);
			gude.enabled = true;
			gude.gameObject.layer = 10;
			gude.transform.parent = null;
			
			if(!gude.IsPlay)
			{
				transform.position = gude.transform.position - distance;
				linked = true;
				isPlaying = false;
			}
		}
		if (Input.GetMouseButton (0))
		{
			if(force < 40)
				force++;
		}
		
		if(Input.GetMouseButtonUp(0))
		{
			gude.Play(transform.eulerAngles, force);
			linked = false;
			force = 0;
		}
		gameObject.SetActive (isPlaying);
	}
	public void Play()
	{
		if(!isPlaying)
		{
			gude.SetLastPosition(gude.transform.position);
			isPlaying = true;
			Vector3 newPos = gude.transform.position;
			newPos.y = 0.8f;
			transform.position = newPos;
			gameObject.SetActive (isPlaying);
		}
	}
	public bool IsPlaying
	{
		get{ return isPlaying;}
	}
	public GudeManager Gude
	{
		get
		{
			return gude;
		}
	}
}
