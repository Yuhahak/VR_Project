using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KDoorCheck : MonoBehaviour
{
    public Animator KDooranim;
    public static KDoorCheck instance;
    // Start is called before the first frame update
    private void Awake()
    {
        KDoorCheck.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KDoorAnim(bool b)
    {
        KDooranim.SetBool("KDoorOpen", b);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
