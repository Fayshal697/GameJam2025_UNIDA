using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float speed = 1f;
    public float resetX = -20f;
    public float startX = 20f;
    
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= resetX)
        {
            Vector3 newPos = transform.position;
            newPos.x = startX;
            transform.position = newPos;
        }
    }
}
