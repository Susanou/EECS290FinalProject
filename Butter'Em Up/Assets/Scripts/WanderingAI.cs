using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    [SerializeField] private GameObject knife;
    private GameObject _knife;

    private bool _alive;

    void Start() {
        _alive = true;
    }

    void Update() {
        if (_alive)
        {
            transform.Translate(Time.deltaTime, speed * Time.deltaTime, 0);

        }
        }

        public void SetAlive(bool alive) {
            _alive = alive;
        }
    }

