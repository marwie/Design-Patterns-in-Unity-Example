using UnityEngine;
using System.Collections;

// when you want a method to return one of several possible classes that share a common superclass
// when you don't know ahead of time which class you might need
// when you want to centralize class selection code
// when you don't want the user to have to know every potential subclass
// to encapsulate object creation

// example in a game: put a random enemy to the screen, the enemy class can be chosen at runtime

namespace FactoryDesign
{
	// move that desicion making into another class:
	public class EnemyShipFactory
	{
		public enum ShipType
		{
			UFO,
			Rocket,
			Endboss }
		;

		public EnemyShip MakeEnemyShip (ShipType shipType)
		{
			if (shipType == ShipType.UFO)
				return new UFOEnemyShip ();
			else if (shipType == ShipType.Rocket)
				return new RocketEnemyShip ();
			else if (shipType == ShipType.Endboss)
				return new BigEnemyShip ();
			else
				return null;
		}
	}

	public class FactoryDesignPattern : MonoBehaviour
	{
		EnemyShipFactory factory;

		void Start ()
		{
			Debug.Log ("------------------");
			Debug.Log ("FACTORY DESIGN PATTERN");
			factory = new EnemyShipFactory ();
		}

		void Update ()
		{
			if (Input.GetKeyDown (KeyCode.U))
			{
				EnemyShip ship = factory.MakeEnemyShip (EnemyShipFactory.ShipType.UFO);
				DoStuffEnemy (ship);
			}
		else if (Input.GetKeyDown (KeyCode.R))
			{
				EnemyShip ship = factory.MakeEnemyShip (EnemyShipFactory.ShipType.Rocket);
				DoStuffEnemy (ship);
			}
		else if (Input.GetKeyDown (KeyCode.B))
			{
				EnemyShip ship = factory.MakeEnemyShip (EnemyShipFactory.ShipType.Endboss);
				DoStuffEnemy (ship);
			}
		}
	
		void DoStuffEnemy (EnemyShip enemyShip)
		{
			enemyShip.displayEnemyShip ();
			enemyShip.followHeroShip ();
			enemyShip.enemyShipShoots ();
		}
	}

	public class BadCodeExample : MonoBehaviour
	{
		void Start ()
		{
			EnemyShip ufo = new UFOEnemyShip ();
			Debug.Log ("What kind of ship do you want? (R / U)");
		}
	
		// yes its dynamic but it is also modifyable
		// you don't want this sort of stuff going on inside of your actual program
		// lots of if and else statements and logic
		void Update ()
		{
			return; // < "deactivating"
		
		
			if (Input.GetKeyDown (KeyCode.U))
			{
				EnemyShip ship = new UFOEnemyShip ();
				DoStuffEnemy (ship);
			}
		else if (Input.GetKeyDown (KeyCode.R))
			{
				EnemyShip ship = new RocketEnemyShip ();
				DoStuffEnemy (ship);
			}
		}
	
		void DoStuffEnemy (EnemyShip enemyShip)
		{
			enemyShip.displayEnemyShip ();
			enemyShip.followHeroShip ();
			enemyShip.enemyShipShoots ();
		}
	}

	public abstract class EnemyShip
	{
		public string name;
		public double damage;

		public void followHeroShip ()
		{
			Debug.Log (name + " is following the hero.");
		}

		public void displayEnemyShip ()
		{
			Debug.Log (name + " is on the screen.");
		}

		public void enemyShipShoots ()
		{
			Debug.Log (name + " attacks and does " + damage + " damage");
		}
	}

	public class UFOEnemyShip : EnemyShip
	{
		public UFOEnemyShip ()
		{
			name = "UFOEnemyShip";
			damage = 20;
		}
	}

	public class RocketEnemyShip : EnemyShip
	{
		public RocketEnemyShip ()
		{
			name = "RocketEnemyShip";
			damage = 10;
		}
	}

	public class BigEnemyShip : UFOEnemyShip
	{
		public BigEnemyShip ()
		{
			name = "BigEnemyShip";
			damage = 40;
		}
	}
}


