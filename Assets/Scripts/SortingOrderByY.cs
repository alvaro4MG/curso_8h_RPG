using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SortingOrderByY : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        // Cuanto más bajo el objeto en Y, más adelante se dibuja
        spriteRenderer.sortingOrder = -(int)(transform.position.y * 100);
    }
}
