using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace GoooodProject
{
    class JSON
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
    public JSON(DbSet<Employee> employee)
        {
            string employeeJson = JsonSerializer.Serialize(employee, typeof(DbSet<Employee>), options);
            StreamWriter file = File.CreateText("employee.json");
            file.WriteLine(employeeJson);
            file.Close();
        }
    }
}
