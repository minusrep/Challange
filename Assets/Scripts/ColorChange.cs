using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private int type;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        type = GetComponent<Trader>().Type;
        switch (type)
        {
            case 1:
                meshRenderer.material.color = Color.green;
                break;
            case 2:
                meshRenderer.material.color = Color.red;
                break;
        }
    }
}
