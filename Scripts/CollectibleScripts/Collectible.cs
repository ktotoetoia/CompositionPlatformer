using UnityEngine;

public class Collectible : MonoBehaviour
{
    protected bool isCollected;

    private Animator animator;
    private string collected = "Collected";

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Collector collector)&&!isCollected)Collect(collector);
    }

    public virtual void Collect(Collector collector)
    {
        isCollected = true;
        animator.SetTrigger(collected);
    }
}
