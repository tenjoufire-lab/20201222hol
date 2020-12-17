using System;
using System.Collections.Generic;
using System.IO;

namespace project
{
    class Program
    {
        private static string filePath = "";
        private static Captions captions;
        private static string videoURL = "";
        static void Main(string[] args)
        {
            captions = new Captions();
            captions.CaptionList = new List<Caption>();
            Console.WriteLine("Enter the .vtt file path");
            filePath = Console.ReadLine();
            Console.WriteLine("Enter the video URL");
            videoURL = Console.ReadLine();
            string line = "";
            bool isContentReading = false;
            bool isReadBreakLine = false;
            bool isReadTimeLine = false;

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string captionstring = "";
                Caption caption = new Caption();
                //string format = "HH:mm:ss.fff";
                while ((line = streamReader.ReadLine()) != null)
                {

                    if (line == "WEBVTT")
                    {
                        //skip
                        //Do Nothing
                    }
                    else if (line.StartsWith("NOTE"))
                    {
                        //skip
                    }
                    else if (line == "" && !isContentReading)
                    {
                        //skip
                        isReadBreakLine = true;
                    }
                    else if (line != "" && isReadBreakLine)
                    {
                        //read ID Line
                        isReadBreakLine = false;
                        isContentReading = true;
                        caption.Id = line;
                    }
                    else if (line != "" && isContentReading && !isReadTimeLine)
                    {
                        //read Time Line
                        isReadBreakLine = false;
                        isReadTimeLine = true;
                        var timeString = line.Split(' ')[0];
                        var inttime = (int)TimeSpan.Parse(timeString).TotalSeconds;
                        caption.StartTime = $"{videoURL}?st={inttime}";
                    }
                    else if (line != "" && isContentReading)
                    {
                        captionstring += line;
                    }
                    else if (line == "" && isContentReading)
                    {
                        isContentReading = false;
                        isReadTimeLine = false;
                        isReadBreakLine = true;
                        //Console.WriteLine(captionstring);
                        caption.CaptionContent = captionstring;
                        captions.CaptionList.Add(caption);
                        captionstring = "";
                        caption = new Caption();
                    }

                }
            }

            using (StreamWriter streamWriter = new StreamWriter($"{filePath}.csv", false))
            {
                foreach (var list in captions.CaptionList)
                {
                    streamWriter.WriteLine($"{list.Id},{list.StartTime},{list.CaptionContent}");
                }
            }

            Console.WriteLine($"{filePath}.csv として保存しました");
            Console.ReadLine();
        }
    }

    class Caption
    {
        public string CaptionContent { get; set; }
        public string StartTime { get; set; }
        public string Id { get; set; }
    }

    class Captions
    {
        public List<Caption> CaptionList { get; set; }

    }
}
