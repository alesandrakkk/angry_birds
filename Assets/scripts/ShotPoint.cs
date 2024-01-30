using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShotPoint : MonoBehaviour
{
    [SerializeField] private float maxDistance = 2;
    public Vector2 shootingPos;
    private Camera _camera;
    public UnityEvent<Vector2> onRelease;


    void Start()
    {
        shootingPos = transform.position;

    }

    void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(shootingPos, mousePos) < maxDistance)
        {
            transform.position = mousePos;
        }
        else
        {
            var direction = (mousePos - shootingPos).normalized * maxDistance;
            transform.position = shootingPos + direction;
        }
    }

    void OnMouseUp()
    {
        Vector2 endPoint = transform.position;
        transform.position = shootingPos;
        Vector2 force = endPoint - shootingPos;
        onRelease?.Invoke(force.normalized * (force.magnitude / maxDistance));
    }

}
