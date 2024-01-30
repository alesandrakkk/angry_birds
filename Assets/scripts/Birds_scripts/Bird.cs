using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public  class Bird : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
    }

    public void Flight( Vector2 direction) {
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }
}
