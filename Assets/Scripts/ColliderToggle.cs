//This script toggles the colliders on/off surrounding the player to reduce
//the collision checks of blocks not nearby


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderToggle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            other.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
