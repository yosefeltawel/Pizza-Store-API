﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.5.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace PizzaStore.Read.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'Pizza'.</summary>
	[Serializable]
	[DataContract]
	public partial class PizzaView
	{
		/// <summary>Gets or sets the Id field. Derived from Entity Model Field 'Pizza.Id'</summary>
		[DataMember]
		public System.Int32 Id { get; set; }
		/// <summary>Gets or sets the Ingredients field. Derived from Entity Model Field 'Pizza.Ingredients'</summary>
		[DataMember]
		public System.String Ingredients { get; set; }
		/// <summary>Gets or sets the Name field. Derived from Entity Model Field 'Pizza.Name'</summary>
		[DataMember]
		public System.String Name { get; set; }
		/// <summary>Gets or sets the Price field. Derived from Entity Model Field 'Pizza.Price'</summary>
		[DataMember]
		public System.Decimal Price { get; set; }
	}

}



