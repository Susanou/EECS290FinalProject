using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public enum EnemyState
{
    pursuit,
    attack,
}

public class WanderingAI : MonoBehaviour {
    public float dist;
    public float giveUp;
    public float attackRange;
    public int speed;

    public EnemyState currentState;

    [SerializeField] private GameObject target;

    private Vector2 change;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private Vector2 originalPos;

    void Start() {

        myRigidbody = this.GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        myAnimator = this.GetComponent<Animator>();

        originalPos = this.transform.position;
        currentState = EnemyState.pursuit;

        myAnimator.SetFloat("changeX", 0);
        myAnimator.SetFloat("changeY", -1);
    }

    void Update()
    {
        change = Vector2.zero;
        change = target.transform.position - this.transform.position;

        if (change.magnitude <= attackRange && currentState != EnemyState.attack)
        {
            StartCoroutine(attack());
        }

        else if (change.magnitude < dist && currentState == EnemyState.pursuit)
        {
            updateMoveAndAnimation();
        }
        else if (change.magnitude >= giveUp)
        {
            Debug.Log("giving up");
            myAnimator.SetBool("walking", false);
            myAnimator.SetFloat("changeX", 0);
            myAnimator.SetFloat("changeY", -1);
        }


    }

    void updateMoveAndAnimation()
    {

        if (change != Vector2.zero)
        {
            MoveCharacter();

            if (change.x != 0)
            {
                myAnimator.SetFloat("changeX", Mathf.Sign(change.x) * 1);
                myAnimator.SetFloat("changeY", 0);
            }
            else
            {
                myAnimator.SetFloat("changeX", 0);
                myAnimator.SetFloat("changeY", Mathf.Sign(change.y)*1);
            }


            myAnimator.SetBool("walking", true);

        }
        else
            myAnimator.SetBool("walking", false);
    }

    private IEnumerator attack()
    {
        myAnimator.SetBool("attacking", true);
        currentState = EnemyState.attack;
        yield return null;
        myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(3f);
        currentState = EnemyState.pursuit;
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition((Vector2)this.transform.position + change * speed * Time.deltaTime);

    }


    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.cyan;
        UnityEditor.Handles.DrawWireDisc(this.transform.position, this.transform.forward, this.dist);

        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(this.transform.position, this.transform.forward, this.giveUp);

        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(this.transform.position, this.transform.forward, this.attackRange);
    }



}
  


      


