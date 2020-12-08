using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour
{

	public Image itemIcon_img;
	public Button removeButton_btn;

	private Item p_item_class;  // Current p_item_class in the slot

	// Add p_item_class to the slot
	public void AddItem(Item _newItem)
	{
		p_item_class = _newItem;

		itemIcon_img.sprite = p_item_class.icon_spr;
		itemIcon_img.enabled = true;
		removeButton_btn.interactable = true;
	}

	// Clear the slot
	public void ClearSlot()
	{
		p_item_class = null;

		itemIcon_img.sprite = null;
		itemIcon_img.enabled = false;
		removeButton_btn.interactable = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory()
	{
		Inventory.instance_class.Remove(p_item_class);
	}

	// Use the p_item_class
	public void UseItem()
	{
		if (p_item_class != null)
		{
			p_item_class.Use();
		}
	}

}
