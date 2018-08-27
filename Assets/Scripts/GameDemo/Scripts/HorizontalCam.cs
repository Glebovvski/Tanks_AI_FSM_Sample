using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCam : MonoBehaviour {

    [SerializeField]
    private Transform target;

    private Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetPosition = transform.position;
        targetPosition.z = target.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);
	}
}
