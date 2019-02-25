using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

    /* A simple UI.
     */
    public class MenuUI : MonoBehaviour{
        
        public void Host(){
            NetworkManager.singleton.StartHost();
        }

        public void Join(){
            NetworkManager.singleton.StartClient();
        }

    }
}
