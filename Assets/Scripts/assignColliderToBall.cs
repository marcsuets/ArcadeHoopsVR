using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignColliderToBall : MonoBehaviour
{
    private GameObject net;
    private SphereCollider ballCollider;

    void Start()
    {
        // Find the net GameObject by its tag
        net = GameObject.FindGameObjectWithTag("Net");
        ballCollider = GetComponent<SphereCollider>();

        // Null checks
        if (net == null)
        {
            Debug.LogError("Net GameObject not found! Ensure it has the 'Net' tag assigned.");
        }

        if (ballCollider == null)
        {
            Debug.LogError("SphereCollider not found! Ensure this GameObject has a SphereCollider component.");
        }
    }

    public void OnHandGrab()
    {
        if (net == null || ballCollider == null) return;

        Debug.Log("OnHandGrab triggered");

        // Get the Cloth component
        Cloth clothComponent = net.GetComponent<Cloth>();
        if (clothComponent == null)
        {
            Debug.LogError("Cloth component not found on Net!");
            return;
        }

        // Update the sphereColliders array
        ClothSphereColliderPair[] currentColliders = clothComponent.sphereColliders;
        ClothSphereColliderPair[] newColliders = new ClothSphereColliderPair[currentColliders.Length + 1];

        // Copy existing colliders
        for (int i = 0; i < currentColliders.Length; i++)
        {
            newColliders[i] = currentColliders[i];
        }

        // Add the new collider
        newColliders[currentColliders.Length] = new ClothSphereColliderPair(ballCollider);

        // Assign the updated array back to the Cloth component
        clothComponent.sphereColliders = newColliders;
    }
}