using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class ToWin : MonoBehaviour
{
    public GameObject transitioningGameObject;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == transitioningGameObject)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}