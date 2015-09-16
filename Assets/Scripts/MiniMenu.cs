using UnityEngine;
using System.Collections;

public class MiniMenu : MonoBehaviour
{
	bool show;
	Rect windowRect;
	void Start () 
	{
		Screen.showCursor = false;
		Screen.lockCursor = true;
		windowRect = new Rect (0, 0, Screen.width/8, Screen.height / 3);
		windowRect.x = Screen.width / 2 - windowRect.width / 2;
		windowRect.y = Screen.height / 2 - windowRect.height / 2;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q) && Time.timeScale > 0) 
		{
			Screen.showCursor = true;
			Screen.lockCursor = false;
			show = true;
			if(show) Time.timeScale = 0;
			else Time.timeScale = 1;
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.showCursor = false;
			Screen.lockCursor = true;
			show = false;
			if(show) Time.timeScale = 0;
			else Time.timeScale = 1;
		}
	}

	void OnGUI ()
	{
		if (show)
		{
			GUI.Window (0, windowRect, MiniMenuWindow, "Menu");
		}
	}

	void MiniMenuWindow(int id)
	{
		float buttonW = windowRect.width - 20;
		float buttonH = (windowRect.height - 70) / 3;
		if (GUI.Button (new Rect (10, 30, buttonW, buttonH), "Continuar"))
			show = false;
		if (GUI.Button (new Rect (10, 40 + buttonH, buttonW, buttonH), "Recomeçar"))
			Application.LoadLevel (Application.loadedLevel);	
		if (GUI.Button (new Rect (10, 50 + buttonH * 2, buttonW, buttonH), "Sair"))
			Application.LoadLevel ("MENU");	
	}
}
