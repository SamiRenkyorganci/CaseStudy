using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OCRJsonParse
{
    

    #region |Interfaces|
    interface IDataProcessor
    {
        List<string> ProcessAndFormatData(string jsonData, IDataFormatter formatter);
    }

    interface IDataFormatter
    {
        List<string> FormatData(List<ResponseData> response);
    }
    #endregion

    #region |Classes|
    class JsonDataProcessor : IDataProcessor
    {
        public List<string> ProcessAndFormatData(string jsonData, IDataFormatter formatter)
        {
            List<ResponseData> responses = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResponseData>>(jsonData);
            responses.RemoveAt(0); // Gelen datadaki ilk özet kısmı algoritmaya sokmuyouz.
            return formatter.FormatData(responses);
        }
    }

    // Verileri satır formatında düzenlemek için sınıf
    class LineDataFormatter : IDataFormatter
    {

        // Verilen koordinat verilerini satır satır birleştirir
        public List<string> FormatData(List<ResponseData> responses)
        {
            List<List<ResponseData>> groupedWords = GroupNodeByRow(responses);
            List<string> lines = new List<string>();

            foreach (var group in groupedWords)
            {
                string line = "|";

                foreach (var g in group)
                {
                    line += $" {g.Description} ";
                }

                line += "|";
                lines.Add(line);
            }

            return lines;
        }

        // Verilen koordinatlarda  aynı satıra denk gelen şekilde gruplar
        private List<List<ResponseData>> GroupNodeByRow(List<ResponseData> responses)
        {
            List<List<ResponseData>> groups = new List<List<ResponseData>>();

            foreach (var res in responses)
            {
                bool addedToExistingGroup = false;

                foreach (var group in groups)
                {
                    if (group.Any(existingNode => AreOnSameRow(res.BoundingPoly, existingNode.BoundingPoly)))
                    {
                        group.Add(res);
                        addedToExistingGroup = true;
                        break;
                    }
                }

                if (!addedToExistingGroup)
                {
                    groups.Add(new List<ResponseData> { res });
                }
            }

            return groups;
        }

        // İki konumun aynı satırda olup olmadığını kontrol eder
        private bool AreOnSameRow(BoundingPoly poly1, BoundingPoly poly2)
        {
            int averageY1 = poly1.Vertices.Sum(v => v.Y) / poly1.Vertices.Count;
            int averageY2 = poly2.Vertices.Sum(v => v.Y) / poly2.Vertices.Count;

            return Math.Abs(averageY1 - averageY2) < 10; // İhtiyaca göre eşik değeri ayarlanabilir
        }
    }
    #endregion
 
    #region |Models|
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class BoundingPoly
    {
        public List<Vertex> Vertices { get; set; }
    }

    public class ResponseData
    {
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
    }
    #endregion


    #region |Main|
    class Program
    {
        static void Main(string[] args)
        {

            // JSON dosyasındaki verileri okur
            string jsonData = JsonData.responseData;

            // JSON verilerini işlemek için bir veri işleyici oluşturulur
            IDataProcessor dataProcessor = new JsonDataProcessor();

            // Verileri alıp düzenleyen bir düzenleyici oluşturulur
            IDataFormatter dataFormatter = new LineDataFormatter();

            // JSON verilerini işle ve düzenle
            List<string> formettedData = dataProcessor.ProcessAndFormatData(jsonData, dataFormatter);

            // Düenlenmiş verileri yazdır
            foreach (var (line, index) in formettedData.Select((value, i) => (value, i)))    
            {
                Console.WriteLine(index+"-"+line);
            }
        }
    }
    #endregion
}
