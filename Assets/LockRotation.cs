using UnityEngine;

public class LockCandleRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation; // remember starting orientation
    }

    void LateUpdate()
    {
        // Restore the original rotation every frame so it stays upright
        transform.rotation = initialRotation;
    }
}
