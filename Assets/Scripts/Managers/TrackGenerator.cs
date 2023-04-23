using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour {
    
   
    [SerializeField] private GameObject trackPrefab; // array of track prefabs
    [SerializeField] private float trackLength = 10f; // length of each track piece
    [SerializeField] private int numPieces = 10; // number of pieces to generate
    private GameObject player;
    private List<GameObject> trackPieces = new List<GameObject>(); // list of generated track pieces
    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        GenerateTrack();
    }
    
    void GenerateTrack() {
        for (int i = 0; i < numPieces; i++) {
            GameObject track = Instantiate(trackPrefab);
            track.transform.position = new Vector3(0f, 0f, 20f + i * trackLength);
            trackPieces.Add(track);
        }
    }
    
    void Update() {
        if (player.transform.position.z > trackPieces[trackPieces.Count - 2].transform.position.z) {
            Destroy(trackPieces[0].gameObject);
            trackPieces.Remove(trackPieces[0]);
            GameObject newPiece = Instantiate(trackPrefab);
            newPiece.transform.position = new Vector3(0f, -20f, trackPieces[trackPieces.Count - 1].transform.position.z + trackLength);
            trackPieces.Add(newPiece);
        }
    }
}
