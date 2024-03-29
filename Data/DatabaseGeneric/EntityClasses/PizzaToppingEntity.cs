﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.9.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using PizzaStore.Data.HelperClasses;
using PizzaStore.Data.FactoryClasses;
using PizzaStore.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaStore.Data.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>Entity class which represents the entity 'PizzaTopping'.<br/><br/></summary>
	[Serializable]
	public partial class PizzaToppingEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		private OrderPizzaEntity _orderPizza;
		private ToppingEntity _topping;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		private static PizzaToppingEntityStaticMetaData _staticMetaData = new PizzaToppingEntityStaticMetaData();
		private static PizzaToppingRelations _relationsFactory = new PizzaToppingRelations();

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrderPizza</summary>
			public static readonly string OrderPizza = "OrderPizza";
			/// <summary>Member name Topping</summary>
			public static readonly string Topping = "Topping";
		}

		/// <summary>Static meta-data storage for navigator related information</summary>
		protected class PizzaToppingEntityStaticMetaData : EntityStaticMetaDataBase
		{
			public PizzaToppingEntityStaticMetaData()
			{
				SetEntityCoreInfo("PizzaToppingEntity", InheritanceHierarchyType.None, false, (int)PizzaStore.Data.EntityType.PizzaToppingEntity, typeof(PizzaToppingEntity), typeof(PizzaToppingEntityFactory), false);
				AddNavigatorMetaData<PizzaToppingEntity, OrderPizzaEntity>("OrderPizza", "PizzaToppings", (a, b) => a._orderPizza = b, a => a._orderPizza, (a, b) => a.OrderPizza = b, PizzaStore.Data.RelationClasses.StaticPizzaToppingRelations.OrderPizzaEntityUsingOrderPizzaIdStatic, ()=>new PizzaToppingRelations().OrderPizzaEntityUsingOrderPizzaId, null, new int[] { (int)PizzaToppingFieldIndex.OrderPizzaId }, null, true, (int)PizzaStore.Data.EntityType.OrderPizzaEntity);
				AddNavigatorMetaData<PizzaToppingEntity, ToppingEntity>("Topping", "PizzaToppings", (a, b) => a._topping = b, a => a._topping, (a, b) => a.Topping = b, PizzaStore.Data.RelationClasses.StaticPizzaToppingRelations.ToppingEntityUsingToppingIdStatic, ()=>new PizzaToppingRelations().ToppingEntityUsingToppingId, null, new int[] { (int)PizzaToppingFieldIndex.ToppingId }, null, true, (int)PizzaStore.Data.EntityType.ToppingEntity);
			}
		}

		/// <summary>Static ctor</summary>
		static PizzaToppingEntity()
		{
		}

		/// <summary> CTor</summary>
		public PizzaToppingEntity()
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public PizzaToppingEntity(IEntityFields2 fields)
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this PizzaToppingEntity</param>
		public PizzaToppingEntity(IValidator validator)
		{
			InitClassEmpty(validator, null);
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		public PizzaToppingEntity(System.Int32 id) : this(id, null)
		{
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for PizzaTopping which data should be fetched into this PizzaTopping object</param>
		/// <param name="validator">The custom validator object for this PizzaToppingEntity</param>
		public PizzaToppingEntity(System.Int32 id, IValidator validator)
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected PizzaToppingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'OrderPizza' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrderPizza() { return CreateRelationInfoForNavigator("OrderPizza"); }

		/// <summary>Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'Topping' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTopping() { return CreateRelationInfoForNavigator("Topping"); }
		
		/// <inheritdoc/>
		protected override EntityStaticMetaDataBase GetEntityStaticMetaData() {	return _staticMetaData; }

		/// <summary>Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		/// <summary>Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this PizzaToppingEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary>The relations object holding all relations of this entity with other entity classes.</summary>
		public static PizzaToppingRelations Relations { get { return _relationsFactory; } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrderPizza' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrderPizza { get { return _staticMetaData.GetPrefetchPathElement("OrderPizza", CommonEntityBase.CreateEntityCollection<OrderPizzaEntity>()); } }

		/// <summary>Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Topping' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTopping { get { return _staticMetaData.GetPrefetchPathElement("Topping", CommonEntityBase.CreateEntityCollection<ToppingEntity>()); } }

		/// <summary>The Id property of the Entity PizzaTopping<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PizzaTopping"."Id".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)PizzaToppingFieldIndex.Id, true); }
			set { SetValue((int)PizzaToppingFieldIndex.Id, value); }		}

		/// <summary>The OrderPizzaId property of the Entity PizzaTopping<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PizzaTopping"."OrderPizzaId".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 OrderPizzaId
		{
			get { return (System.Int32)GetValue((int)PizzaToppingFieldIndex.OrderPizzaId, true); }
			set	{ SetValue((int)PizzaToppingFieldIndex.OrderPizzaId, value); }
		}

		/// <summary>The ToppingId property of the Entity PizzaTopping<br/><br/></summary>
		/// <remarks>Mapped on  table field: "PizzaTopping"."ToppingId".<br/>Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0.<br/>Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ToppingId
		{
			get { return (System.Int32)GetValue((int)PizzaToppingFieldIndex.ToppingId, true); }
			set	{ SetValue((int)PizzaToppingFieldIndex.ToppingId, value); }
		}

		/// <summary>Gets / sets related entity of type 'OrderPizzaEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual OrderPizzaEntity OrderPizza
		{
			get { return _orderPizza; }
			set { SetSingleRelatedEntityNavigator(value, "OrderPizza"); }
		}

		/// <summary>Gets / sets related entity of type 'ToppingEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual ToppingEntity Topping
		{
			get { return _topping; }
			set { SetSingleRelatedEntityNavigator(value, "Topping"); }
		}

		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END

	}
}

namespace PizzaStore.Data
{
	public enum PizzaToppingFieldIndex
	{
		///<summary>Id. </summary>
		Id,
		///<summary>OrderPizzaId. </summary>
		OrderPizzaId,
		///<summary>ToppingId. </summary>
		ToppingId,
		/// <summary></summary>
		AmountOfFields
	}
}

namespace PizzaStore.Data.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: PizzaTopping. </summary>
	public partial class PizzaToppingRelations: RelationFactory
	{

		/// <summary>Returns a new IEntityRelation object, between PizzaToppingEntity and OrderPizzaEntity over the m:1 relation they have, using the relation between the fields: PizzaTopping.OrderPizzaId - OrderPizza.Id</summary>
		public virtual IEntityRelation OrderPizzaEntityUsingOrderPizzaId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "OrderPizza", false, new[] { OrderPizzaFields.Id, PizzaToppingFields.OrderPizzaId }); }
		}

		/// <summary>Returns a new IEntityRelation object, between PizzaToppingEntity and ToppingEntity over the m:1 relation they have, using the relation between the fields: PizzaTopping.ToppingId - Topping.Id</summary>
		public virtual IEntityRelation ToppingEntityUsingToppingId
		{
			get	{ return ModelInfoProviderSingleton.GetInstance().CreateRelation(RelationType.ManyToOne, "Topping", false, new[] { ToppingFields.Id, PizzaToppingFields.ToppingId }); }
		}

	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPizzaToppingRelations
	{
		internal static readonly IEntityRelation OrderPizzaEntityUsingOrderPizzaIdStatic = new PizzaToppingRelations().OrderPizzaEntityUsingOrderPizzaId;
		internal static readonly IEntityRelation ToppingEntityUsingToppingIdStatic = new PizzaToppingRelations().ToppingEntityUsingToppingId;

		/// <summary>CTor</summary>
		static StaticPizzaToppingRelations() { }
	}
}
