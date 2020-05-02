using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack: MonoBehaviour
{

    public int dmg;
    public float kbtime;
    public float thrust;
    public Transform origin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int mask = LayerMask.GetMask("Enemy");
        RaycastHit2D hit = Physics2D.Raycast((Vector2)origin.position, (Vector2)other.transform.position, Mathf.Infinity, mask);
        Debug.Log(hit.collider);
        if (hit.collider.tag != "walls")
        {
            if (other.gameObject.CompareTag("Damageable"))
            {


                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    Debug.Log("Knocking Bakc");

                    enemy.GetComponent<WanderingAI>().currentState = EnemyState.stagger;
                    Vector2 difference = enemy.gameObject.transform.position - this.transform.position;
                    difference = difference.normalized * thrust;

                    enemy.AddForce(difference, ForceMode2D.Impulse);

                    StartCoroutine(KnockCo(enemy));

                }
            }
            else if (other.gameObject.CompareTag("BossEpi"))
            {
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    Debug.Log("Knocking Bakc");

                    enemy.GetComponent<BossEpi>().currentState = BossState.stagger;
                    Vector2 difference = enemy.gameObject.transform.position - this.transform.position;


                    difference = difference.normalized * thrust;

                    enemy.AddForce(difference, ForceMode2D.Impulse);

                    StartCoroutine(BossEpiKnockCo(enemy));
                }
            }
            else if (other.gameObject.CompareTag("BossHallah"))
            {
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    Debug.Log("Knocking Bakc");

                    enemy.GetComponent<BossHallah>().currentState = BossState.stagger;
                    Vector2 difference = enemy.gameObject.transform.position - this.transform.position;
                    difference = difference.normalized * thrust;

                    enemy.AddForce(difference, ForceMode2D.Impulse);

                    StartCoroutine(BossHallahKnockCo(enemy));
                }
            }
            else if (other.gameObject.CompareTag("BossDoughnut"))
            {
                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {

                    enemy.GetComponent<BossDoughnut>().currentState = BossState.stagger;
                    Vector2 difference = enemy.gameObject.transform.position - this.transform.position;

                    difference = difference.normalized * thrust;
                    enemy.AddForce(difference, ForceMode2D.Impulse);

                    StartCoroutine(BossDoughnutKnockCo(enemy));
                }
            }

            if (!this.CompareTag("DeadFriend") && other.CompareTag("Player") && other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
            {


                Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
                if (enemy != null)
                {
                    Debug.Log("Knocking Bakc player");

                    enemy.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    Vector2 difference = enemy.gameObject.transform.position - this.transform.position;
                    difference = difference.normalized * thrust;

                    enemy.AddForce(difference, ForceMode2D.Impulse);

                    StartCoroutine(PlayerKnockCo(enemy));
                    other.GetComponent<PlayerMovement>().hurt(dmg);

                }


            }
        }
    }

    private IEnumerator PlayerKnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime + 0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<PlayerMovement>().currentState = PlayerState.walk;
        }
    }

    private IEnumerator KnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime+0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<WanderingAI>().currentState = EnemyState.pursuit;
        }
    }

    private IEnumerator BossEpiKnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime+0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<BossEpi>().currentState = BossState.walk;
        }
    }

    private IEnumerator BossHallahKnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime + 0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<BossHallah>().currentState = BossState.walk;
        }
    }

    private IEnumerator BossDoughnutKnockCo(Rigidbody2D e)
    {
        if (e != null)
        {
            yield return new WaitForSeconds(kbtime + 0.5f);
            e.velocity = Vector2.zero;
            e.GetComponent<BossDoughnut>().currentState = BossState.walk;
        }
    }
}
