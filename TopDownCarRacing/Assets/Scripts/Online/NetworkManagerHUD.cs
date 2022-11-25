using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerHUD : MonoBehaviour
{
    public GameObject LanMenu;
    public string IP;

    public bool solo;

    // Use this for initialization
    void Start () {

    }

    public void StartHost()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(IP, 7777, "0.0.0.0");
            NetworkManager.Singleton.StartHost();
            LanMenu.SetActive(false);
    }

    public void JoinHost()
    {
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(IP, 7777, "0.0.0.0");
            NetworkManager.Singleton.StartClient();
            LanMenu.SetActive(false);
    }

    public void ReadStringInput(string s)
    {
        IP = s;
        Debug.Log(IP);
    }
    
    
}
