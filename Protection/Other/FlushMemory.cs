using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlushMemory
{
    internal class Flush
    {
        public static void FlushMem1()
        {
            Process prs = Process.GetCurrentProcess();
            try
            {
                prs.MinWorkingSet = (IntPtr)(300000);
            }

            catch (Exception)
            {
            }
        }

        static void FlushMem2()
        {
            GC.Collect(); // Force garbage collection to release memory.
            GC.WaitForPendingFinalizers(); // Wait for finalizers to finish.
            if (Environment.Is64BitProcess)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1); // Release working set memory for 64-bit processes.
            }
            else
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, 1024 * 1024); // Release working set memory for 32-bit processes.
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        public static void Start()
        {
            Thread startFlushThread1 = new Thread(FlushMem1);
            startFlushThread1.Priority = ThreadPriority.Highest;
            startFlushThread1.Start();

            Thread startFlushThread2 = new Thread(FlushMem2);
            startFlushThread2.Priority = ThreadPriority.AboveNormal;
            startFlushThread2.Start();
        }
    }
}