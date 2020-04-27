using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class ToWin : MonoBehaviour
{
    public GameObject transitioningGameObject;
    public string newSceneName;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == transitioningGameObject)
        {
            TransitionInternal();
        }
    }

    protected void TransitionInternal()
    {
        SceneManager.LoadScene(newSceneName, LoadSceneMode.Single);
    }
}