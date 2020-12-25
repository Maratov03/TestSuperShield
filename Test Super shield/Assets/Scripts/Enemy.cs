using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    new Collider collider;
    public PlayerProperties playerProperties;
    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<Collider>();  
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            anim.enabled = false;
            Destroy(collider);
            playerProperties.enemy -= 1;
        }

    }
}
