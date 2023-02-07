using UnityEngine;

public class TemporaryTestScript : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    [Tooltip("Event to call when pressing number key 7")]
    private GameEvent event7;

    [SerializeField]
    [Tooltip("Event to call when pressing number key 8")]
    private GameEvent event8;

    [SerializeField]
    [Tooltip("Event to call when pressing number key 9")]
    private GameEvent event9;

    [SerializeField]
    [Tooltip("Event to call when pressing number key 0")]
    private GameEvent event0;
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Starting temporary test script.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("Raising test event 7");
            if (event7 != null) event7.Raise();
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Raising test event 8");
            if (event8 != null) event8.Raise();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("Raising test event 9");
            if (event9 != null) event9.Raise();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Raising test event 0");
            if (event0 != null) event0.Raise();
        }
    }
#endif
}
