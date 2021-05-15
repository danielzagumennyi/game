using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUiController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool open;
    public GameObject UIObject;

    public bool Open
    {
        get
        {
            return open;
        }

        set
        {
            UIObject.SetActive(value);
            open = value;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
          Open = !Open;
        }
    }
}
