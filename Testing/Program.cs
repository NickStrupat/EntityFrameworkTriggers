﻿using System;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace Testing
{
	public class Entity
	{
		public Int64 Id { get; private set; }
		public DateTime Inserted { get; set; }
		public DateTime Updated { get; set; }
		public String Name { get; set; }
	}

	public class Foo
	{
		private static Int32 instanceCount;
		public readonly Int32 Count;
		public Foo() => Count = instanceCount++;
	}

	public class Context : DbContextWithTriggers
	{
		public Context(IServiceProvider serviceProvider) : base(serviceProvider) {}
		//public Context(IServiceProvider serviceProvider, DbContextOptions options) : base(serviceProvider, options) {}

		public virtual DbSet<Entity> Entities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
				optionsBuilder.UseInMemoryDatabase("what");
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			var container = new Container();
			container.Register<IServiceProvider>(() => container, Lifestyle.Singleton);
			container.Register<Context>(Lifestyle.Transient);
			container.Register<Foo>(Lifestyle.Transient);
			container.Register(typeof(Triggerz<>), typeof(Triggerz<>), Lifestyle.Singleton);

			container.GetInstance<Triggerz<Entity>>().InsertingAdd<Foo>((entry, foo) => entry.Entity.Inserted = DateTime.UtcNow);
			container.GetInstance<Triggerz<Entity>>().UpdatingAdd<Foo>((entry, foo) => entry.Entity.Updated = DateTime.UtcNow);

			container.GetInstance<Triggerz<Entity>>().InsertingAdd<Foo>((entry, foo) => entry.Entity.Name = foo.Count.ToString());

			using (var context = container.GetInstance<Context>())
			{
				var a = new Entity();
				var b = new Entity();
				context.Add(a);
				context.Add(b);
				context.SaveChanges();
			}
		}
	}

	public static class TriggerzExtensions
	{
		public static IServiceCollection AddDbContextWithTriggers(this IServiceCollection serviceCollection) => null;
	}
}