using UnityEngine;

public class PadelMovement : MonoBehaviour
{
    [SerializeField] private float maxPosition = 10;
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position.z+Input.GetAxis("Mouse X")<maxPosition && transform.position.z+Input.GetAxis("Mouse X")>-maxPosition)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z+Input.GetAxis("Mouse X"));
        }
    }
}
