using UnityEngine;

public class TrackMover : MonoBehaviour
{
    public float speed = 5f;
    public float resetPositionZ = -20f;
    public float startPositionZ = 40f;

    private void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if (transform.position.z <= resetPositionZ)
        {
            Vector3 newPos = transform.position;
            newPos.z = startPositionZ;
            transform.position = newPos;
        }
    }
}
