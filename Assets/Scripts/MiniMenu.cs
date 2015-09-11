using UnityEngine;
using System.Collections;

public class MiniMenu : MonoBehaviour
{

	bool show;
	Rect windowRect;
	void Start () 
	{
		windowRect = new Rect (0, 0, Screen.width/8, Screen.height / 3);
		windowRect.x = Screen.width / 2 - windowRect.width / 2;
		windowRect.y = Screen.height / 2 - windowRect.height / 2;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			show = !show;
		}
	
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			show = false;
		}
		if(show) Time.timeScale = 0;
		else Time.timeScale = 1;


	}

	void OnGUI ()
	{
		if (show)
		{
			GUI.Window (0, windowRect, FunctionWindow, "Menu");
		}
	}

	void FunctionWindow(int id)
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
