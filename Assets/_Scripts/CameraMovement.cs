using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed;
    public float smoothTime;
    public float elasticity = 0.2f;

    private bool isDragging;

    public Vector2 clampBoundsMin;
    public Vector2 clampBoundsMax;


    private Vector3 lastInputPosition;
    private Vector3 deltaInput;

    private Vector3 camFollowPos;

    private Vector3 newPosition;

    private bool hasSelection;
    private Vector3 selectionTargetPos;

    private Camera cam;
    private void Awake()
    {
       cam = Camera.main;
    }

    private void Start()
    {
        newPosition = cam.transform.position;
    }

    private void Update()
    {
        UserInput();
        MoveCamera();
    }

    private void UserInput()
    {
        if (hasSelection) return;

        if (Input.GetMouseButtonDown(0))
        {
            lastInputPosition = Input.mousePosition;
            deltaInput = Vector3.zero;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0))
        {
            deltaInput = (Input.mousePosition - lastInputPosition);
            lastInputPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
    private void MoveCamera()
    {
        if (isDragging)
        {
            newPosition = newPosition - deltaInput * panSpeed * Time.deltaTime;

            newPosition.x = Mathf.Clamp(newPosition.x, clampBoundsMin.x * 1.5f, clampBoundsMax.x * 1.5f);
            newPosition.y = Mathf.Clamp(newPosition.y, clampBoundsMin.y * 1.5f, clampBoundsMax.y * 1.5f);

            newPosition += deltaInput * Time.deltaTime;

            camFollowPos = newPosition;
        }
        else
        {
            newPosition.x = Mathf.Lerp(newPosition.x, Mathf.Clamp(newPosition.x, clampBoundsMin.x, clampBoundsMax.x), elasticity * Time.deltaTime);
            newPosition.y = Mathf.Lerp(newPosition.y, Mathf.Clamp(newPosition.y, clampBoundsMin.y, clampBoundsMax.y), elasticity * Time.deltaTime);

            camFollowPos = newPosition;
        }

        if (hasSelection)
        {
            camFollowPos = selectionTargetPos;
            newPosition = selectionTargetPos;
        }

        Vector3 smoothLerpPos = Vector3.Lerp(cam.transform.position, camFollowPos, smoothTime * Time.deltaTime);
        cam.transform.position = new Vector3(smoothLerpPos.x, smoothLerpPos.y, cam.transform.position.z);
    }

    public void Select(Vector3 pos, bool selected)
    {
        selectionTargetPos = pos - Vector3.up*5;
        hasSelection = selected;
    }

}
