using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public KeyCode up { get; set; }
    public KeyCode down { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }
    public KeyCode leftClick { get; set; }
    public KeyCode rightClick { get; set; }

    public bool inputDetected()
    {
        if (Input.anyKey)
            return true;
        return false;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        up = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("upKey", "W"));
        down = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("downKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        leftClick = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("shootKey", "Mouse0"));
        rightClick = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rotateKey", "Mouse1"));
    }

    private void Awake()
    {
        SingletonAwake();
    }
}
