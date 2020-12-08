using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2move : MonoBehaviour
{
    [Header("Object Variables")]
    public GameObject playerCam_go;

    private CharacterController p_controller_class;

    [Header("Player Variables")]
    public float lookSensitivity_f = 5;
    public float speed_f = 25.0F;
    public float jumpSpeed_f = 8.0F;
    public float gravity_f = 20.0F;

    private float p_turner_f;
    private float p_looker_f;
    private Vector3 moveDirection_v3 = Vector3.zero;

    void Start()
    {
        p_controller_class = GetComponent<CharacterController>();
    }

    void Update()
    {
        // is the controller on the ground?
        if (p_controller_class.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection_v3 = new Vector3(Input.GetAxis("Horizontal_XC"), 0, Input.GetAxis("Vertical_XC"));
            moveDirection_v3 = transform.TransformDirection(moveDirection_v3);
            //Multiply it by speed_f.
            moveDirection_v3 *= speed_f;
            //Jumping
            if (Input.GetButton("Jump_XC"))
                moveDirection_v3.y = jumpSpeed_f;

        }

        //camera looking around
        p_turner_f = Input.GetAxis("LookHorizontal_XC") * lookSensitivity_f;
        p_looker_f = Mathf.Clamp(-Input.GetAxis("LookVertical_XC") * lookSensitivity_f, -80, 80);
        if (p_turner_f != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, p_turner_f, 0);
        }
        if (p_looker_f != 0)
        {
            //Code for action on mouse moving right
            playerCam_go.transform.eulerAngles += new Vector3(p_looker_f, 0, 0);

        }
        //Applying gravity to the controller
        moveDirection_v3.y -= gravity_f * Time.deltaTime;
        //Making the character move
        p_controller_class.Move(moveDirection_v3 * Time.deltaTime);
    }
}
