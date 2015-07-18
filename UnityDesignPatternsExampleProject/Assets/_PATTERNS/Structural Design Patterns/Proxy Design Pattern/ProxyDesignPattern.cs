using UnityEngine;
using System.Collections;


/*
 * Use when you want to provide limited access to another class
 * 
 * Maybe for security reasons because an object is intensive to create
 * or is accessed from a remote location
 * 
 * */


// using the state pattern here for getting access to the ATMMachine object that we created in the StatePattern Namespace
using StatePattern;

namespace ProxyPattern
{
	public class ProxyDesignPattern : MonoBehaviour
	{

		// Use this for initialization
		void OnEnable ()
		{
			Debug.Log ("------------------");
			Debug.Log ("PROXY DESIGN PATTERN");

			GetATMData realATMMachine = new ATMMachine();
			GetATMData atmProxy = new ATMProxy();
			Debug.Log ("Current State: " + atmProxy.GetCurrentState());
			Debug.Log ("Current Cash in Machine: " + atmProxy.GetCashInMachine());

			//atmProxy.setCashInMachine << not possible because not defined in the interface

		}
	}



	public interface GetATMData
	{
		ATMState GetCurrentState();
		int GetCashInMachine();
	}


	public class ATMProxy : GetATMData
	{
		public ATMState GetCurrentState()
		{
			ATMMachine atm = new ATMMachine();
			return atm.GetCurrentState();
		}

		public int GetCashInMachine()
		{
			ATMMachine atm = new ATMMachine();
			return atm.GetCashInMachine();
		}
	}

}
