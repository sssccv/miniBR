using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rompeesc : MonoBehaviour
{
    public float destroyTime = 60f;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
