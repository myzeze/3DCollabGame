using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform player_t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition_v3 = player_t.position;
        newPosition_v3.y = transform.position.y; //keeps y position the same
        transform.position = newPosition_v3;

        transform.rotation = Quaternion.Euler(90f, player_t.eulerAngles.y, 0f); //makes camera rotate with player_t
    }
}
