using System.Collections;
using UnityEngine;

// ����Ʈ ����

public class Effect : MonoBehaviour
{
    private void Start()
    {
        // 0.5�� �� ����Ʈ ����
        StartCoroutine(DestroyEffect());
    }

    IEnumerator DestroyEffect()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
    }
}
