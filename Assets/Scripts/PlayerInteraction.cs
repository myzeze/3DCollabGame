using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   Created By: Finn Dudley
*   Last Edited: 18/11/2020, By Finn Dudley
*/
public class PlayerInteraction : MonoBehaviour
{
    [Header("Player Attributes")]
    public float playerReachDistance;

    [Header("Player Object References")]
    public Camera playerCam;
    private Player1Movement player1MovementScript;

    [Header("UI References")]
    public Canvas canvas;
    private RectTransform canvasRectTransform;    
    public GameObject grabIcon;
    private RectTransform grabIconRectTransform;

#region Unity Functions

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;

        player1MovementScript = gameObject.GetComponent<Player1Movement>();
        
        // UI Stuff
        grabIcon.SetActive(false);
        grabIconRectTransform = grabIcon.GetComponent<RectTransform>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    private void Update(){
        DropItem();
        ItemInteraction();
        RaycastInteract();
    }
#endregion

// -----

#region  Item Functions

    private void DropItem(){
        // Drop Current Held Item.
    }
    private void ItemInteraction(){

    }

    private void RaycastInteract(){

        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        RaycastHit hit;
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward * playerReachDistance, Color.green ); // Debug to Draw Ray in Scene View

        if(Physics.Raycast(ray, out hit, playerReachDistance)){
            ObjectType objType = hit.collider.gameObject.GetComponent<ObjectType>();
            if(objType != null){
                
                
                Vector2 grabIconTempPos = playerCam.WorldToScreenPoint(hit.transform.position);
                grabIconRectTransform.anchoredPosition = (grabIconTempPos - canvasRectTransform.sizeDelta / 2f); // TEMP most likely need changing for performance
                if(grabIcon.activeSelf == false) grabIcon.SetActive(true);
                
                switch (objType.selectedObjectType)
                {
                    case ObjectTypes.Task:

                        break;
                    case ObjectTypes.Item:
                        // If it is a pickable item.
                        break;
                    default:
                    break;
                }
            }
            
        }
        else if (grabIcon.activeSelf == true) grabIcon.SetActive(false);   
    }
#endregion
}
