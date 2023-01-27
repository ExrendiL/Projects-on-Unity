using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    public List<GameObject> tracks;
    private float offset = 12f;
    void Start()
    {
        if (tracks != null && tracks.Count > 0)
        {
            tracks = tracks.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    public void MoveTrack()
    {
        GameObject moveTrack = tracks[0];
        tracks.Remove(moveTrack);
        float newZ = tracks[tracks.Count - 1].transform.position.z + offset;
        moveTrack.transform.position = new Vector3(0, 0, newZ);
        tracks.Add(moveTrack);
    }
}
