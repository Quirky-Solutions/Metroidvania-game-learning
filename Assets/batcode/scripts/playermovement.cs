using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private void Start()
    {
        Debug.Log("This is start function!");
    }

    private void Update()
    {
        transform.Translate(new Vector2(1,0) * Time.deltaTime * movementSpeed);
    }
}
