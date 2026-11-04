using UnityEngine;

public class TestScript : MonoBehaviour
{
    private bool isTesting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputManager.I.OnLClickStarted += () => isTesting = true;
        InputManager.I.OnLClickEnded += () => isTesting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTesting)
            Test();
    }

    private void Test()
    {
        Debug.Log("Test");
    }
}
