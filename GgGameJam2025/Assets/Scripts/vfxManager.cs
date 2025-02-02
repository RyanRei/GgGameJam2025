using UnityEngine;
using System.Collections;
using UnityEngine.VFX;

public class vfxManager : MonoBehaviour
{
    public VisualEffect vfxUlt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    private IEnumerator ultVfx()
    {
        vfxUlt.enabled = true;
        yield return new WaitForSeconds(2.1f);
        vfxUlt.enabled = false;
    }
}
