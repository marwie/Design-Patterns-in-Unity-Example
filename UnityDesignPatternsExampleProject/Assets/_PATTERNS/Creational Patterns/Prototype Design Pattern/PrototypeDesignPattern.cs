using UnityEngine;
using System.Collections;
using System;// needed for cloneable interface
using System.Runtime.CompilerServices;

// creating objects by cloning other objects
// adding any subclass to a known superclass at runtime
// when there are potential classes that you only want at runtime
// reducing the need of creating subclasses

namespace PrototypePattern
{
	public class PrototypeDesignPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log ("------------------");
			Debug.Log ("PROTOTYPE DESIGN PATTERN");
			CloneFactory factory = new CloneFactory();

			Sheep sally = new Sheep();

			Sheep clonedSheep = (Sheep) factory.GetClone(sally);

			Debug.Log ("Sally: " + sally.ToString());
			Debug.Log ("Clone of Sally: " + clonedSheep.ToString());
			Debug.Log ("Sally Hash: " + sally.GetHashCode() + " - Cloned Sheep Hash: " + clonedSheep.GetHashCode());
		}
	}

	public class CloneFactory
	{
		public IAnimal GetClone (IAnimal animalSample)
		{
			return (IAnimal) animalSample.Clone ();
		}
	}

	public interface IAnimal : ICloneable
	{
		object Clone ();
	}

	public class Sheep : IAnimal
	{
		public Sheep ()
		{
			Debug.Log ("Made Sheep");
		}

		public object Clone ()
		{
			Sheep sheep = null;

			try
			{
				sheep = (Sheep)base.MemberwiseClone ();
			} catch (Exception e)
			{
				Debug.LogError ("Error cloning Sheep");
			}

			return sheep;
		}

		public string ToString ()
		{
			return "Hello I'm a Sheep";
		}
	}
}
