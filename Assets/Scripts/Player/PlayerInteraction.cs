using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Created: 18/11/2020, By Finn Dudley
*   Last Edited: 21/11/2020, By Finn Dudley
*/

public class PlayerInteraction : MonoBehaviour
{
    [Header("Player Attributes")]
    public float playerReachDistance_f;

    [Header("Player Object References")]
    public Camera player_cam;

    private Player1Movement player1MovementScript_class;

    [Header("UI References")]
    public Canvas canvas_can;
    public GameObject grabIcon_go;

    private RectTransform canvasRectTransform_rt;    
    private RectTransform grabIconRectTransform_rt;

#region Unity Functions

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        player1MovementScript_class = gameObject.GetComponent<Player1Movement>();
        
        // UI Stuff
        grabIcon_go.SetActive(false);
        grabIconRectTransform_rt = grabIcon_go.GetComponent<RectTransform>();
        canvasRectTransform_rt = canvas_can.GetComponent<RectTransform>();
    }

    private void Update()
    {
        DropItem();
        ItemInteraction();
        RaycastInteract();
    }
#endregion

// -----

#region  Item Functions

    /// <summary>
    /// Drops the currently handheld item.
    /// If an item in the hand equals <see langword="true"/>.
    /// </summary>
    private void DropItem(){
        // Drop Current Held Item.
    }

    /// <summary>
    /// Handles any handheld item interaction.
    /// If an item is in the hand equals <see langword="true"/>.
    /// </summary>
    private void ItemInteraction(){

    }

    /// <summary>
    /// Handles any Player Interaction using a raycast from the player.
    /// </summary>
    private void RaycastInteract()
    {
        Ray ray_ray = player_cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit_rhit;
        Debug.DrawRay(player_cam.transform.position, player_cam.transform.forward * playerReachDistance_f, Color.green ); // Debug to Draw Ray in Scene View

        if(Physics.Raycast(ray_ray, out hit_rhit, playerReachDistance_f)){
            ObjectType objType_class = hit_rhit.collider.gameObject.GetComponent<ObjectType>();

            if(objType_class != null){
                Vector2 grabIconTempPos_v2 = player_cam.WorldToScreenPoint(hit_rhit.transform.position);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform_rt, grabIconTempPos_v2, player_cam, out Vector2 calculatedCanvasPos_v2);
                grabIconRectTransform_rt.localPosition = calculatedCanvasPos_v2;

                if(!grabIcon_go.activeSelf) grabIcon_go.SetActive(true);

                if(Input.GetButtonDown("Interact")){
                    switch (objType_class.selectedObjectType_e)
                    {
                    case ObjectTypes.Task:
                        // Start to Complete the task
                        Debug.Log("Interacted with " + objType_class.selectedObjectType_e.ToString());
                        break;
                    case ObjectTypes.Equipment:
                        // Start interacting with ships Equipment.
                        Debug.Log("Interacted with " + objType_class.selectedObjectType_e.ToString());
                        break;
                    case ObjectTypes.Item:
                        // If it is a pickable item. Add to Inventory
                        Inventory.instance_class.Add(objType_class.itemType_class);
                        Destroy(hit_rhit.collider.gameObject);
                        Debug.Log("Interacted with " + objType_class.selectedObjectType_e.ToString());
                        break;
                    default:
                        break;
                    }
                }
                
            }
        }
        else if (grabIcon_go.activeSelf) grabIcon_go.SetActive(false);   
    }
#endregion
}
