namespace WebIVBackend.Domain.Models
{
    public class AppSettings: IAppSettings
    {
        public string key { get; set; }
    }
    
    public interface IAppSettings
    {
        string key { get; set; }
    }
}