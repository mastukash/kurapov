using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Kurapov.Bll.HttpClients.Abstractions;
using Kurapov.DAL.Entities;

namespace Kurapov.Bll.HttpClients.Implementations
{
    public class TxtDocument : ITxtDocument, IDisposable
    {
        public string FileName { get; set; }
        public string PathToFile { get; set; }

        private readonly StreamReader sr;

        public TxtDocument(string path)
        {
            sr = new StreamReader(path);
            FileName = System.IO.Path.GetFileName(path);
            PathToFile = System.IO.Path.GetPathRoot(path);
        }

        public Document Read()
        {
            var doc = new Document
            {
                Id = Guid.NewGuid(),
                Name = FileName,
                Path = PathToFile,
                CreatedDateTime = DateTime.UtcNow,

                Header = ReadHeader(),
                Body = ReadBody()
            };

            return doc;
        }

        public Document Write()
        {
            throw new NotImplementedException();
        }

        public void Save(Document doc)
        {
            throw new NotImplementedException();
        }

        private Header ReadHeader()
        {
            Header header = new Header
            {
                Id = Guid.NewGuid()
            };

            var line = sr.ReadLine();
            try
            {
                header.Format = line.Substring("Format".Length + 1).Trim();
            }
            catch
            {
                header.Format = "";
            }

            line = sr.ReadLine();
            try { 
                header.SourceOfData = line.Substring("Source of Data".Length + 1).Trim();
            }
            catch
            {
                header.SourceOfData = "";
            }

            line = sr.ReadLine();
            try
            {
                header.StationName = line.Substring("Station Name".Length + 1).Trim();
            }
            catch
            {
                header.StationName = "";
            }

            line = sr.ReadLine();
            try
            {
                header.IAGACODE = line.Substring("IAGA CODE".Length + 1).Trim();
            }
            catch
            {
                header.IAGACODE = "";
            }

            line = sr.ReadLine();
            try
            {
                header.GeodeticLatitude = decimal.Parse(line.Substring("Geodetic Latitude".Length + 1).Trim(), CultureInfo.InvariantCulture);
            }
            catch
            {
                header.GeodeticLatitude = 0;
            }

            line = sr.ReadLine();
            try
            {
                header.GeodeticLongitude = decimal.Parse(line.Substring("Geodetic Longitude".Length + 1).Trim(), CultureInfo.InvariantCulture);
            }
            catch
            {
                header.GeodeticLongitude = 0;
            }

            line = sr.ReadLine();
            try
            {
                header.Elevation = decimal.Parse(line.Substring("Elevation".Length + 1).Trim(), CultureInfo.InvariantCulture);
            }
            catch
            {
                header.Elevation = 0;
            }

            line = sr.ReadLine();
            try
            {
                header.Reported = line.Substring("Reported".Length + 1).Trim();
            }
            catch
            {
                header.Reported = "";
            }

            line = sr.ReadLine();
            try
            {
                header.SensorOrientation = line.Substring("Sensor Orientation".Length + 1).Trim();
            }
            catch
            {
                header.SensorOrientation = "";
            }

            line = sr.ReadLine();
            try
            {
                header.DigitalSampling = line.Substring("Digital Sampling".Length + 1).Trim();
            }
            catch
            {
                header.DigitalSampling = "";
            }

            line = sr.ReadLine();
            try
            {
                header.DataIntervalType = line.Substring("Data Interval Type".Length + 1).Trim();
            }
            catch
            {
                header.DataIntervalType = "";
            }

            line = sr.ReadLine();
            try
            {
                header.DataType = line.Substring("Data Type".Length + 1).Trim();
            }
            catch
            {
                header.DataType = "";
            }
            return header;
        }

        private Body ReadBody()
        {
            Body body = new Body();
            body.Lines = new List<Line>();

            //Read header of table 
            var buf = sr.ReadLine();
            var str = buf.Split(new char[]{' ','\t'}).ToList();
            str = str.Where(item => item != "").ToList();

            var isColumns = new Dictionary<string, bool>()
            {
                {"DATE", str.Contains("DATE")},
                {"TIME", str.Contains("TIME")},
                {"DOY",  str.Contains("DOY") },
                {"BRWD", str.Contains("BRWD")},
                {"BRWH", str.Contains("BRWH")},
                {"BRWZ", str.Contains("BRWZ")},
                {"BRWF", str.Contains("BRWF")}
            };

            while (!sr.EndOfStream)
            {
                var line = new Line
                {
                    Id = Guid.NewGuid()
                };

                buf = sr.ReadLine();
                str = buf.Split(new char[] { ' ', '\t' }).ToList();
                str = str.Where(item => item != "").ToList();

                int i = 0;
                if (isColumns["DATE"])
                    line.DATE = DateTime.Parse(str[i++]);

                if (isColumns["TIME"])
                    line.TIME = TimeSpan.Parse(str[i++]);

                if (isColumns["DOY"])
                    line.DOY = int.Parse(str[i++]);

                if (isColumns["BRWD"])
                    line.BRWD = decimal.Parse(str[i++], CultureInfo.InvariantCulture);

                if (isColumns["BRWH"])
                    line.BRWH = decimal.Parse(str[i++], CultureInfo.InvariantCulture);

                if (isColumns["BRWZ"])
                    line.BRWZ = decimal.Parse(str[i++], CultureInfo.InvariantCulture);

                if (isColumns["BRWF"])
                    line.BRWF = decimal.Parse(str[i++], CultureInfo.InvariantCulture);

                body.Lines.Add(line);
            }

            return body;
        }

        private void WriteBody(Body body)
        {
            throw new NotImplementedException();
        }

        private void WriteHeader(Header header)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
