using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BirdRB;
   
    //private Camera _camera;
    private bool isCliked = false;

    private void Start()
    {
        BirdRB = GetComponent<Rigidbody2D>();
        //_camera = Camera.main;
              
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
        StartCoroutine(Fly());
    }
     
    IEnumerator Fly(){
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent < SpringJoint2D >().enabled = false;
        this.enabled = false;
    }
}

