using UnityEngine;

public class TestScript : MonoBehaviour
{
    private bool isTesting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputManager.I.OnLClickStart += () => isTesting = true;
        InputManager.I.OnLClickEnd += () => isTesting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTesting)
            print("test");
    }

    private void Test()
    {
        Debug.Log("Test");
    }
}
