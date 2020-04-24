using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{

    public string spread1;
    public string spread2;

    private string spread;
    private Animator _animator;
    private PlayerMovement movement;
    [SerializeField] GameObject swoosh;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        movement = this.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AttackSpread1()
    {
        spread = spread1;
        StartCoroutine(knifeSwing());
    }

    public void AttackSpread2()
    {
        spread = spread2;
        StartCoroutine(knifeSwing());
    }

    private IEnumerator knifeSwing()
    {
        _animator.SetBool("attacking", true);
        movement.currentState = PlayerState.attack;
        swoosh.SetActive(true);
        yield return null;
        _animator.SetBool("attacking", false);
        yield return new WaitForSeconds(0.5f);
        swoosh.SetActive(false);
        movement.currentState = PlayerState.walk;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Damageable"))
        {
            other.GetComponent<Befriend>().hurt(spread);
        }
        else if (other.CompareTag("BossEpi"))
        {
            other.GetComponent<BossEpi>().hurt(spread);
        }else if (other.CompareTag("BossHallah"))
        {
            other.GetComponent<BossHallah>().hurt(spread);
        }
    }
}
