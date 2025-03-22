using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾� �̵�
// �÷��̾� �ִϸ��̼�
// �����۰� �浹
// ���� ���������� �̵�

public class PlayerController_02 : MonoBehaviour
{
    // private
    Animator _animator; // �ִϸ�����
    Rigidbody2D _rigidbody2D; // ������ٵ�
    CapsuleCollider2D _collider; // �ݶ��̴�
    bool _isGround = false; // �� �浹 üũ��
    float _originalSpeed; // ���̽��׶��� �ӵ� üũ��

    // public
    public GameObject CollectedEffect; // ������ ����Ʈ ������
    public float Speed; // �÷��̾� �ӵ�

    void Start()
    {
        // ������Ʈ ��������
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _originalSpeed = Speed;
    }

    void Update()
    {
        Move(); // �÷��̾� ������ �Լ�
    }

    void Move()
    {
        // �̵�
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 movement = new Vector3(h, 0, 0);
            transform.Translate(movement.normalized * Speed * Time.deltaTime);

            _animator.SetFloat("Speed", 1); // Speed �� 1�� ���������ν� Player_Move �ִϸ��̼� ����

            if (h > 0) { transform.localScale = new Vector3(1, 1, 1); }
            if (h < 0) { transform.localScale = new Vector3(-1, 1, 1); }
            // X���� 0���� ���� ��� (= �������� ������ ���) localScale X�� -1 ó���Ͽ� �¿�����ǵ��� ��
        }
        else
        {
            _animator.SetFloat("Speed", 0); // Speed �� 0���� ���������ν� Player_Idle �ִϸ��̼� ����
        }

        // ����
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * 300);
            _animator.SetTrigger("Jump");
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾�� �� �浹 ó���Ͽ� ���� �� ���� �ϵ��� ��
        if (collision.transform.CompareTag("GROUND") || collision.transform.CompareTag("FINISH POINT") || collision.transform.CompareTag("ICEGROUND"))
        {
            _isGround = true;
            _animator.SetTrigger("Ground");
        }

        // ������ ��� ���� �� ���� ���������� �̵�
        if (collision.transform.CompareTag("FINISH POINT"))
        {
            // ������ ī��Ʈ�� 0�̶��
            if (ItemController.ItemCount == 0)
            {
                SceneManager.LoadScene("03_STAGE");
            }
        }

        if (collision.transform.CompareTag("ICEGROUND"))
        {
            Speed += 7;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ICEGROUND"))
        {
            Speed = _originalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEM") // �����۰� ����� ��
        {
            Instantiate(CollectedEffect, collision.transform.position, Quaternion.identity); // ����Ʈ �߻�
        }

        if (collision.gameObject.tag == "SAW")
        {
            _animator.SetTrigger("Die");
            _collider.enabled = false;
            _rigidbody2D.AddForce(Vector2.up * 100);

            StartCoroutine(DestroyPlayer());
        }
    }

    IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        // ���� �� ��ȣ �ҷ��ͼ� �ε�
        int sceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIdx);
    }
}
