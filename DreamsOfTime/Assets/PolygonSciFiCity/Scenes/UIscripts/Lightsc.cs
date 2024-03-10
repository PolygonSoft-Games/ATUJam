using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsc : MonoBehaviour
{

    public Light isik;
    public bool acik;

    public int zaman;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Degis());

    }

    // Update is called once per frame
    void Update()
    {

        zaman = Random.Range(1, 2);

        if (acik)
        {
            isik.enabled = true;
        }
        if (!acik) 
        {
            isik.enabled = false; 
        
        }

    }

    IEnumerator Degis()
    {
        acik = !acik;
        yield return new WaitForSeconds(zaman);
        acik = !acik;
        yield return new WaitForSeconds(zaman);
        Yeniden();

    }

    void Yeniden ()
    {
        StartCoroutine (Degis());

    }

}
