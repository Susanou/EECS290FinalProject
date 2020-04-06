using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(knifeSwing());

        }
    }
    private IEnumerator knifeSwing()
    {
        _animator.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        _animator.SetBool("attacking", false);


    }
}
