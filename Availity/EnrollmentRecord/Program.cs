using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class EnrollmentRecord
{
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Version { get; set; }
    public string InsuranceCompany { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input.csv";
        string outputDirectory = "output";

 
        List<EnrollmentRecord> records = ReadCsv(inputFilePath);

        var groupedRecords = records.GroupBy(r => r.InsuranceCompany);

        foreach (var group in groupedRecords)
        {
            var sortedRecords = group.OrderBy(r => r.LastName)
                                     .ThenBy(r => r.FirstName)
                                     .ThenByDescending(r => r.Version);

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string outputFilePath = Path.Combine(outputDirectory, $"{group.Key}.csv");
            WriteCsv(outputFilePath, sortedRecords);
        }

        Console.WriteLine("Enrollment files created successfully.");
    }

    static List<EnrollmentRecord> ReadCsv(string filePath)
    {
        List<EnrollmentRecord> records = new List<EnrollmentRecord>();

        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                var record = new EnrollmentRecord
                {
                    UserId = values[0],
                    FirstName = values[1],
                    LastName = values[2],
                    Version = int.Parse(values[3]),
                    InsuranceCompany = values[4]
                };

                records.Add(record);
            }
        }

        return records;
    }

    static void WriteCsv(string filePath, IEnumerable<EnrollmentRecord> records)
    {
        using (var writer = new StreamWriter(filePath))
        {
            foreach (var record in records)
            {
                writer.WriteLine($"{record.UserId},{record.FirstName},{record.LastName},{record.Version},{record.InsuranceCompany}");
            }
        }
    }
}
