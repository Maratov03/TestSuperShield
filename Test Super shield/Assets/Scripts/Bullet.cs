using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask layerMask;

    public int Speed;
    private RaycastHit hit;
    private Ray ray;
   


    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
               
        ray = new Ray(transform.position, transform.forward);
 
        if(Physics.Raycast(ray, out hit, Speed * Time.deltaTime + .1f, layerMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);

        }
        Destroy(gameObject, 2f);
    }

}
