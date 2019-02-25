using System;
using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

	/* Just an event manager class for decoupling logic
	 */
	public class CustomEvents : MonoBehaviour{

		#region Singleton Implementation
		
		private static CustomEvents _instance;
		public static CustomEvents instance{
			get{ return _instance; }
		}

		private void Awake(){
			if( _instance ) {
				Debug.LogError( "There is already a CustomEvents instance" );
				Destroy( this );
				return;
			}

			_instance = this;
		}
		
		#endregion

		public Action<NetworkInstanceId> Clicked;

	}
	
}
