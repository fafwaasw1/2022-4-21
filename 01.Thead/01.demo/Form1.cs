using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            
           
            //创建一个线程去执行的方法
            th = new Thread(Test);

            th.Start();

        }

        Thread th1;
        private void button2_Click(object sender, EventArgs e)
        {
            th1 = new Thread(Test1);
            th1.Start();
        }

        Thread th2;
        private void button3_Click(object sender, EventArgs e)
        {
            th2 = new Thread(Test2);
            th2.Start();
        }


        private void Test()
        {
            CPU cp = new CPU();
            for (int i = 0; i < 100000; i++)
            {
                textBox1.Text = cp.ServiceDemo()+"%";
            }

        }

        private void Test1()
        {
            CPU cp = new CPU();
            for (int i = 0; i < 10000; i++)
            {
                textBox2.Text = cp.ServiceDemo1() + "MB";
            }
        }


        private void Test2()
        {
            CPU cp = new CPU();
            for (int i = 0; i < 10000; i++)
            {
                textBox3.Text = "硬盘总容量："+ cp.ServiceDemo2() + "MB,硬盘剩余容量：" + cp.ServiceDemo3() +"MB" ;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //取消跨线程的访问
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭窗体，判断线程是否为null
            if(th!=null )
            {
                //立即结束线程
                th.Abort();
            }
            if(th1!=null)
            {
                th1.Abort();
            }
            if (th2 != null)
            {
                th2.Abort();
            }

        }

      
    }
}
