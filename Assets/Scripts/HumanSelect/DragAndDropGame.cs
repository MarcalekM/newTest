using UnityEngine;
using TMPro;

public class DragAndDropGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;
    private int points = DataManager.GetMyIntData();

    private bool isDragging = false;
    private GameObject draggedObject;
    private Vector2 initialPosition;

    public Transform target1;
    public Transform target2;
    public Transform target3;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    HandleTouchBegin(touch.position);
                    break;
                case TouchPhase.Moved:
                    HandleTouchMoved(touch.position);
                    break;
                case TouchPhase.Ended:
                    HandleTouchEnded();
                    break;
            }
        }
        TextMeshProUGUI.text = points.ToString();
    }

    void HandleTouchBegin(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            isDragging = true;
            draggedObject = hit.collider.gameObject;
            initialPosition = draggedObject.transform.position;
        }
    }

    void HandleTouchMoved(Vector2 touchPosition)
    {
        if (isDragging)
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            draggedObject.transform.position = new Vector3(newPosition.x, newPosition.y, 0);
        }
    }

    void HandleTouchEnded()
    {
        if (isDragging)
        {
            isDragging = false;

            CheckDropZone(draggedObject);
        }
    }

    void CheckDropZone(GameObject draggedObject)
    {
        if (target1.GetComponent<Collider2D>().OverlapPoint(draggedObject.transform.position) && target1.tag == draggedObject.tag)
        {
            points++;
            Debug.Log("Object dropped on Target 1");
            Destroy(draggedObject);
        }
        else if (target2.GetComponent<Collider2D>().OverlapPoint(draggedObject.transform.position) && target2.tag == draggedObject.tag)
        {
            points++;
            Debug.Log("Object dropped on Target 2");
            Destroy(draggedObject);
        }
        else if (target3.GetComponent<Collider2D>().OverlapPoint(draggedObject.transform.position) && target3.tag == draggedObject.tag)
        {
            points++;
            Debug.Log("Object dropped on Target 3");
            Destroy(draggedObject);
        }
        else
        {
            draggedObject.transform.position = initialPosition;
        }
    }
}
