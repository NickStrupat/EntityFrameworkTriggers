﻿using System;

#if EF_CORE
using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkCore.Triggers
#else
using System.Data.Entity;
namespace EntityFramework.Triggers
#endif
{
	public sealed class Triggers<TEntity, TDbContext> : ITriggers<TEntity, TDbContext>
	where TEntity : class
	where TDbContext : DbContext
	{
		internal Triggers()
		{
			inserting    = new TriggerEvent<IInsertingEntry   <TEntity, TDbContext>, TEntity, TDbContext>();
			insertFailed = new TriggerEvent<IInsertFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
			inserted     = new TriggerEvent<IInsertedEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
			deleting     = new TriggerEvent<IDeletingEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
			deleteFailed = new TriggerEvent<IDeleteFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
			deleted      = new TriggerEvent<IDeletedEntry     <TEntity, TDbContext>, TEntity, TDbContext>();
			updating     = new TriggerEvent<IUpdatingEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
			updateFailed = new TriggerEvent<IUpdateFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
			updated      = new TriggerEvent<IUpdatedEntry     <TEntity, TDbContext>, TEntity, TDbContext>();
		}

		private readonly TriggerEvent<IInsertingEntry   <TEntity, TDbContext>, TEntity, TDbContext> inserting   ;
		private readonly TriggerEvent<IInsertFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> insertFailed;
		private readonly TriggerEvent<IInsertedEntry    <TEntity, TDbContext>, TEntity, TDbContext> inserted    ;
		private readonly TriggerEvent<IDeletingEntry    <TEntity, TDbContext>, TEntity, TDbContext> deleting    ;
		private readonly TriggerEvent<IDeleteFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> deleteFailed;
		private readonly TriggerEvent<IDeletedEntry     <TEntity, TDbContext>, TEntity, TDbContext> deleted     ;
		private readonly TriggerEvent<IUpdatingEntry    <TEntity, TDbContext>, TEntity, TDbContext> updating    ;
		private readonly TriggerEvent<IUpdateFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> updateFailed;
		private readonly TriggerEvent<IUpdatedEntry     <TEntity, TDbContext>, TEntity, TDbContext> updated     ;

		TriggerEvent<IInsertingEntry   <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Inserting    => inserting   ;
		TriggerEvent<IInsertFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.InsertFailed => insertFailed;
		TriggerEvent<IInsertedEntry    <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Inserted     => inserted    ;
		TriggerEvent<IDeletingEntry    <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Deleting     => deleting    ;
		TriggerEvent<IDeleteFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.DeleteFailed => deleteFailed;
		TriggerEvent<IDeletedEntry     <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Deleted      => deleted     ;
		TriggerEvent<IUpdatingEntry    <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Updating     => updating    ;
		TriggerEvent<IUpdateFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.UpdateFailed => updateFailed;
		TriggerEvent<IUpdatedEntry     <TEntity, TDbContext>, TEntity, TDbContext> ITriggers<TEntity, TDbContext>.Updated      => updated     ;
		
		private static readonly TriggerEvent<IInsertingEntry   <TEntity, TDbContext>, TEntity, TDbContext> staticInserting    = new TriggerEvent<IInsertingEntry   <TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IInsertFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> staticInsertFailed = new TriggerEvent<IInsertFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IInsertedEntry    <TEntity, TDbContext>, TEntity, TDbContext> staticInserted     = new TriggerEvent<IInsertedEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IDeletingEntry    <TEntity, TDbContext>, TEntity, TDbContext> staticDeleting     = new TriggerEvent<IDeletingEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IDeleteFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> staticDeleteFailed = new TriggerEvent<IDeleteFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IDeletedEntry     <TEntity, TDbContext>, TEntity, TDbContext> staticDeleted      = new TriggerEvent<IDeletedEntry     <TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IUpdatingEntry    <TEntity, TDbContext>, TEntity, TDbContext> staticUpdating     = new TriggerEvent<IUpdatingEntry    <TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IUpdateFailedEntry<TEntity, TDbContext>, TEntity, TDbContext> staticUpdateFailed = new TriggerEvent<IUpdateFailedEntry<TEntity, TDbContext>, TEntity, TDbContext>();
		private static readonly TriggerEvent<IUpdatedEntry     <TEntity, TDbContext>, TEntity, TDbContext> staticUpdated      = new TriggerEvent<IUpdatedEntry     <TEntity, TDbContext>, TEntity, TDbContext>();

        public static event Action<IInsertingEntry   <TEntity, TDbContext>> Inserting    { add => staticInserting   .Add(value); remove => staticInserting   .Remove(value); }
        public static event Action<IInsertFailedEntry<TEntity, TDbContext>> InsertFailed { add => staticInsertFailed.Add(value); remove => staticInsertFailed.Remove(value); }
        public static event Action<IInsertedEntry    <TEntity, TDbContext>> Inserted     { add => staticInserted    .Add(value); remove => staticInserted    .Remove(value); }
        public static event Action<IDeletingEntry    <TEntity, TDbContext>> Deleting     { add => staticDeleting    .Add(value); remove => staticDeleting    .Remove(value); }
        public static event Action<IDeleteFailedEntry<TEntity, TDbContext>> DeleteFailed { add => staticDeleteFailed.Add(value); remove => staticDeleteFailed.Remove(value); }
        public static event Action<IDeletedEntry     <TEntity, TDbContext>> Deleted      { add => staticDeleted     .Add(value); remove => staticDeleted     .Remove(value); }
        public static event Action<IUpdatingEntry    <TEntity, TDbContext>> Updating     { add => staticUpdating    .Add(value); remove => staticUpdating    .Remove(value); }
        public static event Action<IUpdateFailedEntry<TEntity, TDbContext>> UpdateFailed { add => staticUpdateFailed.Add(value); remove => staticUpdateFailed.Remove(value); }
        public static event Action<IUpdatedEntry     <TEntity, TDbContext>> Updated      { add => staticUpdated     .Add(value); remove => staticUpdated     .Remove(value); }
	}

	public sealed class Triggers<TEntity> : ITriggers<TEntity>
	where TEntity : class
	{
		private readonly ITriggers<TEntity, DbContext> triggers;
		internal Triggers() => triggers = new Triggers<TEntity, DbContext>();

		TriggerEvent<IInsertingEntry   <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Inserting    => triggers.Inserting   ;
		TriggerEvent<IInsertFailedEntry<TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.InsertFailed => triggers.InsertFailed;
		TriggerEvent<IInsertedEntry    <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Inserted     => triggers.Inserted    ;
		TriggerEvent<IDeletingEntry    <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Deleting     => triggers.Deleting    ;
		TriggerEvent<IDeleteFailedEntry<TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.DeleteFailed => triggers.DeleteFailed;
		TriggerEvent<IDeletedEntry     <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Deleted      => triggers.Deleted     ;
		TriggerEvent<IUpdatingEntry    <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Updating     => triggers.Updating    ;
		TriggerEvent<IUpdateFailedEntry<TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.UpdateFailed => triggers.UpdateFailed;
		TriggerEvent<IUpdatedEntry     <TEntity, DbContext>, TEntity, DbContext> ITriggers<TEntity, DbContext>.Updated      => triggers.Updated     ;

		public static event Action<IInsertingEntry   <TEntity, DbContext>> Inserting    { add => Triggers<TEntity, DbContext>.Inserting    += value; remove => Triggers<TEntity, DbContext>.Inserting    -= value; }
		public static event Action<IInsertFailedEntry<TEntity, DbContext>> InsertFailed { add => Triggers<TEntity, DbContext>.InsertFailed += value; remove => Triggers<TEntity, DbContext>.InsertFailed -= value; }
		public static event Action<IInsertedEntry    <TEntity, DbContext>> Inserted     { add => Triggers<TEntity, DbContext>.Inserted     += value; remove => Triggers<TEntity, DbContext>.Inserted     -= value; }
		public static event Action<IDeletingEntry    <TEntity, DbContext>> Deleting     { add => Triggers<TEntity, DbContext>.Deleting     += value; remove => Triggers<TEntity, DbContext>.Deleting     -= value; }
		public static event Action<IDeleteFailedEntry<TEntity, DbContext>> DeleteFailed { add => Triggers<TEntity, DbContext>.DeleteFailed += value; remove => Triggers<TEntity, DbContext>.DeleteFailed -= value; }
		public static event Action<IDeletedEntry     <TEntity, DbContext>> Deleted      { add => Triggers<TEntity, DbContext>.Deleted      += value; remove => Triggers<TEntity, DbContext>.Deleted      -= value; }
		public static event Action<IUpdatingEntry    <TEntity, DbContext>> Updating     { add => Triggers<TEntity, DbContext>.Updating     += value; remove => Triggers<TEntity, DbContext>.Updating     -= value; }
		public static event Action<IUpdateFailedEntry<TEntity, DbContext>> UpdateFailed { add => Triggers<TEntity, DbContext>.UpdateFailed += value; remove => Triggers<TEntity, DbContext>.UpdateFailed -= value; }
		public static event Action<IUpdatedEntry     <TEntity, DbContext>> Updated      { add => Triggers<TEntity, DbContext>.Updated      += value; remove => Triggers<TEntity, DbContext>.Updated      -= value; }
	}
}
