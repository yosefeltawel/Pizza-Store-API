﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro v5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaStore.Data.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	internal static class PersistenceInfoProviderSingleton
	{
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton() {	}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance() { return _providerInstance; }
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass();
			InitOrderEntityMappings();
			InitOrderPizzaEntityMappings();
			InitPizzaEntityMappings();
			InitPizzaToppingEntityMappings();
			InitToppingEntityMappings();
		}

		/// <summary>Inits OrderEntity's mappings</summary>
		private void InitOrderEntityMappings()
		{
			this.AddElementMapping("OrderEntity", @"PizzaStore", @"dbo", "Order", 2, 0);
			this.AddElementFieldMapping("OrderEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("OrderEntity", "Note", "Note", true, "NVarChar", 255, 0, 0, false, "", null, typeof(System.String), 1);
		}

		/// <summary>Inits OrderPizzaEntity's mappings</summary>
		private void InitOrderPizzaEntityMappings()
		{
			this.AddElementMapping("OrderPizzaEntity", @"PizzaStore", @"dbo", "OrderPizza", 3, 0);
			this.AddElementFieldMapping("OrderPizzaEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("OrderPizzaEntity", "OrderId", "OrderId", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("OrderPizzaEntity", "PizzaId", "PizzaId", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits PizzaEntity's mappings</summary>
		private void InitPizzaEntityMappings()
		{
			this.AddElementMapping("PizzaEntity", @"PizzaStore", @"dbo", "Pizza", 4, 0);
			this.AddElementFieldMapping("PizzaEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("PizzaEntity", "Ingredients", "Ingredients", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("PizzaEntity", "Name", "Name", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("PizzaEntity", "Price", "Price", false, "Decimal", 0, 19, 5, false, "", null, typeof(System.Decimal), 3);
		}

		/// <summary>Inits PizzaToppingEntity's mappings</summary>
		private void InitPizzaToppingEntityMappings()
		{
			this.AddElementMapping("PizzaToppingEntity", @"PizzaStore", @"dbo", "PizzaTopping", 3, 0);
			this.AddElementFieldMapping("PizzaToppingEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("PizzaToppingEntity", "OrderPizzaId", "OrderPizzaId", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("PizzaToppingEntity", "ToppingId", "ToppingId", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 2);
		}

		/// <summary>Inits ToppingEntity's mappings</summary>
		private void InitToppingEntityMappings()
		{
			this.AddElementMapping("ToppingEntity", @"PizzaStore", @"dbo", "Topping", 3, 0);
			this.AddElementFieldMapping("ToppingEntity", "Id", "Id", false, "Int", 0, 10, 0, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0);
			this.AddElementFieldMapping("ToppingEntity", "Name", "Name", false, "NVarChar", 250, 0, 0, false, "", null, typeof(System.String), 1);
			this.AddElementFieldMapping("ToppingEntity", "Price", "Price", false, "Decimal", 0, 19, 5, false, "", null, typeof(System.Decimal), 2);
		}

	}
}
