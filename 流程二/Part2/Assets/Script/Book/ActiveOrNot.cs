using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOrNot : MonoBehaviour
{
    // Start is called before the first frame update
    public void Active()
    {
        this.gameObject.SetActive(true);
    }

    public void DisActive()
    {
        this.gameObject.SetActive(false);
    }
}
