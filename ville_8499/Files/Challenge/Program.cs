using System;
using System.IO;

class OfficeFileSummary
{
    static void Main(string[] args)
    {
        // Setup directory and file paths
        string directoryName = "FileCollection";
        string resultsFileName = "results.txt";

        // Create helper function to check if a file is an Office file
        bool IsOfficeFile(string fileExtension)
        {
            return fileExtension.ToLower() == ".xlsx" || fileExtension.ToLower() == ".docx" || fileExtension.ToLower() == ".pptx";
        }

        // Initialize counters and variables
        int excelCount = 0;
        long excelSize = 0;
        int wordCount = 0;
        long wordSize = 0;
        int powerPointCount = 0;
        long powerPointSize = 0;
        int totalCount = 0;
        long totalSize = 0;

        // Create DirectoryInfo object to access the specified directory
        DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);

        // Enumerate files
        foreach (FileInfo file in directoryInfo.GetFiles())
        {
            string fileExtension = file.Extension.ToLower();
            if (IsOfficeFile(fileExtension))
            {
                totalCount++;
                totalSize += file.Length;

                switch (fileExtension)
                {
                    case ".xlsx":
                        excelCount++;
                        excelSize += file.Length;
                        break;
                    case ".docx":
                        wordCount++;
                        wordSize += file.Length;
                        break;
                    case ".pptx":
                        powerPointCount++;
                        powerPointSize += file.Length;
                        break;
                }
            }
        }

        // Write results to file
        using (StreamWriter writer = new StreamWriter(resultsFileName))
        {
            writer.WriteLine("Office File Summary:");
            writer.WriteLine($"Excel files: {excelCount} ({excelSize} bytes)");
            writer.WriteLine($"Word files: {wordCount} ({wordSize} bytes)");
            writer.WriteLine($"PowerPoint files: {powerPointCount} ({powerPointSize} bytes)");
            writer.WriteLine($"Total Office files: {totalCount} ({totalSize} bytes)");
        }

        Console.WriteLine("Results written to " + resultsFileName);
    }
}


                                    


