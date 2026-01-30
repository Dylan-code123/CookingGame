using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FryTheThing : MonoBehaviour
{
    public GameObject AreaToFry;

    public float areaOfMargin = 2f;


    public FryingThing[] fryies;

    public bool allFried = false;
    public string nextSceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        AreaToFry = gameObject;
    }

    // Update is called once per frame
    void Update()
    {

       foreach (var fry in fryies)
       {
            if (fry.doneFry)
            {
                allFried = true;
            }
            else
            {
                allFried = false;
                return;
            }

       }

       if (allFried )
       {
            StartCoroutine(LoadNextScene());
       }

    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(transform.position, areaOfMargin);

    }
}
