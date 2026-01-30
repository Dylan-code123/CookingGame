using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ClickToChop : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] Sprite imageAfterChop;

    public int chopCounter;
    [SerializeField] int chopMax = 5;
    public string nextSceneName;


    public TextMeshProUGUI chops;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                chopCounter++;
            }
        }

        if (chopCounter >= chopMax)
        {
            sprite.sprite = imageAfterChop;

            StartCoroutine(LoadNextScene());
        }

        chops.text = chopCounter + " / " + chopMax;
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }
}
