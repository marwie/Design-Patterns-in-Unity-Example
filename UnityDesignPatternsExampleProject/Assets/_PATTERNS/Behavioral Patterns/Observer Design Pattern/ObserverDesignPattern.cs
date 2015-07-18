using UnityEngine;
using System.Collections;

// when you need many objects that receive an update when another object changes

// benefit: loose coupling, publisher doesn't know anything about the subscribers
// negative: publisher may send updates that don't matter to the subscriber

public class ObserverDesignPattern : MonoBehaviour 
{
	void Start () 
	{
		// mmh events ? 
		Debug.Log ("------------------");
		Debug.Log ("OBSERVER DESIGN PATTERN");
		Debug.Log ("Not implemented yet");
	}
}


