using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    [SerializeField] string userID;

    [SerializeField] Text chatText;
    [SerializeField] InputField textMessage;

    [SerializeField] InputField inputName;
    [SerializeField] GameObject panelLogin;

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"{level}, {message}");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state);
    }

    public void OnConnected()
    {
        chatText.text += "\n Добро пожаловать";
        chatClient.Subscribe("globalChat");
    }

    public void OnDisconnected()
    {
        chatClient.Unsubscribe(new string[] { "globalChat" });
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            chatText.text += $"\n[{channelName}] {senders[i]}: {messages[i]}";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        for (int i = 0; i < channels.Length; i++)
        {
            chatText.text += $"\nВы поключены к {channels[i]}."; 
        }
    }

    public void OnUnsubscribed(string[] channels)
    {
        for (int i = 0; i < channels.Length; i++)
        {
            chatText.text += $"\nВы отключены к {channels[i]}.";
        }
    }

    public void OnUserSubscribed(string channel, string user)
    {
        chatText.text += $"\nПользователь {user} подключился к {channel}";
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        chatText.text += $"\nПользователь {user} отключился от {channel}";
    }

    void Start()
    {
        chatClient = new ChatClient(this);
    }
    void Update()
    {
        chatClient.Service();
    }

    public void SendButton() 
    {
        chatClient.PublishMessage("globalChat", textMessage.text);
        textMessage.text = null;
    }

    public void LoginButton()
    {
        panelLogin.SetActive(false);
        userID = inputName.text;
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userID));
    }
}
