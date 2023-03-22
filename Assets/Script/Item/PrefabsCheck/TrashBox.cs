using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBox : MonoBehaviour
{
    public Animator aim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrashBoxCheck();
    }

    void TrashBoxCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Player")
            {
                aim.SetBool("TrashBoxOpen", true);
            }
        }
    }
}

