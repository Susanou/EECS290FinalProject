using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

//this is from the 2D GameKit Code with some modifications to fit our use case.
[RequireComponent(typeof(Collider2D))]
public class TransporterScript : MonoBehaviour
{
    
        public GameObject transitioningGameObject;
        public string newSceneName;
        public TransportEndpoint.DestinationTag transitionDestinationTag;
        [Tooltip("The player will lose control when the transition happens but should the axis and button values reset to the default when control is lost.")]
        bool m_TransitioningGameObjectPresent;


        void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject == transitioningGameObject)
            {
                m_TransitioningGameObjectPresent = true;
                TransitionInternal ();
            }
        }

        void OnTriggerExit2D (Collider2D other)
        {
            if (other.gameObject == transitioningGameObject)
            {
                m_TransitioningGameObjectPresent = false;
            }
        }

        void Update ()
        {
            if(!m_TransitioningGameObjectPresent)
                return;
        }

        protected void TransitionInternal ()
        {
            SceneManager.LoadScene(newSceneName, LoadSceneMode.Single);
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
        }

}
