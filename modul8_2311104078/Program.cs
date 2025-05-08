using System;

class Program
{
    static void Main()
    {
        BankTransferConfig config = new BankTransferConfig();
        string lang = config.lang;

        string promptAmount = (lang == "en") ? "Please insert the amount of money to transfer:" : "Masukkan jumlah uang yang akan di-transfer:";
        Console.WriteLine(promptAmount);
        int amount = int.Parse(Console.ReadLine());

        int fee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
        int total = amount + fee;

        if (lang == "en")
        {
            Console.WriteLine($"Transfer fee = {fee}");
            Console.WriteLine($"Total amount = {total}");
        }
        else
        {
            Console.WriteLine($"Biaya transfer = {fee}");
            Console.WriteLine($"Total biaya = {total}");
        }

        Console.WriteLine((lang == "en") ? "Select transfer method:" : "Pilih metode transfer:");
        for (int i = 0; i < config.methods.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {config.methods[i]}");
        }
        Console.ReadLine(); // input pilihan metode, tidak digunakan lanjut

        string confirmPrompt = (lang == "en")
            ? $"Please type \"{config.confirmation.en}\" to confirm the transaction:"
            : $"Ketik \"{config.confirmation.id}\" untuk mengkonfirmasi transaksi:";
        Console.WriteLine(confirmPrompt);
        string input = Console.ReadLine();

        bool confirmed = (lang == "en" && input.ToLower() == config.confirmation.en.ToLower()) ||
                         (lang == "id" && input.ToLower() == config.confirmation.id.ToLower());

        if (confirmed)
        {
            Console.WriteLine(lang == "en" ? "The transfer is completed" : "Proses transfer berhasil");
        }
        else
        {
            Console.WriteLine(lang == "en" ? "Transfer is cancelled" : "Transfer dibatalkan");
        }
    }
}
