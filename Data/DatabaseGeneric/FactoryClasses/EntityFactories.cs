﻿//////////////////////////////////////////////////////////////
// <auto-generated>This code was generated by LLBLGen Pro 5.5.</auto-generated>
//////////////////////////////////////////////////////////////
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using PizzaStore.Data.EntityClasses;
using PizzaStore.Data.HelperClasses;
using PizzaStore.Data.RelationClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaStore.Data.FactoryClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2<TEntity> : EntityFactoryCore2
		where TEntity : EntityBase2, IEntity2
	{
		private readonly PizzaStore.Data.EntityType _typeOfEntity;
		private readonly bool _isInHierarchy;

		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <param name="isInHierarchy">If true, the entity of this factory is in an inheritance hierarchy, false otherwise</param>
		public EntityFactoryBase2(string entityName, PizzaStore.Data.EntityType typeOfEntity, bool isInHierarchy) : base(entityName)
		{
			_typeOfEntity = typeOfEntity;
			_isInHierarchy = isInHierarchy;
		}
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateFields() { return ModelInfoProviderSingleton.GetInstance().GetEntityFields(this.ForEntityName); }
		
		/// <inheritdoc/>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue) {	return GeneralEntityFactory.Create((PizzaStore.Data.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) { return ModelInfoProviderSingleton.GetInstance().GetHierarchyRelations(this.ForEntityName, objectAlias); }

		/// <inheritdoc/>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			return (IEntityFactory2)ModelInfoProviderSingleton.GetInstance().GetEntityFactory(this.ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
		
		/// <inheritdoc/>
		public override IPredicateExpression GetEntityTypeFilter(bool negate, string objectAlias) {	return ModelInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, objectAlias, negate);	}
						
		/// <inheritdoc/>
		public override IEntityCollection2 CreateEntityCollection()	{ return new EntityCollection<TEntity>(this); }
		
		/// <inheritdoc/>
		public override IEntityFields2 CreateHierarchyFields() 
		{
			return _isInHierarchy ? new EntityFields2(ModelInfoProviderSingleton.GetInstance().GetHierarchyFields(this.ForEntityName), ModelInfoProviderSingleton.GetInstance(), null) : base.CreateHierarchyFields();
		}
		
		/// <inheritdoc/>
		protected override Type ForEntityType { get { return typeof(TEntity); } }
	}

	/// <summary>Factory to create new, empty OrderEntity objects.</summary>
	[Serializable]
	public partial class OrderEntityFactory : EntityFactoryBase2<OrderEntity> 
	{
		/// <summary>CTor</summary>
		public OrderEntityFactory() : base("OrderEntity", PizzaStore.Data.EntityType.OrderEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new OrderEntity(fields); }
	}

	/// <summary>Factory to create new, empty OrderPizzaEntity objects.</summary>
	[Serializable]
	public partial class OrderPizzaEntityFactory : EntityFactoryBase2<OrderPizzaEntity> 
	{
		/// <summary>CTor</summary>
		public OrderPizzaEntityFactory() : base("OrderPizzaEntity", PizzaStore.Data.EntityType.OrderPizzaEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new OrderPizzaEntity(fields); }
	}

	/// <summary>Factory to create new, empty PizzaEntity objects.</summary>
	[Serializable]
	public partial class PizzaEntityFactory : EntityFactoryBase2<PizzaEntity> 
	{
		/// <summary>CTor</summary>
		public PizzaEntityFactory() : base("PizzaEntity", PizzaStore.Data.EntityType.PizzaEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PizzaEntity(fields); }
	}

	/// <summary>Factory to create new, empty PizzaToppingEntity objects.</summary>
	[Serializable]
	public partial class PizzaToppingEntityFactory : EntityFactoryBase2<PizzaToppingEntity> 
	{
		/// <summary>CTor</summary>
		public PizzaToppingEntityFactory() : base("PizzaToppingEntity", PizzaStore.Data.EntityType.PizzaToppingEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new PizzaToppingEntity(fields); }
	}

	/// <summary>Factory to create new, empty ToppingEntity objects.</summary>
	[Serializable]
	public partial class ToppingEntityFactory : EntityFactoryBase2<ToppingEntity> 
	{
		/// <summary>CTor</summary>
		public ToppingEntityFactory() : base("ToppingEntity", PizzaStore.Data.EntityType.ToppingEntity, false) { }
		/// <inheritdoc/>
		protected override IEntity2 CreateImpl(IEntityFields2 fields) { return new ToppingEntity(fields); }
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(PizzaStore.Data.EntityType entityTypeToCreate)
		{
			var factoryToUse = EntityFactoryFactory.GetFactory(entityTypeToCreate);
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
		
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			foreach(int entityTypeValue in Enum.GetValues(typeof(PizzaStore.Data.EntityType)))
			{
				var factory = GetFactory((PizzaStore.Data.EntityType)entityTypeValue);
				_factoryPerType.Add(factory.ForEntityType ?? factory.Create().GetType(), factory);
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity) { return _factoryPerType.GetValue(typeOfEntity); }

		/// <summary>Gets the factory of the entity with the PizzaStore.Data.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(PizzaStore.Data.EntityType typeOfEntity)
		{
			switch(typeOfEntity)
			{
				case PizzaStore.Data.EntityType.OrderEntity:
					return new OrderEntityFactory();
				case PizzaStore.Data.EntityType.OrderPizzaEntity:
					return new OrderPizzaEntityFactory();
				case PizzaStore.Data.EntityType.PizzaEntity:
					return new PizzaEntityFactory();
				case PizzaStore.Data.EntityType.PizzaToppingEntity:
					return new PizzaToppingEntityFactory();
				case PizzaStore.Data.EntityType.ToppingEntity:
					return new ToppingEntityFactory();
				default:
					return null;
			}
		}
	}
		
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator2
	{
		/// <summary>Gets the factory of the Entity type with the PizzaStore.Data.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(int entityTypeValue) { return (IEntityFactory2)this.GetFactoryImpl(entityTypeValue); }
		
		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory2 GetFactory(Type typeOfEntity) { return (IEntityFactory2)this.GetFactoryImpl(typeOfEntity); }

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields2 CreateResultsetFields(int numberOfFields) { return new ResultsetFields(numberOfFields); }
		
		/// <inheritdoc/>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance() { return ModelInfoProviderSingleton.GetInstance(); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand) { return new DynamicRelation(leftOperand); }

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, string aliasLeftOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, aliasLeftOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (PizzaStore.Data.EntityType)Enum.Parse(typeof(PizzaStore.Data.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((PizzaStore.Data.EntityType)Enum.Parse(typeof(PizzaStore.Data.EntityType), leftOperandEntityName, false), joinType, (PizzaStore.Data.EntityType)Enum.Parse(typeof(PizzaStore.Data.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		public override IDynamicRelation CreateDynamicRelation(IEntityFieldCore leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (PizzaStore.Data.EntityType)Enum.Parse(typeof(PizzaStore.Data.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
		
		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue) { return EntityFactoryFactory.GetFactory((PizzaStore.Data.EntityType)entityTypeValue); }

		/// <inheritdoc/>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity) { return EntityFactoryFactory.GetFactory(typeOfEntity);	}

	}
}
