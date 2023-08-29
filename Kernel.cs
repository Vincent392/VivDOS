using System;
using System.IO;
using System.Threading;
using Sys = Cosmos.System;

namespace VivDOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        string current_directory = "0:\\";
        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            //Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
            if (!File.Exists("0:\\VivDOS\\Sys.VDS"))
            {
                Setup1();
            }
            else if (!File.Exists("0:\\Users\\Users.VDDB"))
            {
                oobe();
            }
            Console.Clear();
            Console.WriteLine("VivDOS v1.0.0"); //FF9 and Portal are not the same!
        }

        protected override void Run()
        {
            //Console.Write("Input: ");
            Console.Write("> ");
            var input = Console.ReadLine();
            //Console.Write("Text typed: ");
            //Console.WriteLine(input);

            if (input == "About")
            {
                try
                {
                    Console.WriteLine(File.ReadAllText(@"0:\VivDOS\SysVer.VDS"));
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.ToString());
                    Console.WriteLine("Error");
                    Console.WriteLine("Or in other terms: " + e.ToString());
                }
            }
            else if (input == "Shutdown")
            {
                Console.Clear();
                Console.WriteLine("Logging Off...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Closing Connections...");
                Thread.Sleep(4000);
                Console.Clear();
                Console.WriteLine("VivDOS is shutting down...");
                Thread.Sleep(3000);
                Console.Clear();
                Cosmos.System.Power.Shutdown();
            }
            else if (input == "Dir")
            {
                var files_list = Directory.GetFiles(@"0:\");
                var directory_list = Directory.GetDirectories(@"0:\");

                foreach (var file in files_list)
                {
                    Console.WriteLine(file);
                }
                foreach (var directory in directory_list)
                {
                    Console.WriteLine(directory);
                }

                //} else if (input == "Notes")
                //{
                //VivPad();
            }
            else if (input == "Credits")
            {
                Console.WriteLine("Vincent - Lead Dev, Creator");
            }
            else if (input == "Reboot")
            {
                Console.Clear();
                Console.WriteLine("Logging Off...");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Closing Connections...");
                Thread.Sleep(4000);
                Console.Clear();
                Console.WriteLine("VivDOS is rebooting...");
                Thread.Sleep(3000);
                Console.Clear();
                Cosmos.System.Power.Reboot();
            }
            else if (input == "Echo")
            {
                SysPrintThing();
            }
            else if (input == "Help")
            {
                //Console.WriteLine("Currently there are 55 commands");
            }
            else
            {
                Console.WriteLine("ERR VI1: COMMAND NOT FOUND");
            }
        }

        protected void VivPad()
        {
            Console.Clear();
            if (!File.Exists("0:\\VivDOS\\VivPad\\VivPad.VDA"))
            {
                Console.WriteLine("Error. App not installed");
                Thread.Sleep(5000);
                BeforeRun();
            }
            else if (!File.Exists("0:\\VivDOS\\VivPad\\UsedBefore.VDS"))
            {
                Console.WriteLine("Welcome To VivPad!");
                Console.WriteLine("VivPad is the built in text editor! it saves in .txt and .vpt (VivPad text) files!");
                Console.WriteLine("to save press SHIFT and ` from there you can choose for the file format and name the file");
                Console.WriteLine("Now who's ready to use a text editor?");
                Thread.Sleep(5000);
                Console.Write("> ");
                var input = Console.ReadLine();
                VivPadMain();
            }
            else { VivPadMain(); }
        }

        protected void VivPadMain()
        {
            Console.Clear();
            Console.Write("");
            var input = Console.ReadLine();
            if (input == "¬")
            {
                Console.WriteLine("");
            }
        }

        protected void SysPrintThing()
        {
            Console.Write("Text:");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
        }
        protected void Setup1()
        {
            Console.Clear();
            Console.WriteLine("VivDOS Setup");
            Console.WriteLine("Thanks for choosing VivDOS!");
            Console.WriteLine("To repair a install that can't boot press R");
            Console.WriteLine("To Install VivDOS press S");
            Console.WriteLine("To quit setup press Q");
            Console.WriteLine("=============================================================================================");
            var input = Console.ReadLine();
            if (input == "R") { fixsys(); } else if (input == "S") { setupsys(); } else if (input == "Q") { Cosmos.System.Power.Shutdown(); } else { Setup1(); }
        }

        protected void setupsys()
        {
            Console.Clear();
            Console.WriteLine("VivDOS Setup");
            Console.WriteLine("");
            Console.WriteLine("Format Disk 0 to FAT32?");
            Console.WriteLine("it's recommended");
            Console.WriteLine("");
            Console.WriteLine("=============================================================================================");
            var input = Console.ReadLine();
            if (input == "Y") { sysform(); } else if (input == "N") { setupsys1(); } else { setupsys(); }
        }

        protected void sysform()
        {
            Console.Clear();
            Console.WriteLine("VivDOS Setup");
            Console.WriteLine("");
            Console.WriteLine("Formatting Disk 0 to FAT32...");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("=============================================================================================");
            //insert format code here, someone help plz
            setupsys1();
        }
        protected void setupsys1()
        {
            Console.Clear();
            Console.WriteLine("VivDOS Setup");
            Console.WriteLine("");
            Console.WriteLine("Setup is now installing VivDOS");
            Console.WriteLine("Just sit back and relax");
            Console.WriteLine("");
            Console.WriteLine("=============================================================================================");
            fs.CreateDirectory("0:\\VivDOS\\");
            fs.CreateDirectory("0:\\VivDOS\\SRC");
            fs.CreateFile("0:\\VivDOS\\System.VVDB");
            fs.CreateFile("0:\\VivDOS\\Sys.VDS");
            fs.CreateFile("0:\\VivDOS\\Help.vpt");
            fs.CreateFile("0:\\VivDOS\\SysFiles.VDDB");
            fs.CreateFile("0:\\VivDOS\\SRC\\GPL-V3.txt");
            fs.CreateFile("0:\\VivDOS\\SysVer.VDS");
            fs.CreateFile("0:\\VivDOS\\SRC\\Kernel.cs");
            File.WriteAllText("0:\\VivDOS\\SRC\\GPL-V3.txt", "[GPL-V3 HERE]");
            File.WriteAllText("0:\\VivDOS\\SysVer.VDS", "VivDOS 1.0.0 Codename \"Dublin\"\r\nViv-Kernel-1.0.0-290823\r\nhttps://github.com/Vincent392/VivDOS");
            File.WriteAllText("0:\\VivDOS\\Help.vpt", "Currently there are 8 commands\r\nAbout - shows system info\r\nShutdown - powers off the system\r\nDir - list directory\r\nCredits - Credits\r\nReboot - Restarts the system\r\nEcho - echos text\r\nHelp - displays help (this)\r\nSetup - boots back into setup\r\nKeep in mind: all commands start with a Capital letter"); //make sure to add to this list and change number when commands are added + what they do.
            File.Delete("0:\\Kudzu.txt");
            File.Delete("0:\\Root.txt");
            Directory.Delete("0;\\TEST\\");
            Directory.Delete("0:\\Dir Testing");
            reboottooobe();
        }

        protected void reboottooobe()
        {
            Console.Clear();
            Console.WriteLine("VivDOS Setup");
            Console.WriteLine("");
            Console.WriteLine("VivDOS is installed!");
            Console.WriteLine("Press any key to reboot");
            Console.WriteLine("");
            Console.WriteLine("=============================================================================================");
            Cosmos.System.Power.Reboot();
        }

        protected void oobe()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                         VivDOS");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Welcome to VivDOS!");
            Console.WriteLine("Congatulations on installing VivDOS!");
            Console.WriteLine("The system will guide you though setup! no internet connection required!");
            Console.WriteLine("===========================================================(N) Next [->]");
            var inputobbe = Console.ReadLine();
            if (inputobbe == "N")
            {
                Console.Clear();
                Console.WriteLine("Welcome to VivDOS!");
                Console.WriteLine("What do you want to call your user?");
                var inputoobeuser = Console.ReadLine();
                Console.Write(inputoobeuser);
                var username = inputoobeuser;
                Console.WriteLine("===========================================================(N) Next [->]");
                if (inputobbe == "N")
                {
                    fs.CreateDirectory("0:\\Users");
                    fs.CreateDirectory("0:\\Users\\" + username);
                    fs.CreateDirectory("0:\\Users\\" + username + "Documents");
                    fs.CreateFile("0:\\Users\\Users.VDDB");
                    File.WriteAllText("0:\\Users\\Users.VDDB", "0: " + username);
                    Console.Clear();
                    Console.WriteLine("Welcome to VivDOS!");
                    Console.WriteLine("Password?");
                    var inputoobepass = Console.ReadLine();
                    Console.Write(inputoobepass);
                    var password = inputoobepass;
                    Console.WriteLine("===========================================================(N) Next [->]");
                    if (inputobbe == "N")
                    {
                        Console.Clear();
                        fs.CreateFile("0:\\Users\\" + username + "\\Password.VDDB");
                        File.WriteAllText("0:\\Users\\" + username + "\\Password.VDDB", password);
                        Console.WriteLine("Welcome to VivDOS!");
                        Console.WriteLine("You have finished setup!");
                        Console.WriteLine("Enjoy using VivDOS!");
                        Console.WriteLine("===========================================================(N) Next [->]");
                        var inputA = Console.ReadLine();
                        Cosmos.System.Power.Reboot();
                    }
                }
            }
        }

        protected void fixsys()
        {
            Console.WriteLine("fixing system...");
            fs.CreateDirectory("0:\\VivDOS\\");
            fs.CreateDirectory("0:\\VivDOS\\SRC");
            fs.CreateFile("0:\\VivDOS\\System.VDDB");
            fs.CreateFile("0:\\VivDOS\\Sys.VDS");
            fs.CreateFile("0:\\VivDOS\\SysFiles.VDDB");
            fs.CreateFile("0:\\VivDOS\\Help.vpt");
            fs.CreateFile("0:\\VivDOS\\SRC\\GPL-V3.txt");
            fs.CreateFile("0:\\VivDOS\\SysVer.VDS");
            fs.CreateFile("0:\\VivDOS\\SRC\\Kernel.cs");
            File.WriteAllText("0:\\VivDOS\\SRC\\GPL-V3.txt", "[GPL-V3 HERE]");
            File.WriteAllText("0:\\VivDOS\\SysVer.VDS", "VivDOS 1.0.0 Codename \"Dublin\"\r\nViv-Kernel-1.0.0-290823\r\nhttps://github.com/Vincent392/VivDOS");
            File.WriteAllText("0:\\VivDOS\\Help.vpt", "Currently there are 8 commands\r\nAbout - shows system info\r\nShutdown - powers off the system\r\nDir - list directory\r\nCredits - Credits\r\nReboot - Restarts the system\r\nEcho - echos text\r\nHelp - displays help (this)\r\nSetup - boots back into setup\r\nKeep in mind: all commands start with a Capital letter"); //make sure to add to this list and change number when commands are added + what they do.
            File.WriteAllText("0:\\VivDOS\\SysFiles.VDDB", "");
            Console.WriteLine("Press any key to reboot");
            var input = Console.ReadLine();
            Cosmos.System.Power.Reboot();
        }
    }
}