using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxKey : MonoBehaviour
{
    public GameObject boxup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkopenBox();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            InstanceManager.s.openBox = true;
        }
    }

    public void checkopenBox() { 
        if(InstanceManager.s.openBox == true)
        {
            boxup.GetComponent<Animator>().SetTrigger("OpenBox");
        }

    }


}
