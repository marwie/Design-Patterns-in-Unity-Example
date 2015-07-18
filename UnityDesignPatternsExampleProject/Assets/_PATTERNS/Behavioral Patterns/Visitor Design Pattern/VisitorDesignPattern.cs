using UnityEngine;
using System.Collections;

/* video: https://www.youtube.com/watch?v=pL4mOUDi54o&list=PLF206E906175C7E07&index=26
 * 
 * 
 * allows you to add methods to classes of different types without much altering to those classes
 * 
 * allows to make completely different methods depending on the class used
 * 
 * allows you to define external classes that can be extend other classes without majorly editing them
 * 
 * 
 * */

namespace VisitorPattern
{
	public class VisitorDesignPattern : MonoBehaviour
	{
		void OnEnable ()
		{
			Debug.Log ("------------------");
			Debug.Log ("VISITOR DESIGN PATTERN");

			// testing the pattern:

			TaxVisitor taxCalc = new TaxVisitor();
			TaxHolidayVisitor taxHolidayCalc = new TaxHolidayVisitor();

			Necessity milk = new Necessity(3.25);
			Liquor vodka = new Liquor(11.99);
			Tobacco cigars = new Tobacco(19.99);

			double milkPrice = milk.Accept(taxCalc);
			double milkPriceHoliday = milk.Accept(taxHolidayCalc);
			Debug.Log ("Milk costs: " + milkPrice.ToString() + ", Holiday Price: " + milkPriceHoliday.ToString());

			double vodkaPrice = vodka.Accept(taxCalc);
			double vodkaHolidayPrice = vodka.Accept(taxHolidayCalc);
			Debug.Log ("Vodka costs: " + vodkaPrice.ToString() + ", Holiday Price: " + vodkaHolidayPrice.ToString());

			double cigarsPrice = cigars.Accept(taxCalc);
			double cigarsPriceHoliday = cigars.Accept(taxHolidayCalc);
			Debug.Log ("Cigars cost: " + cigarsPrice.ToString() + ", Holiday Price: " + cigarsPriceHoliday.ToString());
		}
	}

	
	// Visitor, Visitable, Accept and Visit are common jargon names for parts of the visitor pattern
	public interface Visitor
	{
		double visit(Liquor item);
		double visit(Tobacco item);
		double visit(Necessity item);
	}

	// concrete implementation
	public class TaxVisitor : Visitor
	{
		#region Visitor implementation
		public double visit (Liquor item)
		{
			Debug.Log ("Liquor item: Price with Tax");
			return item.price * 1.18f;
		}
		public double visit (Tobacco item)
		{
			Debug.Log ("Tobacco item: Price with Tax");
			return item.price * 1.32f;
		}
		public double visit (Necessity item)
		{
			Debug.Log ("Necessity item: Price with Tax");
			return item.price;
		}
		#endregion
	}



	// Interfaces and abstract classes

	// this belongs to the visitor pattern :)
	public interface Visitable
	{
		double Accept(Visitor visitor);
	}

	// this is just for not having to type this for every item
	public abstract class Item
	{
		public double price { get; protected set; }

		public Item(double price)
		{
			this.price = price;
		}
	}


	// some items:

	// concrete implementation
	public class Liquor : Item, Visitable
	{
		public Liquor(double price) : base(price) {}
		
		#region Visitable implementation
		
		public double Accept (Visitor visitor)
		{
			return visitor.visit(this);
		}
		
		#endregion
	}
	
	// concrete implementation
	public class Tobacco : Item, Visitable
	{
		public Tobacco(double price) : base(price) {}
		
		#region Visitable implementation
		
		public double Accept (Visitor visitor)
		{
			return visitor.visit(this);
		}
		
		#endregion
	}
	
	// concrete implementation
	public class Necessity : Item, Visitable
	{
		public Necessity(double price) : base(price) {}
		
		#region Visitable implementation
		
		public double Accept (Visitor visitor)
		{
			return visitor.visit(this);
		}
		
		#endregion
	}




	// if out of the sudden you need some other implementation or tax handling for holidays it is 
	// a matter of copy paste edit to implement that :-)
	// see below:

	public class TaxHolidayVisitor : Visitor
	{
		#region Visitor implementation
		public double visit (Liquor item)
		{
			Debug.Log ("Liquor item: Price with Tax");
			return item.price * 1.10f;
		}
		public double visit (Tobacco item)
		{
			Debug.Log ("Tobacco item: Price with Tax");
			return item.price * 1.20f;
		}
		public double visit (Necessity item)
		{
			Debug.Log ("Necessity item: Price with Tax");
			return item.price;
		}
		#endregion
	}



}