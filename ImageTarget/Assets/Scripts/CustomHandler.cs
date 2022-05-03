using UnityEngine;
using Vuforia;

public class CustomHandler : MonoBehaviour
{

    public GameObject fadeTower;
    public PlaneFinderBehaviour planeFinder;

    public void handleAutomaticTest(HitTestResult result)
    {
        Renderer[] renderers = planeFinder.PlaneIndicator.GetComponentsInChildren<Renderer>(true);
        Canvas[] canvas = planeFinder.PlaneIndicator.GetComponentsInChildren<Canvas>(true);

        foreach (Renderer el in renderers)
            el.enabled = false;

        foreach (Canvas el in canvas)
            el.enabled = false;

        fadeTower.SetActive(true);
        //fadeTower.PositionAt(result.Position);
    }

}
