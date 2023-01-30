using CsvHelper;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\Users\tkarc\OneDrive\デスクトップ\example.csv";
        if (!File.Exists(path))
        {
            Console.WriteLine("example.csvが存在しません");
            return;
        }

        //全てのセルを取得してA1から出力する
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(new CsvParser(reader, CultureInfo.InvariantCulture)))

        {
            var records = csv.GetRecords<ExampleRecord>();
            foreach (var record in records)
            {
                Console.WriteLine($"{record.Name}, {record.Age}");
            }
        }

        //特定のセルにアクセスするにはこのように書く
        using (var reader = new StreamReader(path))
        using (var csv = new CsvReader(new CsvParser(reader, CultureInfo.InvariantCulture)))
        {
            var records = csv.GetRecords<ExampleRecord>().ToList();
            var bbb = records.Where(r => r.Name == "bbb").First();
            //Console.WriteLine(bbb.Age);
            //Console.WriteLine(records.Where(m => m.Name == "bbb").ToList());
        }
    }
}

internal class ExampleRecord
{
    public string Name { get; set; }
    public int Age { get; set; }
}