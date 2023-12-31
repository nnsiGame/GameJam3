using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_AMusicGage { get; private set; }
    public float m_BMusicGage { get; private set; }

    [SerializeField] float m_MagicChargeSpeed = 3;
    public float m_MagicChargeGage { get; private set; }
    float m_CurrentSpeed;                               // 現在の移動スピード
    [SerializeField] float m_MoveSpeed = 16f;           // 移動スピードの最大値
    [SerializeField] float m_AccelerationSpeed = 14.5f; // 加速度
    [SerializeField] float m_JumpPower = 5f;            // ジャンプ力

    bool m_IsJump;
    bool m_CanCreateShockWave; // 衝撃波を生成してよいか？

    public bool m_IsDead { get; private set; }

    [SerializeField] GameObject m_AMagic;
    [SerializeField] GameObject m_BMagic;
    [SerializeField] GameObject m_ShockWave;

    [SerializeField] ParticleSystem m_Particle;

    Transform m_ShockWaveCreatePoint;
    [SerializeField] Transform m_MagicCreatePoint; // 魔法を生成するポジション
    [SerializeField] Transform m_BoxCastOrigin;    // BoxCastを放つオリジン

    Rigidbody2D m_RB;

    Animator m_Animator;

    BGMManager m_BGMManager;

    State m_CurrentState;
    enum State
    {
        Normal,
        Die,
    }

    // Start is called before the first frame update
    void Start()
    {
        m_IsJump = false;
        m_CanCreateShockWave = false;
        m_IsDead = false;

        m_CurrentState = State.Normal;
        m_BGMManager = GameObject.FindWithTag("BGMManager").GetComponent<BGMManager>();
        m_CurrentSpeed = 0;
        m_MagicChargeGage = 5;
        m_AMusicGage = 60;
        m_BMusicGage = 60;
        m_RB = GetComponent<Rigidbody2D>();
        m_ShockWaveCreatePoint = transform.Find("ShockWaveCreatePoint");

        m_Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (m_AMusicGage <= 0 && m_BMusicGage <= 0 && m_CurrentState == State.Normal)
        {
            m_Animator.SetTrigger("Die");
            m_Animator.ResetTrigger("Attack");
            m_Animator.ResetTrigger("Jump");
            m_Animator.ResetTrigger("HitDamage");
            transform.parent = null;
            m_CurrentState = State.Die;

            m_IsDead = true;
        }

        if (m_CurrentState == State.Normal)
        {
            Jump();
            bool attack = Input.GetMouseButtonDown(0) && m_MagicChargeGage >= 1;
            if (attack) m_Animator.SetTrigger("Attack");


            if(m_BGMManager.m_ABGM && m_AMusicGage < 0)
            {
                m_BGMManager.ChangeBGM();

                m_Particle.Play();
            }
            else if(!m_BGMManager.m_ABGM && m_BMusicGage < 0)
            {
                m_BGMManager.ChangeBGM();

                m_Particle.Play();
            }

            // BGMをチェンジする
            if (Input.GetButtonDown("ChangeBGM"))
            {

                if (m_BGMManager.m_ABGM)
                {
                    if(m_BMusicGage > 0)
                    {
                        change();
                    }
                }
                else
                {
                    if(m_AMusicGage > 0)
                    {
                        change();
                    }
                }

                void change()
                {
                    m_BGMManager.ChangeBGM();

                    m_Particle.Play();

                    if (m_CanCreateShockWave)
                    {
                        Instantiate(m_ShockWave, m_ShockWaveCreatePoint.position, Quaternion.identity);
                    }
                }
            }

            m_MagicChargeGage = Mathf.Clamp(m_MagicChargeGage + m_MagicChargeSpeed * Time.deltaTime, 0, 5);

            if (m_BGMManager.m_ABGM) m_AMusicGage -= Time.deltaTime;
            else m_BMusicGage -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (m_CurrentState == State.Normal)
        {
            Move();

            if (!m_IsJump) ChackIsGround();
        }
    }

    // 移動関数
    void Move()
    {
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveX = 1;

        //float accelerationSpeed = Time.deltaTime * m_AccelerationSpeed;

        //// 移動スピードを少しづつ最大値に近づける
        //if (moveX > 0) // 右が押された場合
        //{
        //    if (m_CurrentSpeed < m_MoveSpeed - 0.1f) m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_MoveSpeed, accelerationSpeed);
        //    else m_CurrentSpeed = m_MoveSpeed;

        //    transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        //}
        //else if (moveX < 0) // 左が押された場合
        //{
        //    if (m_CurrentSpeed > -m_MoveSpeed + 0.1f) m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, -m_MoveSpeed, accelerationSpeed);
        //    else m_CurrentSpeed = -m_MoveSpeed;

        //    transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        //}
        //else // 何も押されていない、もしくは両方が押されている場合
        //{
        //    if (Mathf.Abs(m_CurrentSpeed) > 0.1f) m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, 0, accelerationSpeed);
        //    else m_CurrentSpeed = 0.0f;
        //}

        //m_Animator.SetFloat("VelocityX", Mathf.Abs(moveX));
        //Vector2 newVelocity = new Vector2(m_CurrentSpeed, m_RB.velocity.y);
        //m_RB.velocity = newVelocity;

        m_Animator.SetFloat("VelocityX", 1);
    }

    // 魔法生成（アニメーションイベントで使用
    void CreateMagic()
    {
        Instantiate(m_BGMManager.m_ABGM ? m_AMagic : m_BMagic, m_MagicCreatePoint.position, m_MagicCreatePoint.transform.rotation);
        m_MagicChargeGage -= 1;
    }

    // ジャンプ
    void Jump()
    {
        // ジャンプが押されていない場合はreturn
        if (!Input.GetButtonDown("Jump")) return;

        // 接地していない場合はreturn
        if (m_IsJump) return;

        m_RB.AddForce(Vector2.up * m_JumpPower, ForceMode2D.Impulse);
        m_Animator.SetTrigger("Jump");
        m_Animator.ResetTrigger("JumpEnd");
        m_IsJump = true;

        StartCoroutine(CanJump());

    }

    IEnumerator CanJump()
    {
        yield return new WaitForSeconds(0.2f);

        while (true)
        {
            LayerMask layer = 1 << LayerMask.NameToLayer("Floor");
            RaycastHit2D boxCast = Physics2D.BoxCast(m_BoxCastOrigin.position, new Vector2(1, 1), 0, -transform.up, 0.1f, layer);

            m_IsJump = boxCast.collider == null;

            if (!m_IsJump)
            {
                m_Animator.SetTrigger("JumpEnd");
                yield break;
            }

            yield return null;
        }
    }

    // 接地しているかを調べる
    void ChackIsGround()
    {
        LayerMask layer = 1 << LayerMask.NameToLayer("Floor");
        RaycastHit2D boxCast = Physics2D.BoxCast(m_BoxCastOrigin.position, new Vector2(1, 1), 0, -transform.up, 0.1f, layer);

        m_IsJump = boxCast.collider == null;

        if (m_IsJump)
        {
            StartCoroutine(CanJump());
            m_Animator.SetTrigger("Jump");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(m_BoxCastOrigin.position, new Vector2(1, 1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeBGMPoint")) m_CanCreateShockWave = true;

        if (collision.CompareTag("OrangeEnemy") || collision.CompareTag("PurpleEnemy") || collision.CompareTag("LargeEnemy"))
        {
            if (m_BGMManager.m_ABGM)
            {
                m_AMusicGage -= 5;
            }
            else
            {
                m_BMusicGage -= 5;
            }
            m_Animator.SetTrigger("HitDamage");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeBGMPoint")) m_CanCreateShockWave = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EdgeScreen")) Destroy(gameObject);
    }
}
