using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour

{
    private float _speed = 3f;

    void Update()
    {

        transform.Translate(Vector3.up * _speed * Time.deltaTime);
       
        if (transform.position.y > 8f)
        {
            //check if object has a parent 
            // destroy parent too
            if (transform.parent  != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy (this.gameObject);
        }
    }
}
