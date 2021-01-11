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
        HeldItemInteraction();
        RaycastInteract();
    }
#endregion

// -----

#region  Interaction Functions

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
    private void HeldItemInteraction(){

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
                    Debug.Log("Interacted with " + objType_class.selectedObjectType_e.ToString());
                    FMODUnity.RuntimeManager.PlayOneShot("event:/PickUp"); 
                    switch (objType_class.selectedObjectType_e)
                    {
                    case ObjectTypes.Task:
                        TaskInteract(hit_rhit);
                        break;
                    case ObjectTypes.Equipment:
                        EquipmentInteract(hit_rhit);
                        break;
                    case ObjectTypes.Item:
                        ItemInteract(hit_rhit);
                        break;
                    default:
                        break;
                    }
                }
                
            }
        }
        else if (grabIcon_go.activeSelf) grabIcon_go.SetActive(false);   
    }

    #region ObjectType Interaction
    private void EquipmentInteract(RaycastHit _hit_rhit)
    {
        EquipmentObject equipmentObject_class = _hit_rhit.collider.gameObject.GetComponent<EquipmentObject>();

    }

    private void ItemInteract(RaycastHit _hit_rhit)
    {
        ItemObject itemObject = _hit_rhit.collider.gameObject.GetComponent<ItemObject>();

        Inventory.instance_class.Add(itemObject.itemType_class);
        Destroy(_hit_rhit.collider.gameObject);
    }

    private void TaskInteract(RaycastHit _hit_rhit)
    {
        ITask taskObject = _hit_rhit.collider.gameObject.GetComponent<ITask>();

        taskObject.InteractTask();
    }
    #endregion

#endregion
}
