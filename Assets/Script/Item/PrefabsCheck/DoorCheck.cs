using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{

    public Animator doorOpenAnim;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen() {
        doorOpenAnim.SetInteger("doorState", 1);
    }

    public void DoorClose()
    {
        doorOpenAnim.SetInteger("doorState", 0);
    }
}
