using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHand : MonoBehaviour
{
    public GameObject item;
    public Transform hand;
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.Q;

    private GameObject heldItem;

    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && heldItem == null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Item")
                {
                    Debug.Log("1");
                    heldItem = Instantiate(item, hand);
                    heldItem.transform.localPosition = Vector3.zero;
                    heldItem.transform.localRotation = Quaternion.identity;
                    heldItem.GetComponent<Rigidbody>().isKinematic = true;
                    break;
                }
            }
        }
        else if (Input.GetKeyDown(dropKey) && heldItem != null)
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.transform.parent = null;
            heldItem = null;
        }
    }
}
