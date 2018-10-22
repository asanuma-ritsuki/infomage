using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignDataDemo3
{
	//The Customer class defines a simple Customer business object.
	class Customer
	{
		//Default constructor is required for usage as sample data
		//in the WPF and Silverlight Designer.
		public Customer() { }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public Guid CustomerID { get; set; }
		public int Age { get; set; }
	}

	//The CustomerCollection class defines a simple collection
	//for Customer business objects.
	class CustomerCollection : List<Customer>
	{
		//Default constructor is required for usage in the WPF Designer.
		public CustomerCollection() { }
	}
}
