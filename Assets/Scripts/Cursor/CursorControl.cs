using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{
    Camera MainCamera;

    private void Awake()
    {
        MainCamera = Camera.main;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        transform.position = cursorPos;
    }
}
