using UnityEngine;

// 플레이어와 충돌 관리
// 아이템 개수 카운트

public class ItemController : MonoBehaviour
{
    // public
    public static int ItemCount; // 개수를 누적시키고 PlayerController 스크립트에서 활용하고자 static으로 선언함

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
