using UnityEngine;

public class DrawingSystem : MonoBehaviour
{
    public Camera m_camera;
    public GameObject brush;

    private LineRenderer currentLineRenderer;

    private Vector2 lastPos;

    private void Update() => Draw();

    private void Draw() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CreateBrush();
        else if (Input.GetKey(KeyCode.Mouse0))
            PointToMousePos();
        else 
            currentLineRenderer = null;
    }

    private void CreateBrush() 
    {
        GameObject brushInstance = Instantiate(brush);
        currentLineRenderer = brushInstance.GetComponent<LineRenderer>();

        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);

        currentLineRenderer.SetPosition(0, mousePos);
        currentLineRenderer.SetPosition(1, mousePos);
    }

    private void AddAPoint(Vector2 pointPos) 
    {
        currentLineRenderer.positionCount++;
        int positionIndex = currentLineRenderer.positionCount - 1;
        currentLineRenderer.SetPosition(positionIndex, pointPos);
    }

    private void PointToMousePos() 
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        if (lastPos != mousePos) 
        {
            AddAPoint(mousePos);
            lastPos = mousePos;
        }
    }

}

