using UnityEngine;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField]
	private string nameScene;

	public void OnClick()
	{
		if (nameScene != null)
			Application.LoadLevel (nameScene);
	}
}
