using CoolCockSuckedByAuxy;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Loader.Util
{
    internal class Util
    {
        public static void cock()
        {
            
        }

        public static void cleanFirst()
        {
            Process.Start("taskkill / f / im epicgameslauncher.exe > nul");
            Process.Start("taskkill / f / im EpicWebHelper.exe > nul");
            Process.Start("taskkill / f / im FortniteClient - Win64 - Shipping_EAC.exe > nul");
            Process.Start("taskkill / f / im FortniteClient - Win64 - Shipping_BE.exe > nul");
            Process.Start("taskkill / f / im FortniteLauncher.exe > nul");
            Process.Start("taskkill / f / im FortniteClient - Win64 - Shipping.exe > nul");
            Process.Start("taskkill / f / im EpicGamesLauncher.exe > nul");
            Process.Start("taskkill / f / im EasyAntiCheat.exe > nul");
            Process.Start("taskkill / f / im BEService.exe > nul");
            Process.Start("taskkill / f / im BEServices.exe > nul");
            Process.Start("taskkill / f / im BattleEye.exe > nul");

        }
    }
}
