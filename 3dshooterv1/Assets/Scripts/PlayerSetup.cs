using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    private string remoteLayer = "RemotePlayer";
    private Camera sceneCamera;
    [SerializeField]
    Behaviour[] componentsToDiasable;

     void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDiasable.Length; i++)
                componentsToDiasable[i].enabled = false;
            gameObject.layer = LayerMask.NameToLayer(remoteLayer);
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
                sceneCamera.gameObject.SetActive(false);
        } 
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        string netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player player = GetComponent<Player>();
        GameManager.RegisterPlayer(netID,player);
    }

    void OnDisable()
    {
        if (sceneCamera != null)
            sceneCamera.gameObject.SetActive(true);

        GameManager.UnRegiterPlayer(transform.name);

    }

}
