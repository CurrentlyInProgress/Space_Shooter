using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3.0f;
    [SerializeField]
    private GameObject _explosionPrefab;
 

    // Update is called once per frame
    void Update()
    {
        //rotate object on z axis  3m/s
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    //check for laser collisiom
    //instantiate explosion at astroid position
    //destroy explosion at 3 secs
    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.tag == "Laser")
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
