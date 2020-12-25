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
    [SerializeField] private bool cursor;
 
 

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerProperties.bullet = 3;
        cursor = true;
    }
  
    void Update()
    {
        if (playerProperties.menu)
        {
            cursor = false;
        }
        if (!playerProperties.menu)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Shoot();
                playerProperties.bullet -= 1;

            }
            if (Input.GetMouseButton(0))
            {
                cursor = false;
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
                cursor = true;
                lineRenderer.SetPosition(1, new Vector3(0, 0, 0));
            }
        }
        CursorFalse();
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
    public void CursorFalse()
    {
        if (cursor)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
