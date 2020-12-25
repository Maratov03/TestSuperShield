using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public float distanceLaser;
    [SerializeField] private Animator anim;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private RaycastHit hit;
    public PlayerProperties playerProperties;
 
 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerProperties.bullet = 3;        
    }
  
    void Update()
    {
        if (!playerProperties.menu)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Shoot();
                playerProperties.bullet -= 1;

            }
            if (Input.GetMouseButton(0))
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider)
                    {
                        lineRenderer.SetPosition(1, new Vector3(0, 0, hit.distance));
                    }
                    else
                    {
                        lineRenderer.SetPosition(1, new Vector3(0, 0, 5000));
                    }
                }
            }
            else
            {
                lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
            }
        }

    }
   
    public void Shoot()
    {
        anim.SetTrigger("Shoot");
        StartCoroutine(ShootCoroutine());
    }
    IEnumerator ShootCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
    }
}
