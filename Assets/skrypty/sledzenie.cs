using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Gracz, którego chcemy œledziæ
    public float smoothSpeed = 0.125f; // Wspó³czynnik p³ynnoœci kamery
    public Vector3 offset; // Przesuniêcie kamery

    public Vector2 minXMinMax = new Vector2(-3.85f, 3.55f);
    public Vector2 minYMinMax = new Vector2(2.6f, 4.53f);

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;

            // Ograniczenia kamery
            float clampedX = Mathf.Clamp(desiredPosition.x, minXMinMax.x, minXMinMax.y);
            float clampedY = Mathf.Clamp(desiredPosition.y, minYMinMax.x, minYMinMax.y);
            desiredPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
