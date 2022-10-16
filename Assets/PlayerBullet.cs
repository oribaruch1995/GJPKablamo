using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int BulletSpeed;
    private Vector3 _bulletDirection;
    // Update is called once per frame
    private void Start()
    {
        _bulletDirection = GameObject.Find("Gun").transform.up;
    }
    private void Update()
    {
        GetComponent<Rigidbody>().velocity = _bulletDirection * BulletSpeed * Time.deltaTime;
    }
}
