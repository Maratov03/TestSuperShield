using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensRotate;
    public float minHorizontal = -20;
    public float maxHorizontal = 20;
    public PlayerProperties playerProperties;

    private float rotationX = 0;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!playerProperties.menu)
            {
                rotationX += Input.GetAxis("Mouse X") * sensRotate;
                rotationX = Mathf.Clamp(rotationX, minHorizontal, maxHorizontal);
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotationX);
            }
        }
    }
}
