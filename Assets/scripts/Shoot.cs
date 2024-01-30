using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class Shoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BirdRB;
    private bool isCliked = false;

    private void Awake()
    {
        BirdRB = GetComponent<Rigidbody2D>();
                     
    }
    private void Update()
    {
        if (isCliked == true)
        {
              BirdRB.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }

    }


    private void OnMouseDrag()
    {  
        isCliked = true;
        BirdRB.isKinematic = true;
        Debug.Log("Wait");
    }
    private void OnMouseUp()
    {
       isCliked = false;
        BirdRB.isKinematic = false;
        Debug.Log("I'm yours worst nightmare");
       // StartCoroutine(Fly());
    }
     
   
}

