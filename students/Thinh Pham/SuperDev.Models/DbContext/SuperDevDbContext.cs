using SuperDev.Models.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;


namespace SuperDev.Models
{
    public partial class SuperDevDbContext : DbContext
    {
        public SuperDevDbContext()
            : base(nameOrConnectionString: "Data Source=THINHPHSE62039\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;User ID=sa;Password=123")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<SuperDevDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public int SaveChanges(int? id = null)
        {
            return base.SaveChanges();
        }

        public void CloneObject(object des, object src)
        {
            foreach (PropertyInfo propertyInfo in des.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (src.GetType().GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    var value = src.GetType().GetProperty(propertyInfo.Name).GetValue(src, null);
                    propertyInfo.SetValue(des, value, null);
                }
            }
        }
    }
}