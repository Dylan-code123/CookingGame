using UnityEngine;

public class FryingThing : MonoBehaviour
{
    SpriteRenderer thisSprite;
    public FryTheThing thing;

    public float timeFried; 
    public float maxTime = 2f;

    public bool doneFry;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                hit.collider.gameObject.transform.position = mousePos;
            }
        }

        if ((Vector3.Distance(transform.position, thing.transform.position) <= thing.areaOfMargin))
        {
            timeFried += Time.deltaTime;
        }


        Color color = Color.white;

        float time = Mathf.PingPong(timeFried, maxTime);
        thisSprite.color = Color.Lerp(Color.white, Color.black, time);

        if (timeFried >= maxTime)
        {
            doneFry = true;
            thisSprite.color = Color.green;
        }

    }
}
