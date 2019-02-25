using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

	// A class for syncing scene objects
	public class SceneObject : NetworkBehaviour{

		private NetworkIdentity identity;
		private new Renderer renderer;

		#region A Sync Event

		public delegate void ChangeColorDelegate( Color color ); 
		
		[SyncEvent]
		public event ChangeColorDelegate EventChangeColor;

		#endregion


		// Grab all necessary components
		private void Awake(){
			identity = GetComponent<NetworkIdentity>();
			renderer = GetComponent<Renderer>();
			
			// This is here because it is required on both Server and client
			EventChangeColor += SetColorSync;
		}

		// Using Mouse Down cause I'm too lazy to go full Raycast
		private void OnMouseDown(){
			if( CustomEvents.instance.Clicked != null ) {
				CustomEvents.instance.Clicked( identity.netId );
			}
		}


		// This is called from the Scene Game Manager
		public void SetColor( Color color ){
			if( EventChangeColor != null ) {
				/* Propagate to all clients. Since this is only called from the Scene Manager, which is a
				 * Server Only NetworkObject, we don't have to check for authority here.
				 * 
				 * If  your Manager is not a Server only object, make sure to check that this only
				 * executes on the Server
				 */
				EventChangeColor( color );
			}
		}

		// The synced event to change the color of this object
		private void SetColorSync( Color color ){
			renderer.material.color = color;
		}
	}
	
}
