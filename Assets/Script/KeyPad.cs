using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyPad : MonoBehaviour
{
    [SerializeField] private Text bigtxt;

    public void Number(int number)
    {
        bigtxt.text = number.ToString();
    }
}
