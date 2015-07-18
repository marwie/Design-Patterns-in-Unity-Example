using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// the command pattern is a behavioural design pattern in which an object is used to represent and encapsulate
// all the information needed to call a method for a later time

// this information includes the method name, the object that owns the method and values for the method parameters

// allows store lists of code that is executed at a later time or many times
// client says i want a specific command to run when execute() is called on 1 of these encapsulated (hidden) objects
// ability to undo commands

// an object called the invoker transfers this command to another object called a receiver to execute the right code
// TurnTVOn - DeviceButton - TurnTVOn - Television.TurnTVOn()


/* Benefits:
 * 
 * allows to set aside a list of commands for later use
 * 
 * a class is a great place to store procedures you want to be executed
 * 
 * you can store multiple commands in a class to use over and over
 * 
 * you can implement undo procedures for past commands
 * 
 * negative: you create many small classes that store lists of commands
 * 
 * */

namespace CommandDesign
{
	public class CommandDesignPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log ("------------------");
			Debug.Log ("COMMAND DESIGN PATTERN");
			IElectronicDevice device = TVRemove.GetDevice();

			TurnTVOn onCommand = new TurnTVOn(device);
			DeviceButton onPressed = new DeviceButton(onCommand);
			onPressed.Press();

			// -----------------------
			
			TurnTVOff offCommand = new TurnTVOff(device);
			onPressed = new DeviceButton(offCommand);
			onPressed.Press();
			
			TurnVolumeUp volUpCommand = new TurnVolumeUp(device);
			onPressed = new DeviceButton(volUpCommand);
			onPressed.Press();
			onPressed.Press();
			onPressed.Press();
			
			TurnVolumeDown volDownCommand = new TurnVolumeDown(device);
			onPressed = new DeviceButton(volDownCommand);
			onPressed.Press();

			// -----------------------
			Television tv = new Television();
			Radio radio = new Radio();

			List<IElectronicDevice> allDevices = new List<IElectronicDevice>();
			allDevices.Add(tv);
			allDevices.Add (radio);

			TurnItAllOff turnOffDevices = new TurnItAllOff(allDevices);
			DeviceButton turnThemOff = new DeviceButton(turnOffDevices);
			turnThemOff.Press();

			// -----------------------
			turnThemOff.PressUndo();


			// Homework for better Undo:
			// saving all commands in linked lists
			// on undo go through commands in list for undoing and do the opposite
		}
	}





	// interface for electronic devices (or receivers)
	public interface IElectronicDevice
	{
		void On();
		void Off();
		void VolumeUp();
		void VolumeDown();
	}


	public class Television : IElectronicDevice
	{
		protected int volume = 0;

		public void On()
		{
			Debug.Log ("TV is On");
		}

		public void Off()
		{
			Debug.Log ("TV is Off");
		}

		public void VolumeUp()
		{
			++volume;
			Debug.Log ("TV Turned Volume Up to " + volume);
		}

		public void VolumeDown()
		{
			if(volume > 0)
				--volume;
			Debug.Log ("TV Turned Volume Down to " + volume);
		}
	}


	// commands:
	// command interface:
	public interface ICommand
	{
		void Execute();
		void Undo();
	}

	public class TurnTVOn : ICommand
	{
		IElectronicDevice device;

		public TurnTVOn(IElectronicDevice device)
		{
			this.device = device;
		}

		public void Execute()
		{
			this.device.On ();
		}

		public void Undo()
		{
			this.device.Off();
		}
	}
	
	public class TurnTVOff : ICommand
	{
		IElectronicDevice device;
		
		public TurnTVOff(IElectronicDevice device)
		{
			this.device = device;
		}
		
		public void Execute()
		{
			this.device.Off ();
		}
		
		public void Undo()
		{
			this.device.On();
		}
	}
	
	public class TurnVolumeUp : ICommand
	{
		IElectronicDevice device;
		
		public TurnVolumeUp(IElectronicDevice device)
		{
			this.device = device;
		}
		
		public void Execute()
		{
			this.device.VolumeUp ();
		}
		
		public void Undo()
		{
			this.device.VolumeDown();
		}
	}
	
	public class TurnVolumeDown : ICommand
	{
		IElectronicDevice device;
		
		public TurnVolumeDown(IElectronicDevice device)
		{
			this.device = device;
		}
		
		public void Execute()
		{
			this.device.VolumeDown ();
		}
		
		public void Undo()
		{
			this.device.VolumeUp();
		}
	}


	
	public class DeviceButton
	{
		ICommand cmd;

		public DeviceButton(ICommand cmd)
		{
			this.cmd = cmd;
		}

		public void Press()
		{
			this.cmd.Execute(); // actually the invoker (device button) has no idea what it does
		}

		public void PressUndo()
		{
			this.cmd.Undo();
		}
	}





	public class TVRemove
	{
		public static IElectronicDevice GetDevice()
		{
			return new Television();
		}
	}




	public class Radio : IElectronicDevice
	{
		protected int volume = 0;
		
		public void On()
		{
			Debug.Log ("Radio is On");
		}
		
		public void Off()
		{
			Debug.Log ("Radio is Off");
		}
		
		public void VolumeUp()
		{
			++volume;
			Debug.Log ("Radio Turned Volume Up to " + volume);
		}
		
		public void VolumeDown()
		{
			if(volume > 0)
				--volume;
			Debug.Log ("Radio Turned Volume Down to " + volume);
		}
	}


	public class TurnItAllOff : ICommand
	{
		List<IElectronicDevice> devices;

		public TurnItAllOff(List<IElectronicDevice> devices)
		{
			this.devices = devices;
		}

		public void Execute()
		{	
			foreach(IElectronicDevice device in devices)
			{
				device.Off();
			}
		}
		
		public void Undo()
		{	
			foreach(IElectronicDevice device in devices)
			{
				device.On();
			}
		}
	}

}