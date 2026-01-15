using UnityEngine;
using System.Collections;


public class Drive : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizonalInput = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;
        Vector3 appendPosition = new Vector3(horizonalInput, verticalInput, 0).normalized * speed;
        position += appendPosition * Time.deltaTime;
        Debug.Log(appendPosition);
        transform.position = position;
    }
}