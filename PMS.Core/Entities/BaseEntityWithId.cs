using System;

namespace PMS.CoreLayer.Entities
{
	public abstract class BaseEntityWithId :IBaseEntityWithId
	{
		public virtual Guid Id { get; set; }= Guid.NewGuid();
		public virtual string InsertedBy { get; set; } = "Undefined";
		public virtual DateTime InsertDate { get; set; }= DateTime.Now;
		public virtual string? UpdatedBy { get; set; }
		public virtual DateTime? UpdateDate { get; set; }
		public virtual string? DeletedBy { get; set; }
		public virtual DateTime? DeletedDate { get; set; }
		public virtual bool IsActive { get; set; } = true;
	}
}
