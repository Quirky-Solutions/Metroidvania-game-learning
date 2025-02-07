using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private float followSpeed = 0.1f;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playermotion.Instance.transform.position + offset, followSpeed);  
    }
}
