using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float Speed = 7f;
    public GameObject TargetPlayer;
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        TargetPlayer = GameObject.Find("Player");
        _moveDirection = (TargetPlayer.transform.position - transform.position).normalized * Speed;
        _rb.velocity = new Vector3(_moveDirection.x, 0, _moveDirection.z);
        Destroy(gameObject, 4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            //ADD HIT PLAYER LOGIC
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other);
        }
        else
            Destroy(gameObject);
    }
}
