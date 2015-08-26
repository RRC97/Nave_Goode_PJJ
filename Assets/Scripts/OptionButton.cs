using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour
{
	[SerializeField]
	private GameObject[] options;
	private bool shown;

	public void OnClick()
	{
		shown = !shown;

		foreach (GameObject option in options)
			option.SetActive (shown);
	}
}
