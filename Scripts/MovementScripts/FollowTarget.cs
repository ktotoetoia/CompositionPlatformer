using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void LateUpdate()
    {
        Follow(target.position);
    }

    private void Follow(Vector3 target)
    {
        target.z = transform.position.z;
        transform.position = target;
    }
}
