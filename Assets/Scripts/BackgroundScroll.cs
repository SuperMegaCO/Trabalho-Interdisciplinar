using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // Scroll main texture based on time

    float scrollSpeed = .25f;
    public Material background;

    void Start()
    {
      
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed ;
        background.mainTextureOffset = new Vector2(0,-offset);
    }
}