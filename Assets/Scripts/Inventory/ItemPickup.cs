using UnityEngine;

public class ItemPickup : Interactable
{

	public Item item_class;   // Item to put in the inventory if picked up

	// When the player interacts with the item_class
	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	// Pick up the item_class
	void PickUp()
	{
		Debug.Log("Picking up " + item_class.name);
		Inventory.instance_class.Add(item_class);   // Add to inventory

		Destroy(gameObject);    // Destroy item_class from scene
	}

}
