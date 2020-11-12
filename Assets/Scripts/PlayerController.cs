using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {
        // 사용자 입력을 감지하고 점프하는 처리
        if (isDead)
            return;
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;//점프 직전에 속도를 순간적으로 0으로 변경
            playerRigidbody.AddForce(new Vector2(0, jumpForce));// 리지드바디에 위쪽으로 힘주기
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {

            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("isGrounded", isGrounded);
   }

   private void Die() {
        // 사망 처리
        animator.SetTrigger("Die");
        //오디오 소스 사망으로 면경
        playerAudio.clip = deathClip;
        playerAudio.Play();
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
   }

   private void OnTriggerEnter2D(Collider2D other) {
        // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
        // 바닥에 닿았음을 감지하는 처리
        ///collision.contacts[0]은 두 물체사이의 충돌지점 중에서 첫번째 충돌지점의 정보임
        ///첫번째 충돌지점의 표면의 방향이 위쪽이며 경사가 너무 급하지 않은지 검사하는거임
        ///이 조건을 검사합으로써 '절벽'이나 '천장'을 바닥으로 인식하는 문제를 해결

        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
   }

   private void OnCollisionExit2D(Collision2D collision) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;

    }
}