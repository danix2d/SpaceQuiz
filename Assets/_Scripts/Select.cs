using UnityEngine;

public class Select : MonoBehaviour
{
    public GameEvent HasSelected;

    public bool selected;
    private GameObject selectedObject;

    private CameraMovement cameraPan;
    private QuestionBuilder questionBuilder;

    private QuestionHolder questionHolder;
    
    private void Awake()
    {
        cameraPan = GetComponent<CameraMovement>();
        questionBuilder = GetComponent<QuestionBuilder>();
    }
    private void Update()
    {
        MakeSelection();
    }

    private void MakeSelection()
    {
        if (selected) { return; }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Asteroid"))
            {
                selected = true;
                HasSelected.Raise();
                selectedObject = hit.collider.gameObject;

                cameraPan.Select(selectedObject.transform.position, true);

                questionHolder = selectedObject.GetComponent<QuestionHolder>();

                selectedObject.GetComponent<Asteroid_VFX>().InstanceVFX(questionHolder.questionSO.spriteImage);

                questionBuilder.BuildQuestion(questionHolder.questionSO);

                Destroy(hit.collider);
            }
        }
    }

    public void Deselect()
    {
        selected = false;
        cameraPan.Select(Vector3.zero, false);
    }
}