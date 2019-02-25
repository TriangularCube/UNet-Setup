using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

	/* This class is meant as a manager for the scene.
	 */
	public class OnlineSceneController : MonoBehaviour{

		private static OnlineSceneController _instance;
		public static OnlineSceneController instance{
			get{ return _instance; }
		}

		private void Awake(){
			if( _instance ) {
				Debug.LogError( "There is already an instance of OnlineSceneController" );
				Destroy( this );
				return;
			}

			_instance = this;
		}

		private readonly Dictionary<Player, SceneObject> selections = new Dictionary<Player, SceneObject>();
		
		// Called from each player's object
		public void SelectObject( Player player, NetworkInstanceId target ){

			var targetObject = NetworkServer.FindLocalObject( target ).GetComponent<SceneObject>();

			if( selections.ContainsValue( targetObject ) ) {
				// Someone has already selected it; Do nothing
				return;
			}

			if( selections.ContainsKey( player ) ) {
				// We've previously selected something else
				
				// Reset the previous thing
				selections[player].SetColor( Color.white );
			}

			// Set new selection for player
			selections[player] = targetObject;
			
			// Set the thing's target to be our player's color
			targetObject.SetColor( player.color );

		}

	}
	
}
