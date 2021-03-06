#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodDiaryBeta.Models.DBObjects
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="FoodDiaryBetaDB")]
	public partial class FoodDiaryBetaModelsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertMeal(Meal instance);
    partial void UpdateMeal(Meal instance);
    partial void DeleteMeal(Meal instance);
    partial void InsertProduct(Product instance);
    partial void UpdateProduct(Product instance);
    partial void DeleteProduct(Product instance);
    #endregion
		
		public FoodDiaryBetaModelsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["FoodDiaryBetaDBConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FoodDiaryBetaModelsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodDiaryBetaModelsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodDiaryBetaModelsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FoodDiaryBetaModelsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Meal> Meals
		{
			get
			{
				return this.GetTable<Meal>();
			}
		}
		
		public System.Data.Linq.Table<Product> Products
		{
			get
			{
				return this.GetTable<Product>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Email;
		
		private System.DateTime _DOB;
		
		private double _Weigth;
		
		private double _Height;
		
		private int _Gender;
		
		private System.Nullable<System.Guid> _Meals;
		
		private EntitySet<Meal> _Meals1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnDOBChanging(System.DateTime value);
    partial void OnDOBChanged();
    partial void OnWeigthChanging(double value);
    partial void OnWeigthChanged();
    partial void OnHeightChanging(double value);
    partial void OnHeightChanged();
    partial void OnGenderChanging(int value);
    partial void OnGenderChanged();
    partial void OnMealsChanging(System.Nullable<System.Guid> value);
    partial void OnMealsChanged();
    #endregion
		
		public User()
		{
			this._Meals1 = new EntitySet<Meal>(new Action<Meal>(this.attach_Meals1), new Action<Meal>(this.detach_Meals1));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DOB", DbType="Date NOT NULL")]
		public System.DateTime DOB
		{
			get
			{
				return this._DOB;
			}
			set
			{
				if ((this._DOB != value))
				{
					this.OnDOBChanging(value);
					this.SendPropertyChanging();
					this._DOB = value;
					this.SendPropertyChanged("DOB");
					this.OnDOBChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Weigth", DbType="Float NOT NULL")]
		public double Weigth
		{
			get
			{
				return this._Weigth;
			}
			set
			{
				if ((this._Weigth != value))
				{
					this.OnWeigthChanging(value);
					this.SendPropertyChanging();
					this._Weigth = value;
					this.SendPropertyChanged("Weigth");
					this.OnWeigthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Height", DbType="Float NOT NULL")]
		public double Height
		{
			get
			{
				return this._Height;
			}
			set
			{
				if ((this._Height != value))
				{
					this.OnHeightChanging(value);
					this.SendPropertyChanging();
					this._Height = value;
					this.SendPropertyChanged("Height");
					this.OnHeightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Int NOT NULL")]
		public int Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Meals", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> Meals
		{
			get
			{
				return this._Meals;
			}
			set
			{
				if ((this._Meals != value))
				{
					this.OnMealsChanging(value);
					this.SendPropertyChanging();
					this._Meals = value;
					this.SendPropertyChanged("Meals");
					this.OnMealsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Meal", Storage="_Meals1", ThisKey="Id", OtherKey="IDUser")]
		public EntitySet<Meal> Meals1
		{
			get
			{
				return this._Meals1;
			}
			set
			{
				this._Meals1.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Meals1(Meal entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Meals1(Meal entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Meal")]
	public partial class Meal : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private System.Guid _IDUser;
		
		private System.DateTime _MealDate;
		
		private int _MealType;
		
		private System.Nullable<System.Guid> _IDProductConsumed;
		
		private int _QTY;
		
		private EntityRef<User> _User;
		
		private EntityRef<Product> _Product;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnIDUserChanging(System.Guid value);
    partial void OnIDUserChanged();
    partial void OnMealDateChanging(System.DateTime value);
    partial void OnMealDateChanged();
    partial void OnMealTypeChanging(int value);
    partial void OnMealTypeChanged();
    partial void OnIDProductConsumedChanging(System.Nullable<System.Guid> value);
    partial void OnIDProductConsumedChanged();
    partial void OnQTYChanging(int value);
    partial void OnQTYChanged();
    #endregion
		
		public Meal()
		{
			this._User = default(EntityRef<User>);
			this._Product = default(EntityRef<Product>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDUser", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IDUser
		{
			get
			{
				return this._IDUser;
			}
			set
			{
				if ((this._IDUser != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDUserChanging(value);
					this.SendPropertyChanging();
					this._IDUser = value;
					this.SendPropertyChanged("IDUser");
					this.OnIDUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MealDate", DbType="DateTime NOT NULL")]
		public System.DateTime MealDate
		{
			get
			{
				return this._MealDate;
			}
			set
			{
				if ((this._MealDate != value))
				{
					this.OnMealDateChanging(value);
					this.SendPropertyChanging();
					this._MealDate = value;
					this.SendPropertyChanged("MealDate");
					this.OnMealDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MealType", DbType="Int NOT NULL")]
		public int MealType
		{
			get
			{
				return this._MealType;
			}
			set
			{
				if ((this._MealType != value))
				{
					this.OnMealTypeChanging(value);
					this.SendPropertyChanging();
					this._MealType = value;
					this.SendPropertyChanged("MealType");
					this.OnMealTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDProductConsumed", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDProductConsumed
		{
			get
			{
				return this._IDProductConsumed;
			}
			set
			{
				if ((this._IDProductConsumed != value))
				{
					if (this._Product.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIDProductConsumedChanging(value);
					this.SendPropertyChanging();
					this._IDProductConsumed = value;
					this.SendPropertyChanged("IDProductConsumed");
					this.OnIDProductConsumedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QTY", DbType="Int NOT NULL")]
		public int QTY
		{
			get
			{
				return this._QTY;
			}
			set
			{
				if ((this._QTY != value))
				{
					this.OnQTYChanging(value);
					this.SendPropertyChanging();
					this._QTY = value;
					this.SendPropertyChanged("QTY");
					this.OnQTYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Meal", Storage="_User", ThisKey="IDUser", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Meals1.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Meals1.Add(this);
						this._IDUser = value.Id;
					}
					else
					{
						this._IDUser = default(System.Guid);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Meal", Storage="_Product", ThisKey="IDProductConsumed", OtherKey="ID", IsForeignKey=true)]
		public Product Product
		{
			get
			{
				return this._Product.Entity;
			}
			set
			{
				Product previousValue = this._Product.Entity;
				if (((previousValue != value) 
							|| (this._Product.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Product.Entity = null;
						previousValue.Meals.Remove(this);
					}
					this._Product.Entity = value;
					if ((value != null))
					{
						value.Meals.Add(this);
						this._IDProductConsumed = value.ID;
					}
					else
					{
						this._IDProductConsumed = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("Product");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
	public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ID;
		
		private string _ProductName;
		
		private int _Calories;
		
		private EntitySet<Meal> _Meals;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Guid value);
    partial void OnIDChanged();
    partial void OnProductNameChanging(string value);
    partial void OnProductNameChanged();
    partial void OnCaloriesChanging(int value);
    partial void OnCaloriesChanged();
    #endregion
		
		public Product()
		{
			this._Meals = new EntitySet<Meal>(new Action<Meal>(this.attach_Meals), new Action<Meal>(this.detach_Meals));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string ProductName
		{
			get
			{
				return this._ProductName;
			}
			set
			{
				if ((this._ProductName != value))
				{
					this.OnProductNameChanging(value);
					this.SendPropertyChanging();
					this._ProductName = value;
					this.SendPropertyChanged("ProductName");
					this.OnProductNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Calories", DbType="Int NOT NULL")]
		public int Calories
		{
			get
			{
				return this._Calories;
			}
			set
			{
				if ((this._Calories != value))
				{
					this.OnCaloriesChanging(value);
					this.SendPropertyChanging();
					this._Calories = value;
					this.SendPropertyChanged("Calories");
					this.OnCaloriesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Product_Meal", Storage="_Meals", ThisKey="ID", OtherKey="IDProductConsumed")]
		public EntitySet<Meal> Meals
		{
			get
			{
				return this._Meals;
			}
			set
			{
				this._Meals.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Meals(Meal entity)
		{
			this.SendPropertyChanging();
			entity.Product = this;
		}
		
		private void detach_Meals(Meal entity)
		{
			this.SendPropertyChanging();
			entity.Product = null;
		}
	}
}
#pragma warning restore 1591
