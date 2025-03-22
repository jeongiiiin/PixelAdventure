using UnityEngine;
using UnityEngine.SceneManagement;

// �÷��̾� �̵�
// �÷��̾� �ִϸ��̼�
// �����۰� �浹
// ���� ���������� �̵�

public class PlayerController_01 : MonoBehaviour
{
    // private
    Animator _animator; // �ִϸ�����
    Rigidbody2D _rigidbody2D; // ������ٵ�
    bool _isGround = false; // �� �浹 üũ

    // public
    public GameObject Effect; // ����Ʈ ������
    public float Speed; // �÷��̾� �ӵ�

    void Start()
    {
        // ������Ʈ ��������
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        GameManager.Instance.Score = 0;
        GameManager.Instance.PlayerStartTime = Time.time;
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
        if (collision.transform.CompareTag("GROUND") || collision.transform.CompareTag("FINISH POINT"))
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
                SceneManager.LoadScene("02_STAGE");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEM") // �����۰� ����� ��
        {
            Instantiate(Effect, collision.transform.position, Quaternion.identity); // ����Ʈ �߻�
        }
    }
}
