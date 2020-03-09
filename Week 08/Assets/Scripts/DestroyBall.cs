using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    Material material;
    bool isFading = false;
    [SerializeField] float fadeSpeed = 10f;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // Schedule the fade out as soon as the ball is created, so that we don't accumulate
        // a whole bunch on top of the court.
        Invoke("StartFading", 6f);
    }
    
    void StartFading()
    {
        isFading = true;
    }

    void Update()
    {
        if (transform.position.y < -20)
        {
            StartFading();
        }

        if (isFading)
        {
            // Move towards fully transparent and then destroy when we hit transparent!
            float fadeAmount = fadeSpeed * Time.deltaTime;
            Color newColor = Color.Lerp(material.color, Color.clear, fadeAmount);
            material.color = newColor;
            if (material.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }
    }
}
