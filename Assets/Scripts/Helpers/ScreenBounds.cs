using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBounds : MonoBehaviour {
    static Camera mainCamera;
    static BoxCollider2D boxCollider;

    ScreenBounds bounds;

    public UnityEvent<Collider2D> ExitTriggerFired { get; private set; }

    [SerializeField]
    [Tooltip("Increase offset to haveo objects trigger the event when they've gone past the bounds")]
    float BoundsOffset = 0.5f;

    static float boundsOffset = 0.2f;

    private void Awake() {
        if(bounds == null) {
            bounds = this;
        }
        else if (bounds != this) {
            Debug.LogError("Multiple ScreenBounds instances detected, bounds calculations might be problematic!");
        }

        mainCamera = Camera.main;
        boxCollider = GetComponent<BoxCollider2D>();
        if (mainCamera.transform.localScale != Vector3.one) {
            Debug.LogError($"Camera's scale is {mainCamera.transform.localScale} instead of (1,1,1), bounds calculations will be problematic!");
        }
        if (!mainCamera.orthographic) {
            Debug.LogError("Camera isn't set to orthographic, bounds calculations will be problematic!");
        }
        if (!boxCollider.isTrigger) {
            Debug.LogWarning("Bounds collider wasn't set to trigger!");
            boxCollider.isTrigger = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        UpdateBoundsSize();
    }

    public void UpdateBoundsSize() {
        ScreenBounds.boundsOffset = BoundsOffset;
        // set camera position to zero
        transform.position = Vector3.zero;
        // orhographicSize = half the height of the screen
        float ySize = mainCamera.orthographicSize * 2;
        // width is calculate by multiplying y with aspect ratio
        boxCollider.size = new Vector2(ySize * mainCamera.aspect + ScreenBounds.boundsOffset, ySize + ScreenBounds.boundsOffset);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        ExitTriggerFired?.Invoke(collision);
    }

    public static bool AmIOutOfBounds(Vector3 worldPosition) {

        // note: the following logic works only when bounds min equals bounds max!
        return (IsXOutOfBounds(worldPosition) || IsYOutOfBounds(worldPosition));
    }

    public static Vector3 CalculateScreenWrapPosition(Vector3 worldPosition) {
        Vector2 worldPosition2D = worldPosition;
        bool isXOutOfBounds = IsXOutOfBounds(worldPosition2D);
        bool isYOutOfBounds = IsYOutOfBounds(worldPosition2D);

        // used to create and reverse coordinates of offset vector in XY, X or Y axis
        Vector2 signVector = new Vector2(Mathf.Sign(worldPosition2D.x), Mathf.Sign(worldPosition2D.y));
        Vector2 offset = new Vector2(boundsOffset * 0.5f, boundsOffset * 0.5f);

        // TODO: logic breaks down if asteroid is out of bounds AND not moving inwards


        // out in both X and Y
        if (isXOutOfBounds && isYOutOfBounds) {
            //offset *= signVector;
            worldPosition2D = new Vector2(worldPosition2D.x * -1, worldPosition2D.y * -1) + offset;
            Debug.DrawRay(worldPosition, offset, Color.magenta, 1.0f);
        }
        // out in only X
        else if (isXOutOfBounds) {
            //Vector2 offset = new Vector2(boundsOffset * signVector.x, boundsOffset);
            offset.y = 0;
            offset *= signVector;
            worldPosition2D = new Vector2(worldPosition2D.x * -1, worldPosition2D.y) + offset;
            Debug.DrawRay(worldPosition, offset, Color.cyan, 1.0f);
        }
        // out in only Y
        else if (isYOutOfBounds) {
            //Vector2 offset = new Vector2(boundsOffset, boundsOffset * signVector.y);
            offset.x = 0; 
            offset *= signVector;
            worldPosition2D = new Vector2(worldPosition2D.x, worldPosition2D.y * -1) + offset;
            Debug.DrawRay(worldPosition, offset, Color.yellow, 1.0f);
        }

        Debug.DrawLine(worldPosition, new Vector3(worldPosition2D.x, worldPosition2D.y, worldPosition.z), Color.white, 1f);
        return new Vector3(worldPosition2D.x, worldPosition2D.y, worldPosition.z);
    }

    private static bool IsXOutOfBounds(Vector2 worldPosition) {
        // note: the following logic works only when bounds min equals bounds max!
        return Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x);
    }

    private static bool IsYOutOfBounds(Vector2 worldPosition) {
        // note: the following logic works only when bounds min equals bounds max!
        return Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);
    }

    /// <summary>
    /// Get random Vector2 position within bounds. 
    /// </summary>
    public static Vector2 GetRandomPosition() {
        return new Vector2(
            Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
            Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y)
            );
    }
}
