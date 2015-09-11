using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	[SerializeField]
	List<GudeInventory> gudes = new List<GudeInventory>();
	bool show;
	Rect windowRect;
	// Use this for initialization
	void Awake ()
	{
		windowRect = new Rect (20, 20, Screen.width - 40, Screen.height / 4);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I))
			show = !show;
		if (Input.GetKeyDown (KeyCode.Escape))
			show = false;

		if(show) Time.timeScale = 0;
		else Time.timeScale = 1;
	}

	void OnGUI ()
	{
		if (show)
		{
			GUI.Window (0, windowRect, FunctionWindow, "Inventario");
		}
	}
	void FunctionWindow(int id)
	{
		for(int i = 0; i < 10; i++)
		{
			float scale = (windowRect.width - 110) / 10;
			GUI.Box(new Rect(10 + i * scale + i * 10, 30, scale, scale), ""+(i + 1)%10);
		}
		for(int i = 0; i < gudes.Count; i++)
		{
			float scale = (windowRect.width - 110) / 10;
			GUI.DrawTexture(new Rect(10 + i * scale + i * 10, 30, scale, scale), gudes[i].Texture);
		}
	}
	public void Add(GudeInventory gude)
	{
		gudes.Add (gude);
	}

}
