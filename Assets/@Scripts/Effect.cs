using System.Collections;
using UnityEngine;

// 이펙트 제거

public class Effect : MonoBehaviour
{
    private void Start()
    {
        // 0.5초 후 이펙트 제거
        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
