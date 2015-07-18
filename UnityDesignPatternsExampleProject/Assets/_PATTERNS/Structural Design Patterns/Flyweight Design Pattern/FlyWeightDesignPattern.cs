using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Used when Creation of a large number of similar objects is needed
 * e.g. for 100.000 objects
 * 
 * This pattern is to reduce memory usage by sharing objects that are similar in some way rarther than creating new ones
 * 
 * Remember Intrinsic Properties (like sharing a Color) and Extrinsic Properties (like having individual sizes)
 * 
 * */


namespace FlyWeightPattern
{

	public class FlyWeightDesignPattern : MonoBehaviour
	{
		// shared colors:
		Color[] shapeColor = 
		{
			Color.red,
			Color.blue,
			Color.gray,
			Color.black,
			Color.green,
			Color.white
		};

		void Start ()
		{
			
			Debug.Log ("------------------");
			Debug.Log ("PROXY DESIGN PATTERN");
			Debug.Log ("Not implemented yet");
		}
	}


	public class FlyWeightTest
	{

	}

}