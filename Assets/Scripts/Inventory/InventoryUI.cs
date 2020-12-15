using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory_class UI. */

public class InventoryUI : MonoBehaviour
{

	public GameObject inventoryUI_go;  // The entire UI
	public Transform itemsParent_t;   // The parent object of all the items

	private Inventory inventory_class;    // Our current inventory_class

	void Start()
	{
		inventory_class = Inventory.instance_class; //references to singleton
		inventory_class.onItemChangedCallback += UpdateUI;
	}

	// Check to see if we should open/close the inventory_class
	void Update()
	{
		if (Input.GetButtonDown("Inventory"))
		{
			inventoryUI_go.SetActive(!inventoryUI_go.activeSelf);
			if(inventoryUI_go) Cursor.lockState = CursorLockMode.Confined;
			else Cursor.lockState = CursorLockMode.Locked;
			UpdateUI();
		}
	}

	// Update the inventory_class UI by:
	//		- Adding items
	//		- Clearing empty slots_class_arr
	// This is called using a delegate on the Inventory.
	public void UpdateUI()
	{
		InventorySlot[] slots_class_arr = GetComponentsInChildren<InventorySlot>(); //array

		for (int i = 0; i < slots_class_arr.Length; i++)
		{
			if (i < inventory_class.items_li.Count)
			{
				slots_class_arr[i].AddItem(inventory_class.items_li[i]);
			}
			else
			{
				slots_class_arr[i].ClearSlot();
			}
		}
	}

}
