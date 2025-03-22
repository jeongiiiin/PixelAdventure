using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// 플레이어 이동
// 플레이어 애니메이션
// 아이템과 충돌
// 다음 스테이지로 이동

public class PlayerController_03 : MonoBehaviour
{
    public static PlayerController_03 Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // private
    Animator _animator; // 애니메이터
    Rigidbody2D _rigidbody2D; // 리지드바디
    CapsuleCollider2D _collider; // 콜라이더
    bool _isGround = false; // 땅 충돌 체크용
    float _originalSpeed; // 아이스그라운드, 샌드그라운드 속도 체크용
    int _hitCount;

    // public
    public GameObject CollectedEffect; // 아이템 이펙트 프리팹
    public GameObject Bullet;
    public float Speed; // 플레이어 속도

    public int HitCount
    {
        get { return _hitCount; }
        set { _hitCount = value; }
    }

    void Start()
    {
        // 컴포넌트 가져오기
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

        _originalSpeed = Speed;
    }

    void Update()
    {
        Move(); // 플레이어 움직임 함수
    }

    void Move()
    {
        // 이동
        if (Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            Vector3 movement = new Vector3(h, 0, 0);
            transform.Translate(movement.normalized * Speed * Time.deltaTime);

            _animator.SetFloat("Speed", 1); // Speed 값 1로 설정함으로써 Player_Move 애니메이션 실행

            if (h > 0) { transform.localScale = new Vector3(1, 1, 1); }
            if (h < 0) { transform.localScale = new Vector3(-1, 1, 1); }
            // X값이 0보다 작을 경우 (= 왼쪽으로 움직일 경우) localScale X축 -1 처리하여 좌우반전되도록 함
        }
        else
        {
            _animator.SetFloat("Speed", 0); // Speed 값 0으로 설정함으로써 Player_Idle 애니메이션 실행
        }

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody2D.AddForce(Vector2.up * 300);
            _animator.SetTrigger("Jump");
            _isGround = false;
        }

        // 공격 // 밟아서 죽이면 됨, 총 필요 없음
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // 총알 발사 방향을 결정
        //    float direction = transform.localScale.x; 
        //    Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>().SetDirection(direction);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어와 땅 충돌 처리하여 점프 한 번만 하도록 함
        if (collision.transform.CompareTag("GROUND") || collision.transform.CompareTag("ICEGROUND"))
        {
            _isGround = true;
            _animator.SetTrigger("Ground");
        }

        if (collision.transform.CompareTag("ICEGROUND"))
        {
            Speed += 7;
        }

        if (collision.transform.CompareTag("SANDGROUND"))
        {
            Speed -= 2;
        }

        if (collision.transform.CompareTag("TRAP"))
        {
            _animator.SetTrigger("Die");
            _collider.enabled = false;
            _rigidbody2D.AddForce(Vector2.up * 100);

            StartCoroutine(DestroyPlayer());
        }

        if (collision.transform.CompareTag("TRAM"))
        {
            _isGround = false;
            _rigidbody2D.AddForce(Vector2.up * 600);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ICEGROUND") || collision.transform.CompareTag("SANDGROUND"))
        {
            Speed = _originalSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ITEM") // 아이템과 닿았을 때
        {
            Instantiate(CollectedEffect, collision.transform.position, Quaternion.identity); // 이펙트 발생
        }

        if (collision.gameObject.tag == "ENEMY")
        {
            _animator.SetTrigger("Die");
            _collider.enabled = false;
            _rigidbody2D.AddForce(Vector2.up * 100);

            StartCoroutine(DestroyPlayer());
        }

        // 아이템 모두 제거 후 엔드씬 이동
        if (collision.gameObject.tag == "FINISH POINT")
        {
            // 아이템 카운트가 0이라면
            if (ItemController.ItemCount == 0)
            {
                _animator.SetTrigger("Win");
                StartCoroutine(CoDelayScene());
            }
        }
    }

    IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(1.5f);

        // 현재 씬 번호 불러와서 로드
        int sceneIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIdx);
    }

    IEnumerator CoDelayScene()
    {
        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene("End");
    }
}
