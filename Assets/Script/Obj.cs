using System;
using UnityEngine;


public class Obj : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    GameObject playerEquipPoint;
    Action playerLogic;

    Vector3 forceDirection;
    bool isPlayerEnter;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerEquipPoint = GameObject.FindGameObjectWithTag("EquipPoint");

        playerLogic = player.GetComponent<Action>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }

}

