using System.Text.Json;

public class Transfer
{
    public int threshold { get; set; }
    public int low_fee { get; set; }
    public int high_fee { get; set; }
}

public class Confirmation
{
    public string en { get; set; }
    public string id { get; set; }
}

public class BankTransferConfig
{
    public string lang { get; set; }
    public Transfer transfer { get; set; }
    public List<string> methods { get; set; }
    public Confirmation confirmation { get; set; }

    private const string filePath = "bank_transfer_config.json";

    public BankTransferConfig()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var config = JsonSerializer.Deserialize<BankTransferConfig>(json);
            lang = config.lang;
            transfer = config.transfer;
            methods = config.methods;
            confirmation = config.confirmation;
        }
        else
        {
            lang = "en";
            transfer = new Transfer { threshold = 25000000, low_fee = 6500, high_fee = 15000 };
            methods = new List<string> { "RTO (real-time)", "SKN", "RTGS", "BI FAST" };
            confirmation = new Confirmation { en = "yes", id = "ya" };
        }
    }
}
