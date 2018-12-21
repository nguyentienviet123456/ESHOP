using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context: DbContext
    {
        //public Context() : base("DefaultConnection")
        //{
        //    ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
        //}
        public Context() : base("DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach(var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

           base.OnModelCreating(modelBuilder);
        }
    }
}
