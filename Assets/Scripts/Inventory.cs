using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singleton

	public static Inventory instance_class;

	void Awake()
	{
		instance_class = this;
	}

	#endregion

	public delegate void OnItemChanged_del();
	public OnItemChanged_del onItemChangedCallback;

	
	[Header("Item Variables")]
	public int space_i = 10;  // Amount of item spaces

	// Our current list of items_li in the inventory
	public List<Item> items_li = new List<Item>();

	// Add a new item if enough room
	public void Add(Item _item)
	{
		if (_item.showInInventory_b)
		{
			if (items_li.Count >= space_i)
			{
				Debug.Log("Not enough room.");
				return;
			}

			items_li.Add(_item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
	}

	// Remove an item
	public void Remove(Item _item)
	{
		items_li.Remove(_item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}