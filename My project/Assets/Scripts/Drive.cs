using UnityEngine;
using System.Collections;


public class Drive : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private GameObject fuelTank;
    [SerializeField] private float stoppingDistance = 0.1f;
    Vector3 direction;
    void Start()
    {
        direction = fuelTank.transform.position - transform.position;
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, fuelTank.transform.position) > stoppingDistance)
        {
            transform.position += direction.normalized * speed * Time.deltaTime;
        }
    }
}