using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _direction = 1f; // 총알의 이동 방향

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector2.right * 5 * _direction * Time.deltaTime);
    }

    // 플레이어의 방향에 맞게 총알의 이동 방향을 설정
    public void SetDirection(float dir)
    {
        _direction = dir;
    }
}
