using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.demo
{
    public class CPU
    {
        /// <summary>
        /// cpu
        /// </summary>
        /// <returns></returns>
        public string ServiceDemo()
        {
            //CPU利用率
            float fCPU = GetCpu();

            return fCPU.ToString();
        }

        /// <summary>
        /// 内存
        /// </summary>
        /// <returns></returns>
        public string ServiceDemo1()
        {
            //获得内存
            ulong physicalMey;
            ulong totalMey;
            ulong rMey;

            double dMermory = GetMemory(out physicalMey, out totalMey, out rMey);

            return dMermory.ToString();
        }


        /// <summary>
        /// 硬盘总容量
        /// </summary>
        /// <returns></returns>
        public string ServiceDemo2()
        {
            //硬盘采集
            long lDisk = GetHardDiskSpace("c");
            

            return lDisk.ToString();

        }

        /// <summary>
        /// 硬盘剩余容量
        /// </summary>
        /// <returns></returns>

        public string ServiceDemo3()
        {
            long rDisk = GetHardDiskFreeSpace("c");
            return rDisk.ToString();
        }




        /// <summary>
        /// 获取CPU
        /// </summary>
        public static float GetCpu()
        {
            PerformanceCounter pcCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            float f = pcCPU.NextValue();
            Thread.Sleep(1000);
            f = pcCPU.NextValue();
            string s1 = f.ToString("0.00");
            return f = float.Parse(s1);
        }


        /// <summary>
        /// 获取内存利用率
        /// </summary>
        /// <param name="physicalMey"></param>
        /// <param name="totalMey"></param>
        /// <param name="rMey"></param>
        public static double GetMemory(out ulong physicalMey, out ulong totalMey, out ulong rMey)
        {
            //内存
            ComputerInfo c1 = new ComputerInfo();

            //可用内存
            physicalMey = c1.AvailablePhysicalMemory;
            //总内存
            totalMey = c1.TotalPhysicalMemory;
            //已用内存
            rMey = totalMey - physicalMey;


            //获得内存占有率
            double a = (double)totalMey;
            double b = (double)rMey;


            string s = (rMey / totalMey).ToString("0.00");

            double t = double.Parse((b / a).ToString("0.000"));
            return t = t * 100;

        }




        /// <summary>
        /// 读取剩余硬盘容量
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        public static long GetHardDiskFreeSpace(string str_HardDiskName)
        {
            long freeSpace = new long();
            str_HardDiskName = (str_HardDiskName + ":\\").ToUpper();
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return freeSpace;
        }



        /// <summary>
        /// 读取硬盘容量
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            str_HardDiskName = str_HardDiskName.ToUpper();
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }



    }
}
