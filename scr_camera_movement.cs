using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera_movement : MonoBehaviour
{
    public GameObject FollowTarget;
    public float MoveSpeed;

    private Vector3 TargetPos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        TargetPos = new Vector3(FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPos, MoveSpeed * Time.deltaTime);
	}
}
