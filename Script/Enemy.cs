using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    private Player _player;
    private Animator _anim;
    //null check
    //handle to animator component to anim

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {//assign to component and null check
            Debug.LogError("Player is NULL");
        }
        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("The Animator is NULL");
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (_player != null)
            {
                _player.Damage();
            }
            _anim.SetTrigger("On Enemy Death");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            //trigger anim
            if (_player != null)
            {
                _player.AddScore(10);
            }
            _anim.SetTrigger("On Enemy Death");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
    }
}
