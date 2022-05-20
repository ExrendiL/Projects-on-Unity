using UnityEngine;

public class TrackCamera : DefaultTrackableEventHandler
{
    public Rigidbody rb;
    public GameObject playButton, panelPause;
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        rb.useGravity = true;
        panelPause.SetActive(false);
        Time.timeScale = 1;
        if (!InGame.isInGame)
        {
            playButton.SetActive(true);
        }
    }
     
    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        rb.useGravity = false;   
        playButton.SetActive(false);
        if (InGame.isInGame)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
