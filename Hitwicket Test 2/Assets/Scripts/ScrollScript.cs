using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{
    public ScrollRect scrollview;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 5; i++)
        {
            generateItem(i);
        }
        scrollview.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateItem(int itemNumber)
    {
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        scrollItemObj.transform.Find("itemnum").gameObject.GetComponent<Text>().text = itemNumber.ToString();
    }
}
