using UnityEngine;

public class RevolveOnStadium : MonoBehaviour
{
    public Transform stadiumTransform;    // Reference to the stadium's Transform
    public float rotationSpeed = 2f;      // Speed of rotation around the circumference of the stadium
    public float spinSpeed = 30f;
    [SerializeField] private float currentAngle = 0f;
    public float targetRadius = 0f;

    void Update()
    {
        RotateAroundStadium();
        SpinAroundYAxis();
    }

    void RotateAroundStadium()
    {
        if (stadiumTransform == null)
        {
            Debug.LogError("Stadium Transform not assigned in the inspector!");
            return;
        }

        // Calculate the desired position in a circular orbit around the circumference of the stadium
        currentAngle += Time.deltaTime * rotationSpeed;
        float x = Mathf.Cos(currentAngle) * targetRadius;
        float y = 0f;
        float z = Mathf.Sin(currentAngle) * targetRadius;

        // Set the object's position to the calculated orbit position relative to the stadium
        transform.position = Vector3.Lerp(transform.position, stadiumTransform.position + new Vector3(x, y, z), Time.deltaTime * 5f);
    }

    // Call this method to change the revolve radius smoothly
    public void ChangeRevolveRadius(float newRadius)
    {
        targetRadius = newRadius;
        currentAngle = Mathf.Atan2(transform.position.z - stadiumTransform.position.z, transform.position.x - stadiumTransform.position.x);
    }

    void SpinAroundYAxis()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}