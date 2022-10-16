using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BulletDamageDealer : MonoBehaviour
{
    public List<LayerMask> layers;
    public int Damage;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IHittable>(out var damagable))
        {
            foreach (var layerMask in layers)
            {
                if((layerMask & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
                { 
                    damagable.OnHit(Damage);
                }
            }
   
        }
        Debug.Log("bullet hit" + collision.gameObject.name);
        Destroy(gameObject);
    }
}
