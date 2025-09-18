using UnityEditor.Experimental.GraphView;
using UnityEngine;

public enum PlatformDirection
{
    Forward = 1,
    Backward = -1
}

public class Platform : MonoBehaviour
{
    [SerializeField] private PlatformDirection direction = PlatformDirection.Forward;
    [SerializeField] private float speed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // Invoke(nameof(SwitchDirection), 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (int)direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlatformBoundary"))
        {
            Debug.Log("Entered a trigger!", other.gameObject);
            SwitchDirection();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered a collision!", collision.gameObject);
    }

    void SwitchDirection()
    {
        direction = (PlatformDirection)((int)direction * -1);
        //Invoke(nameof(SwitchDirection), 3);
    }
}
