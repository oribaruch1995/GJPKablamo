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
        TargetPlayer = GameObject.FindGameObjectWithTag("Player");
        _moveDirection = (TargetPlayer.transform.position - transform.position).normalized;
        _rb.velocity = new Vector3(_moveDirection.x, 0, _moveDirection.z) * Speed;
        Destroy(gameObject, 4f);
    }
/*    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other);
            return;
        }

        Destroy(gameObject);
    }*/
}
