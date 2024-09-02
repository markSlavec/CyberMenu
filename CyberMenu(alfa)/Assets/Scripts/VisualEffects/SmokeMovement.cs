using UnityEngine;

// Класс управления движением дыма
public class SmokeMovement : MonoBehaviour
{
    // Скорость вращения
    public float rotationSpeed = 1.0f;

    // Диапазон прозрачности
    public float minOpacity = 0.5f;
    public float maxOpacity = 1.0f;

    // Интервал таймера (в секундах)
    public float timerInterval = 3.0f;

    // Переменные таймера
    float timer;
    bool timerActive;

    // Переменная для включения/выключения изменения прозрачности
    public bool enableOpacityChange = true;

    // Ссылка на компонент Renderer
    Renderer renderer;

    void Start()
    {
        // Получаем ссылку на компонент Renderer
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