using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public float fSmoothTimeX, fSmoothTimeY;

	public float fCameraGapX, fCameraGapY = 1.3f;

	public Vector2 velocity;

	public GameObject player;

	public Vector2 minPos, maxPos;

	public bool bBound;

    private void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player");

	}
    void FixedUpdate()
	{

		float fPosX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x + fCameraGapX, ref velocity.x, fSmoothTimeX);

		// Mathf.SmoothDamp는 천천히 값을 증가시키는 메서드이다.

		float fPosY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y + fCameraGapY, ref velocity.y, fSmoothTimeY);

		// 카메로 이동

		transform.position = new Vector3(fPosX, fPosY, transform.position.z);



		if (bBound)
		{

			//Mathf.Clamp(현재값, 최대값, 최소값);  현재값이 최대값까지만 반환해주고 최소값보다 작으면 그 최소값까지만 반환합니다.

			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),

				Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),

				Mathf.Clamp(transform.position.z, transform.position.z, transform.position.z)

			);

		}

	}

}
