using UnityEngine;

public class SelectionAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 initialPosition;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.5f);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}