using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

	/* A class representing the Player. Lives on the dummy player object.
	 */
	public class Player : NetworkBehaviour{

		private NetworkIdentity identity;

		public Color color;

		private void Awake(){
			identity = GetComponent<NetworkIdentity>();
		}
		
		// Register ourselves with the custom event manager 
		private void Start(){
			
			// But only if we have authority
			if( identity.isLocalPlayer ) {
				CustomEvents.instance.Clicked += SelectTarget;
			}
			
		}

		// Called from NetManager to set player colors on spawn
		public void SetColor( Color color ){
			this.color = color;
		}


		// Command on the Server to do stuff
		[Command]
		private void CmdSelectObject( NetworkInstanceId id ){
			
			// Ask the Scene's Game Manager to execute action
			OnlineSceneController.instance.SelectObject( this, id );
		}

		// Called on client
		public void SelectTarget( NetworkInstanceId id ){
			
			// Send Command off to Server
			CmdSelectObject( id );
		}
		
	}
	
}
