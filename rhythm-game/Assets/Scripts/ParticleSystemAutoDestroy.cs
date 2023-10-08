using UnityEngine;

public class ParticleSystemAutoDestroy : MonoBehaviour
{
    public float destroyDelay = 1f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private System.Collections.IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSecondsRealtime(destroyDelay);
        Destroy(gameObject);
    }
}
