namespace ControleMateriaisApi.Configurations
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; } = String.Empty;
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; } = String.Empty;
        public string UsernamePassword { get; set; } = String.Empty;
        public string FromEmail { get; set; } = String.Empty;
        public string ToEmail { get; set; } = String.Empty;
        public string CcEmail { get; set; } = String.Empty;
    }
}
