using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Vector3 dir)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
            //총알을 삭제한다.
        Destroy(gameObject, 2f);
	}
}
