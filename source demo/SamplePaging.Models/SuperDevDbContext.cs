using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace SamplePaging.Models
{
    public partial class SuperDevDbContext : DbContext
    {
        public SuperDevDbContext()
            : base("Default")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<SuperDevDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}

//private static readonly byte[] bytes = Encoding.ASCII.GetBytes("Sovigaz1");
//public static string MD5Encrypt(string password)
//{
//    var md5Hasher = new MD5CryptoServiceProvider();
//    var encoder = new UTF8Encoding();
//    var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));

//    return hashedBytes.Aggregate(String.Empty, (current, b) => current + b.ToString("x2"));
//}

//public static string Encrypt(string originalString)
//{
//    if (String.IsNullOrWhiteSpace(originalString))
//        return String.Empty;

//    var cryptoProvider = new DESCryptoServiceProvider();
//    var memoryStream = new MemoryStream();
//    var cryptoStream = new CryptoStream(memoryStream,
//        cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
//    var writer = new StreamWriter(cryptoStream);
//    writer.Write(originalString);
//    writer.Flush();
//    cryptoStream.FlushFinalBlock();
//    writer.Flush();

//    return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
//}

//public static string Decrypt(string cryptedString)
//{
//    if (String.IsNullOrWhiteSpace(cryptedString))
//        return String.Empty;

//    var cryptoProvider = new DESCryptoServiceProvider();
//    var memoryStream = new MemoryStream
//        (Convert.FromBase64String(cryptedString));
//    var cryptoStream = new CryptoStream(memoryStream,
//        cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
//    var reader = new StreamReader(cryptoStream);

//    return reader.ReadToEnd();
//}