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
        Coords dirNormal = Helper.GetNormal(new Coords(direction));
        direction = dirNormal.ToVector();
        float a = Helper.Angle(new Coords(transform.up), new Coords(direction));
        bool clockwise = false;
        if (Helper.Cross(new Coords(transform.up), dirNormal).z < 0)
            clockwise = true;
        Coords newDir = Helper.Rotate(new Coords(transform.up), a, clockwise);
        transform.up = new Vector3(newDir.x, newDir.y, newDir.z);
    }
    void Update()
    {
        if (Helper.Distance(new Coords(transform.position), 
        new Coords(fuelTank.transform.position)) > stoppingDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}