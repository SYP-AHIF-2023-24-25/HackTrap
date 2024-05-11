using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionAnimation : MonoBehaviour
{
    public Texture2D newTexture; // Assign the new texture in the inspector

    public int newWidth = 2800;
    public int newHeight = 1450;

    void Start()
    {
        Image image = GetComponent<Image>();
        if (image != null && newTexture != null)
        {
            // Resize the texture
            Texture2D resizedTexture = ResizeTexture(newTexture, newWidth, newHeight);

            // Create a sprite from the resized texture
            Sprite newSprite = Sprite.Create(resizedTexture, new Rect(0, 0, newWidth, newHeight), Vector2.one * 0.5f);

            // Assign the sprite to the image component
            image.sprite = newSprite;
        }
    }

    Texture2D ResizeTexture(Texture2D originalTexture, int newWidth, int newHeight)
    {
        // Create a new texture and resize the original texture to the desired dimensions
        Texture2D resizedTexture = new Texture2D(newWidth, newHeight);
        Graphics.ConvertTexture(originalTexture, resizedTexture);
        return resizedTexture;
    }
}
