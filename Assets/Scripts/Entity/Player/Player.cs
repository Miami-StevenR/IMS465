using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour, IEntity
{
    private CharacterController controller;
    private GameObject previousCollision = null;
    private IConveyor currentConveyor = null;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    void FixedUpdate()
    {
        // hit.gameObject.SendMessageUpwards("OnMoveableCollide", this, SendMessageOptions.DontRequireReceiver);
        // hit.gameObject.SendMessageUpwards("OnMoveableCollideExit", this, SendMessageOptions.DontRequireReceiver);
    }

    void Update()
    {
        if (!controller.isGrounded)
        {
            if (currentConveyor != null)
            {
                DetachFromCurrentConveyor();
            }
            previousCollision = null;
        }
    }

    public void Translate(Vector3 direction)
    {
        SetPosition(transform.position + direction);
    }

    public void SetPosition(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }

    public void SetRotation(Quaternion rotation)
    {
        controller.enabled = false;
        transform.rotation = rotation;
        controller.enabled = true;
    }

    public void SetFixedUpdateVector(Vector3 vector)
    {
        var destination = transform.position + vector;
        SetPosition(Vector3.Lerp(transform.position, destination, Time.deltaTime));
    }

    private void AttachToConveyor(IConveyor conveyor)
    {
        currentConveyor = conveyor;
        currentConveyor.AttachEntity(this);
    }

    private void DetachFromCurrentConveyor()
    {
        currentConveyor.DetachEntity(this);
        currentConveyor = null;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject == previousCollision) return;

        if (hit.gameObject.CompareTag("Conveyor"))
        {
            var conveyor = hit.gameObject.GetComponent<Conveyor>();
            AttachToConveyor(conveyor);
        }
        previousCollision = hit.gameObject;
    }
}
