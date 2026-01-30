using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private bool hasBeenClicked = false;

    [Header("Visual Feedback")]
    public Color clickedColor = Color.gray;
    public float shrinkSpeed = 2f;

    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;
    private bool shrinking = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (shrinking)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * shrinkSpeed);

            if (transform.localScale.x < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnMouseDown()
    {
        if (!hasBeenClicked && gameManager != null)
        {
            hasBeenClicked = true;
            gameManager.ObjectClicked();

            // Visual feedback
            if (spriteRenderer != null)
            {
                spriteRenderer.color = clickedColor;
            }

            shrinking = true;

            // Optional: Play sound effect here
            // AudioSource.PlayClipAtPoint(clickSound, transform.position);
        }
    }
}