using UnityEngine;
using System.Collections;

public class GudeInventory
{
	Material material;
	public GudeInventory(Material m)
	{
		material = m;
	}
	public Material Material
	{
		get
		{
			return material;
		}
	}
}
