using UnityEngine;

// ���ʹ� ������
public class Enemy_02 : MonoBehaviour
{
    //public
    public float RightMax; // ������ �ִ�
    public float LeftMax; // ���� �ִ�

    // private
    Animator _animator;
    CapsuleCollider2D _collider;
    float _currentPosX; // ���� X�� ��ġ
    [SerializeField] // private ���� �ν����Ϳ� ǥ��
    float _direction;
    //int _hitCount = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<CapsuleCollider2D>();
        _currentPosX = transform.position.x;
    }

    private void Update()
    {
        _currentPosX += Time.deltaTime * _direction;

        if (_currentPosX >= RightMax)
        {
            _direction *= -1; // ���� ��ȯ
            _currentPosX = RightMax;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_currentPosX <= LeftMax)
        {
            _direction *= -1; // ���� ��ȯ
            _currentPosX = LeftMax;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = new Vector3(_currentPosX, transform.position.y, transform.position.z);

        Die();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "BULLET")
    //    {
    //        Destroy(collision.gameObject);
    //        _hitCount++;

    //        if (_hitCount >= 3)
    //        {
    //            _animator.SetTrigger("Die");
    //            _direction = 0;
    //            _collider.enabled = false;
    //            Destroy(gameObject, 1.5f);
    //        }
    //    }
    //}

    void Die()
    {
        if (EnemyHitBox_02.Instance.HitCount02 >= 1)
        {
            Debug.Log("Enemy ��ũ��Ʈ : " + EnemyHitBox_02.Instance.HitCount02);
            _animator.SetTrigger("Die");
            _direction = 0;
            _collider.enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
