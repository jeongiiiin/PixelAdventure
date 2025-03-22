using UnityEngine;

// �÷��̾�� �浹 ����
// ������ ���� ī��Ʈ

public class ItemController : MonoBehaviour
{
    // public
    public static int ItemCount; // ������ ������Ű�� PlayerController ��ũ��Ʈ���� Ȱ���ϰ��� static���� ������

    private void Start()
    {
        ItemCount = GameObject.FindGameObjectsWithTag("ITEM").Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PLAYER")
        {
            Destroy(gameObject);
            ItemCount--;
        }
    }
}
