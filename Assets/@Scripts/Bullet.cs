using UnityEngine;

public class Bullet : MonoBehaviour
{
    float _direction = 1f; // �Ѿ��� �̵� ����

    void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.Translate(Vector2.right * 5 * _direction * Time.deltaTime);
    }

    // �÷��̾��� ���⿡ �°� �Ѿ��� �̵� ������ ����
    public void SetDirection(float dir)
    {
        _direction = dir;
    }
}
