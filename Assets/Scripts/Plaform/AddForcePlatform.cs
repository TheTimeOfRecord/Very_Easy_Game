using UnityEngine;

public class AddForcePlatform : MonoBehaviour
{
    public AddForcePlatformSO addForcePlatform;
    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            collision.rigidbody.AddForce(addForcePlatform.direction * addForcePlatform.power, addForcePlatform.forceMode);
        }
    }
}