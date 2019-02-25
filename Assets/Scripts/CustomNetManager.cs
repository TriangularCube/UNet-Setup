using UnityEngine;
using UnityEngine.Networking;

namespace UNET_Test{

	public class CustomNetManager : NetworkManager {

		
		// A custom Network Manager, just so I can assign a random player color on spawn
		public override void OnServerAddPlayer( NetworkConnection conn, short playerControlerId ){

			GameObject player = Instantiate( playerPrefab, Vector3.zero, Quaternion.identity );

			player.GetComponent<Player>().color = Random.ColorHSV();

			NetworkServer.AddPlayerForConnection( conn, player, playerControlerId );

		}
		
	}
	
}
