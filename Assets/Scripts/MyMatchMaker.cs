using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMatchMaker : MonoBehaviour
{
    public NetworkManager manager;
    public Texture btnTexture, matchTexture;

    [SerializeField] public bool showGUI = true;

    Vector2 btnPosition;

    GUIStyle stopbtnStyle = new GUIStyle();
    GUIContent stopbtnContent = new GUIContent();

    GUIStyle createbtnStyle = new GUIStyle();
    GUIContent btnContent = new GUIContent();

    GUIStyle roomnameStyle = new GUIStyle();
    GUIContent roomnameContent = new GUIContent();

    GUIStyle matchStyle = new GUIStyle();
    GUIContent matchContent = new GUIContent();

    GUIStyle findMatchStyle = new GUIStyle();
    GUIContent findMatchContent = new GUIContent();

    GUIStyle backMatchStyle = new GUIStyle();
    GUIContent backMatchContent = new GUIContent();

    private void Start()
    {
        if (manager == null)
            manager = Persist.net;

        //btnContent.image = btnTexture;
        stopbtnContent.text = "Stop Match";
        stopbtnStyle.normal.textColor = Color.blue;
        stopbtnStyle.normal.background = (Texture2D)btnTexture;
        stopbtnStyle.alignment = TextAnchor.MiddleCenter;
        stopbtnStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);


        //btnContent.image = btnTexture;
        btnContent.text = "Create Match";
        createbtnStyle.normal.textColor = Color.blue;
        createbtnStyle.normal.background = (Texture2D)btnTexture;
        createbtnStyle.alignment = TextAnchor.MiddleCenter;
        createbtnStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);

        //btnContent.image = btnTexture;
        roomnameContent.text = "Room Name:";
        roomnameStyle.normal.textColor = Color.blue;
        roomnameStyle.normal.background = (Texture2D)btnTexture;
        roomnameStyle.alignment = TextAnchor.MiddleCenter;
        roomnameStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);


        //btnContent.image = btnTexture;
        findMatchContent.text = "Find Match";
        findMatchStyle.normal.textColor = Color.blue;
        findMatchStyle.normal.background = (Texture2D)btnTexture;
        findMatchStyle.alignment = TextAnchor.MiddleCenter;
        findMatchStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);

        //btnContent.image = btnTexture;
        matchStyle.normal.textColor = Color.blue;
        matchStyle.normal.background = (Texture2D) matchTexture;
        matchStyle.alignment = TextAnchor.MiddleCenter;
        matchStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);

        //btnContent.image = btnTexture;
        backMatchContent.text = "Back to Match Menu";
        backMatchStyle.normal.textColor = Color.blue;
        backMatchStyle.normal.background = (Texture2D)btnTexture;
        backMatchStyle.alignment = TextAnchor.MiddleCenter;
        backMatchStyle.font = Font.CreateDynamicFontFromOSFont("Arial", 16);
    }
    void Awake()
    {
        //manager = GetComponent<NetworkManager>();
        if (manager == null)
            manager = Persist.net;
        if (manager.matchMaker == null)
            manager.StartMatchMaker();
        btnPosition = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
    }


    void Update()
    {
        if (!showGUI)
            return;

        if (!manager.IsClientConnected() && !NetworkServer.active && manager.matchMaker == null)
        {
            if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    manager.StartServer();
                }
                if (Input.GetKeyDown(KeyCode.H))
                {
                    manager.StartHost();
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                manager.StartClient();
            }
        }
        if (NetworkServer.active && manager.IsClientConnected())
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                manager.StopHost();
            }
        }
    }

    void OnGUI()
    {
        if (!showGUI)
            return;

        int xpos = 10;
        int ypos = 40;

        xpos = (int)btnPosition.x - 100;
        ypos = (int)btnPosition.y - 200;

        const int spacing = 24;

        bool noConnection = (manager.client == null || manager.client.connection == null ||
                             manager.client.connection.connectionId == -1);

        /*
        Debug.Log(manager.IsClientConnected());
        Debug.Log(NetworkServer.active);
        Debug.Log(manager.matchMaker);*/
        if (!manager.IsClientConnected() && !NetworkServer.active && manager.matchMaker == null)
        {
            if (manager == null)
                manager = Persist.net;
            manager.StartMatchMaker();
            Debug.Log(SceneManager.GetSceneByName("Lobby").name);
            if (SceneManager.GetSceneByName("Lobby").name != null)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Lobby"));
            }
            else
            {
                SceneManager.LoadScene("Lobby");
            }
            //Debug.Log("1");
            /*
            if (noConnection)
            {

                if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Host(H)"))
                    {
                        manager.StartHost();
                    }
                    ypos += spacing;
                }

                if (GUI.Button(new Rect(xpos, ypos, 105, 20), "LAN Client(C)"))
                {
                    manager.StartClient();
                }

                manager.networkAddress = GUI.TextField(new Rect(xpos + 100, ypos, 95, 20), manager.networkAddress);
                ypos += spacing;

                if (UnityEngine.Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    // cant be a server in webgl build
                    GUI.Box(new Rect(xpos, ypos, 200, 25), "(  WebGL cannot be server  )");
                    ypos += spacing;
                }
                else
                {
                    if (GUI.Button(new Rect(xpos, ypos, 200, 20), "LAN Server Only(S)"))
                    {
                        manager.StartServer();
                    }
                    ypos += spacing;
                }
            }
            else
            {
                GUI.Label(new Rect(xpos, ypos, 200, 20), "Connecting to " + manager.networkAddress + ":" + manager.networkPort + "..");
                ypos += spacing;


                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Cancel Connection Attempt"))
                {
                    manager.StopClient();
                }
            }*/
        }
        /*
        else
        {
            //Debug.Log("2");
            if (NetworkServer.active)
            {
                string serverMsg = "Server: port=" + manager.networkPort;
                if (manager.useWebSockets)
                {
                    serverMsg += " (Using WebSockets)";
                }
                GUI.Label(new Rect(xpos, ypos, 300, 40), serverMsg);
                ypos += spacing;
            }
            if (manager.IsClientConnected())
            {
                GUI.Label(new Rect(xpos, ypos, 300, 40), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
                ypos += spacing;
            }
        }

        if (manager.IsClientConnected() && !ClientScene.ready)
        {
            if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Client Ready"))
            {
                ClientScene.Ready(manager.client.connection);

                if (ClientScene.localPlayers.Count == 0)
                {
                    ClientScene.AddPlayer(0);
                }
            }
            ypos += spacing;
        }*/

        if (NetworkServer.active || manager.IsClientConnected())
        {

            if (GUI.Button(new Rect(xpos, ypos, 200, 40), stopbtnContent, stopbtnStyle))
            {
                Debug.Log("StopMatch");
                manager.StopHost();
                
                Persist.net.clientCount = 0;
                //manager.StopMatchMaker();
                if (manager.matchMaker == null)
                {
                    manager.StartMatchMaker();
                    if (SceneManager.GetSceneByName("Lobby").name != null)
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Lobby"));
                    }
                    else
                    {
                        SceneManager.LoadScene("Lobby");
                    }
                }
            }
            ypos += 40;
        }

        if (!NetworkServer.active && !manager.IsClientConnected() && noConnection)
        {
            ypos += 10;
            /*
            if (UnityEngine.Application.platform == RuntimePlatform.WebGLPlayer)
            {
                GUI.Box(new Rect(xpos - 5, ypos, 220, 25), "(WebGL cannot use Match Maker)");
                return;
            }*/

            if (manager.matchMaker == null)
            {
                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Enable Match Maker (M)"))
                {
                    manager.StartMatchMaker();
                }
                ypos += spacing;
            }
            else
            {
                if (manager.matchInfo == null)
                {
                    if (manager.matches == null)
                    {

                        //if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Create Internet Match"))
                        if (GUI.Button(new Rect(xpos, ypos, 200, 40), btnContent, createbtnStyle))
                        {
                            Debug.Log("CreateMatch");
                            manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", "", "", 0, 0, manager.OnMatchCreate);

                            Persist.net.clientCount = 0;
                            //SceneManager.LoadScene("Room");
                            if (SceneManager.GetSceneByName("Room").name != null)
                            {
                                SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room"));
                            }
                            else
                            {
                                SceneManager.LoadScene("Room");
                            }
                        }
                        ypos += 40;


                        GUI.Label(new Rect(xpos, ypos, 150, 40), roomnameContent, roomnameStyle);
                        manager.matchName = GUI.TextField(new Rect(xpos + 150, ypos, 100, 40), manager.matchName);
                        ypos += 40;

                        if (GUI.Button(new Rect(xpos, ypos, 200, 40), findMatchContent, findMatchStyle))
                        {
                            Debug.Log("FindMatch");
                            manager.matchMaker.ListMatches(0, 20, "", false, 0, 0, manager.OnMatchList);
                        }
                        ypos += 40;
                    }
                    else
                    {
                        for (int i = 0; i < manager.matches.Count; i++)
                        {
                            var match = manager.matches[i];

                            matchContent.text = "Join Match:" + match.name;

                            if (GUI.Button(new Rect(xpos, ypos, 200, 40), matchContent, matchStyle))
                            {
                                manager.matchName = match.name;
                                manager.matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, manager.OnMatchJoined);

                                if (SceneManager.GetSceneByName("Room").name != null)
                                {
                                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Room"));
                                }
                                else
                                {
                                    SceneManager.LoadScene("Room");
                                }
                                //SceneManager.LoadScene("Room");
                            }
                            ypos += 40;
                        }

                        if (GUI.Button(new Rect(xpos, ypos, 200, 40), backMatchContent, backMatchStyle))
                        {
                            Debug.Log("BackToMenu");
                            manager.matches = null;
                            
                            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Lobby"));
                            //SceneManager.LoadScene("Lobby");
                        }
                        ypos += 40;
                    }
                }
                /*
                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Change MM server"))
                {
                    m_ShowServer = !m_ShowServer;
                }
                if (m_ShowServer)
                {
                    ypos += spacing;
                    if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Local"))
                    {
                        manager.SetMatchHost("localhost", 1337, false);
                        m_ShowServer = false;
                    }
                    ypos += spacing;
                    if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Internet"))
                    {
                        manager.SetMatchHost("mm.unet.unity3d.com", 443, true);
                        m_ShowServer = false;
                    }
                    ypos += spacing;
                    if (GUI.Button(new Rect(xpos, ypos, 100, 20), "Staging"))
                    {
                        manager.SetMatchHost("staging-mm.unet.unity3d.com", 443, true);
                        m_ShowServer = false;
                    }
                }

                ypos += spacing;

                GUI.Label(new Rect(xpos, ypos, 300, 20), "MM Uri: " + manager.matchMaker.baseUri);
                ypos += spacing;


                if (GUI.Button(new Rect(xpos, ypos, 200, 20), "Disable Match Maker"))
                {
                    manager.StopMatchMaker();
                }
                ypos += spacing;*/
            }
        }
    }
}
