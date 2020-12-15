using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the p_player_t can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour
{

	public float radius_f = 3f;
	public Transform interactionTransform_t;

	private bool p_isFocus_b = false;   // Is this interactable currently being focused?
	private Transform p_player_t;       // Reference to the p_player_t transform

	private bool p_hasInteracted_b = false; // Have we already interacted with the object?

	void Update()
	{
		if (p_isFocus_b)    // If currently being focused
		{
			float distance_f = Vector3.Distance(p_player_t.position, interactionTransform_t.position);
			// If we haven't already interacted and the p_player_t is close enough
			if (!p_hasInteracted_b && distance_f <= radius_f)
			{
				// Interact with the object
				p_hasInteracted_b = true;
				Interact();
			}
		}
	}

	/// <summary>
	/// Called when the object starts being focused
	/// </summary>
	/// <param name="playerTransform"> Players Current Transform.</param>
	public void OnFocused(Transform _playerTransform_t)
	{
		p_isFocus_b = true;
		p_hasInteracted_b = false;
		p_player_t = _playerTransform_t;
	}

	/// <summary>
	/// Called when the object is no longer focused
	/// </summary>
	public void OnDefocused()
	{
		p_isFocus_b = false;
		p_hasInteracted_b = false;
		p_player_t = null;
	}

	/// <summary>
	/// Objects Interaction - Gets Overrided.
	/// </summary>
	public virtual void Interact() {}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform_t.position, radius_f);
	}

}
