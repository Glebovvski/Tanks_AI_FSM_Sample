using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalCam : MonoBehaviour {

    [SerializeField]
    private Transform target;

    private Vector3 targetPositon;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void Update()
    {
        targetPositon = transform.position;
        targetPositon.z = target.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPositon, Time.deltaTime);
    }
}
