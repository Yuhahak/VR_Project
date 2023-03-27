using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    private bool isOpen = false;

    public Animator doorAnim;
    public static DoorCheck instance;

    // Start is called before the first frame update
    private void Awake()
    {
        DoorCheck.instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        DoorCheckOpen();
    }

    void DoorCheckOpen()
    {
        if (isOpen == false)
        {
            if (Checker.instance.DoorOpen == true)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;

                DoorAnim(true);
                Debug.Log("문이 열렸습니다");
                isOpen = true;
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DoorAnim(false);
            Debug.Log("문이 잠겨있습니다.");
        }
    }

    public void DoorAnim(bool b)
    {
        doorAnim.SetBool("DoorOpen", b);
    }
}
