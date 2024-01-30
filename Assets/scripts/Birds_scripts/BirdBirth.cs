using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBirth : MonoBehaviour
{
    [SerializeField] private Bird birdPrefab;
    
    public Bird GetBird() {
        return Instantiate(birdPrefab, transform.position, Quaternion.identity);
    }
}
