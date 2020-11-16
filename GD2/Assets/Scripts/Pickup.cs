using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Animator anim;
    Inventory invScript;

    public bool item;
    public GameObject itemIcon;

    bool pickedup = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindWithTag("Player").GetComponent<Animator>();
        invScript = GameObject.FindWithTag("GameController").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerStay(Collider player)
    {
        if (player.tag == "Player")
        {
            if(!pickedup)
            {
                pickedup = true;
                StartCoroutine("PlayAnim");
            }
        }
    }
    IEnumerator PlayAnim()
    {
        anim.SetTrigger("pickup");
        yield return new WaitForSeconds(1);
        if (item)
        {
            GameObject i = Instantiate(itemIcon);
            i.transform.SetParent(invScript.invTab.transform);
            Destroy(gameObject);
        }
    }
}
