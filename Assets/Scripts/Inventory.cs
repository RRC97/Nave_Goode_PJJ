using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	List<GudeInventory> gudes;
	bool show;
	Rect windowRect;
	// Use this for initialization
	void Awake ()
	{
		gudes = new List<GudeInventory>();
		windowRect = new Rect (20, 20, Screen.width - 40, Screen.height / 4);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!GetComponent<PlayerController>().Gude.IsPlay)
		{
			if (Input.GetKeyDown (KeyCode.I) && Time.timeScale > 0)
			{
				show = !show;
				if(show) Time.timeScale = 0;
				else Time.timeScale = 1;
			}
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				show = false;
				if(show) Time.timeScale = 0;
				else Time.timeScale = 1;
			}

			if(show)
			{
				for(int i = 0; i < gudes.Count; i++)
				{
					if(gudes[i] != null)
					{
						if(Input.GetKeyDown(""+(i + 1)%10))
						{
							GudeInventory temp = GetComponent<PlayerController>().Gude.Gude;
							GetComponent<PlayerController>().Gude.Gude = gudes[i];
							gudes[i] = temp;
						}
					}
				}
			}
		}
	}

	void OnGUI ()
	{
		if (show)
		{
			GUI.Window (0, windowRect, InventoryWindow, "Inventario " + gameObject.name);
		}
	}
	void InventoryWindow(int id)
	{
		for(int i = 0; i < 10; i++)
		{
			float scale = (windowRect.width - 110) / 10;
			GUI.Box(new Rect(10 + i * scale + i * 10, 30, scale, scale), ""+(i + 1)%10);
		}
		for(int i = 0; i < gudes.Count; i++)
		{
			float scale = (windowRect.width - 110) / 14;
			GUI.DrawTexture(new Rect(30 + i * (scale * 1.4f) + i * 10, 50, scale, scale), gudes[i].Material.mainTexture);
		}
	}
	public void Add(GudeInventory gude)
	{
		gudes.Add (gude);
	}
	public void Remove(GudeInventory gude)
	{
		gudes.Remove (gude);
	}
	public GudeInventory Get(int i)
	{
		if (i < Count)
			return gudes [i];
		return null;
	}
	public int Count
	{
		get
		{
			return gudes.Count;
		}
	}
}
