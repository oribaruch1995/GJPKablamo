using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int Damage;
    public int BulletSpeed;
    private Vector3 _bulletDirection;
    private Rigidbody _rigidbody;
    // Update is called once per frame
    private void Start()
    {
        _bulletDirection = GameObject.Find("Gun").transform.up;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.velocity = _bulletDirection * BulletSpeed * Time.deltaTime;
    }

/*    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<EnemyAI>(out var enemyAI))
        {
            enemyAI.OnHit(Damage);
        }
        Destroy(gameObject);
    }*/
}
