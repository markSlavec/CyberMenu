using UnityEngine;

// ����� ���������� ��������� ����
public class SmokeMovement : MonoBehaviour
{
    // �������� ��������
    public float rotationSpeed = 1.0f;

    // �������� ������������
    public float minOpacity = 0.5f;
    public float maxOpacity = 1.0f;

    // �������� ������� (� ��������)
    public float timerInterval = 3.0f;

    // ���������� �������
    float timer;
    bool timerActive;

    // ���������� ��� ���������/���������� ��������� ������������
    public bool enableOpacityChange = true;

    // ������ �� ��������� Renderer
    Renderer renderer;

    void Start()
    {
        // �������� ������ �� ��������� Renderer
        renderer = GetComponent<Renderer>();
    }

    void FixedUpdate()
    {
        // Rotate the smoke game object
        transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);

        // Update the timer
        timer += Time.fixedDeltaTime;


        // Check if the opacity change is enabled
        if (enableOpacityChange)
        {
            if (timer >= timerInterval)
            {
                // Reset the timer
                timer = 0.0f;

                // Toggle the timer active flag
                timerActive = !timerActive;
            }

            // Calculate the timer value as a proportion of the interval
            float t = timer / timerInterval;

            // Modify the opacity of the smoke game object based on the timer value
            float opacity;
            if (timerActive)
            {
                // Interpolate from minOpacity to maxOpacity
                opacity = Mathf.SmoothStep(minOpacity, maxOpacity, t);
            }
            else
            {
                // Interpolate from maxOpacity to minOpacity
                opacity = Mathf.SmoothStep(maxOpacity, minOpacity, t);
            }
            Color color = renderer.material.color;
            renderer.material.color = new Color(color.r, color.g, color.b, opacity);
        }
    }
}