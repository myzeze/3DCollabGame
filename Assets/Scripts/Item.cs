using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

	new public string name_str = "New Item";    // Name of the item
	public Sprite icon_spr = null;              // Item icon_spr
	public bool showInInventory_b = true;

	// Called when the item is pressed in the inventory
	public virtual void Use()
	{
		// Use the item
		// Something may happen
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory()
	{
		Inventory.instance_class.Remove(this);
	}

}
