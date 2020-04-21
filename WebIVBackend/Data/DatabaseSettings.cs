namespace WebIVBackend.Data
{
         public class DatabaseSettings : IDatabaseSettings
            {
                public string DaysCollectionName { get; set; }
                public string UsersCollectionName { get; set; }
                public string MenusCollectionName { get; set; }
                public string ConnectionString { get; set; }
                public string DatabaseName { get; set; }
            }
            
            public interface IDatabaseSettings
            {
                string DaysCollectionName { get; set; }
                string UsersCollectionName { get; set; }
                string MenusCollectionName { get; set; }
                string ConnectionString { get; set; }
                string DatabaseName { get; set; }
            }
}