using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 12f;
    [SerializeField] float xLimit = 6f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [SerializeField] float yLimit = 3f;

    [SerializeField] float yRotSpeed = -2f;
    [SerializeField] float xRotSpeed = 8f;
    [SerializeField] float RollSpeed = -30f;


    float xThrow, yThrow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transformPosition();
        transformRotation();

    }

    private void transformRotation()
    {
        float roll = xThrow * RollSpeed;
        float yaw = transform.localPosition.x * xRotSpeed;
        float pitch = transform.localPosition.y * yRotSpeed * yThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void transformPosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Time.deltaTime * xSpeed;
        float xNewPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xLimit, xLimit);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Time.deltaTime * ySpeed;
        float yNewPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yLimit, yLimit);


        transform.localPosition = new Vector3(xNewPos,
                                              yNewPos,
                                              transform.localPosition.z);
    }
}
