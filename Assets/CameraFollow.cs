using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float lerpSpeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetTransform.position + offset, lerpSpeed * Time.deltaTime);
    }
}
