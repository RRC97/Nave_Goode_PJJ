using UnityEngine;
using System.Collections;

public class GudeInventory
{
	Texture texture;
	public GudeInventory(Texture t)
	{
		texture = t;
	}
	public Texture Texture
	{
		get
		{
			return texture;
		}
	}
}
