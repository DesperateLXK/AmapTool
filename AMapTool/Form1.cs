using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;       //添加类对COM可见-ComVisibleAttribute(true)/ 
using System.IO;
using System.Threading;

namespace AMapTool
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            //解决窗体最小限制
            Size newSize = new Size(1450, 825);
            this.MaximumSize = this.MinimumSize = newSize;
            this.Size = newSize;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string str_url = Application.StartupPath + "\\Amap.html";
            Uri url = new Uri(str_url);
            webBrowser1.Url = url;
            webBrowser1.ObjectForScripting = this;
        }
        
        public static string OpenFiles()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//允许打开多个文件
            dialog.DefaultExt = ".txt";//打开文件时显示的可选文件类型
            dialog.Filter = "轨迹文件(*.txt)|*.txt|所有文件(*.*)|*.*";//打开多个文件
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show("文件打开成功","通知");
                return dialog.FileName;
            }
            else
            {
                //MessageBox.Show("返回文件路径失败");
                return null;
            }
        }
        string traceFileName;
        private void openTraceFileButton_Click(object sender, EventArgs e)
        {
            traceFileName = OpenFiles();
            dirTextBox.Text = traceFileName;
        }
        //public double lon = 121.08820638;
        //public double lat = 38.89516914;
        //public int stimFlag = 1;
        //public bool isFirstStart = true;
        //数据格式
        struct wgs84LonLatStimStart
        {
            public double lon ;
            public double lat ;
            public int stimFlag ;
            public bool isFirstStart;

            public void setLonLatStimStartVal(double on, double at, int stim, bool start)
            {
                  lon = on;
                  lat = at;
                  stimFlag = stim;
                  isFirstStart = start;
            }
        };
        wgs84LonLatStimStart wgs84lonlat;   //经纬度数据格式

        //延时函数
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();//可执行某无聊的操作
            }
        }
        //判断文件格式
        public bool isJudgeDataStyle(List<string> dataList, bool isFile)
        {
            try
            {
                //判断经度
                if ((Convert.ToDouble(dataList[0]) > 180) || (Convert.ToDouble(dataList[1]) < 0))
                {
                    return false;
                }
                //判断纬度
                if ((Convert.ToDouble(dataList[1]) > 90) || (Convert.ToDouble(dataList[0]) < 0))
                {
                    return false;
                }
                if(isFile == true)
                {
                    if ((Convert.ToInt16(dataList[2]) > 4) || (Convert.ToDouble(dataList[0]) < 0))
                    {
                        return false;
                    }
                }

                return true;

            }
            catch
            {
                //MessageBox.Show("请打开数据格式正确的文件", "错误");
                return false;
            }
 
        }
        StreamReader sr;
        private void drawTraceStimButton_Click(object sender, EventArgs e)
        {
            object[] objects = new object[5];
            double tempLon;
            double tempLat;
            int tempStimFlag;
            int i = 0;
            if (traceFileName == null)
            {
                return;
            }
            richTextBox1.Clear();

            string content;
            drawTraceStimButton.Enabled = false;
            clearTraceStimButton.Enabled = false;
            sr = new StreamReader(traceFileName);
            while ((content = sr.ReadLine()) != null)
            {
                i++;
                List<string> list = new List<string>(content.Split(','));
                if (isJudgeDataStyle(list, true) == false)
                {
                    MessageBox.Show("请打开数据格式正确的文件", "错误");
                    list.Clear();
                    clearTraceStimButton.Enabled = true;
                    drawTraceStimButton.Enabled = true;
                    return;
                }

                tempLon = Convert.ToDouble(list[0]);
                tempLat = Convert.ToDouble(list[1]);
                tempStimFlag = Convert.ToInt16(list[2]);
                wgs84lonlat.lon = (GPSChange.WGS84_to_GCJ02(tempLat, tempLon)).lng;
                wgs84lonlat.lat = (GPSChange.WGS84_to_GCJ02(tempLat, tempLon)).lat;
                wgs84lonlat.stimFlag = tempStimFlag;
                if (i == 1)
                {
                    wgs84lonlat.isFirstStart = true;
                }
                else
                {
                    wgs84lonlat.isFirstStart = false;
                }
                objects[0] = wgs84lonlat.lon;
                objects[1] = wgs84lonlat.lat;
                objects[2] = wgs84lonlat.stimFlag;
                objects[3] = wgs84lonlat.isFirstStart;
                objects[4] = false;
                if (isFormClosed == true)
                {
                    return;
                }
                else {
                    richTextBox1.AppendText(content + "\n");
                    webBrowser1.Document.InvokeScript("drawTraceAndStim", objects);
                }
                Delay(1);
                list.Clear();
            }
            objects[0] = wgs84lonlat.lon;
            objects[1] = wgs84lonlat.lat;
            objects[2] = wgs84lonlat.stimFlag;
            objects[3] = false;
            objects[4] = true;
            webBrowser1.Document.InvokeScript("drawTraceAndStim", objects);
            MessageBox.Show("轨迹绘制完毕", "完成");
            drawTraceStimButton.Enabled = true;
            clearTraceStimButton.Enabled = true;
        }

        private void clearTraceStimButton_Click(object sender, EventArgs e)
        {
            //清空地图与线条
            webBrowser1.Document.InvokeScript("removeMarkers");
        }

        private void setTargetPosButton_Click(object sender, EventArgs e)
        {
            object[] objects = new object[2];
            double targetPosLon;
            double targetPosLat;
            List<string> list = new List<string>(targetPosTextBox.Text.Split(','));
            if (isJudgeDataStyle(list, false) == false)
            {
                MessageBox.Show("请设置格式正确的坐标系", "错误");
                list.Clear();
                return;
            }
            targetPosLon = Convert.ToDouble(list[0]);
            targetPosLat = Convert.ToDouble(list[1]);
            if (isAMapRadioButton.Checked == true)
            {
                objects[0] = targetPosLon;
                objects[1] = targetPosLat;
            }
            else
            {
                objects[0] = GPSChange.WGS84_to_GCJ02(targetPosLat, targetPosLon).lng;
                objects[1] = GPSChange.WGS84_to_GCJ02(targetPosLat, targetPosLon).lat;
            }

            webBrowser1.Document.InvokeScript("setTargetPos", objects);
            list.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("removeTargetPos");
        }

        private void isAMapRadioButton_Click(object sender, EventArgs e)
        {
            if (isAMapRadioButton.Checked == false)
            {
                isAMapRadioButton.Checked = true;
                label2.Text = "目标位置(高德坐标系)：";
            }
            else
            {
                label2.Text = "目标位置(WGS84)：";
                isAMapRadioButton.Checked = false;
            }
        }
        bool isFormClosed = false;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            webBrowser1.Document.InvokeScript("destroyMap");
            webBrowser1.Dispose();
            isFormClosed = true;
            this.Dispose();
        }

        private void closeTraceFileButton_Click(object sender, EventArgs e)
        {
            sr.Close();
            traceFileName = null;
            dirTextBox.Text = " ";
        }
//WGS84to高德
//高德toWGS84
//WGS84to百度
//百度toWGS84
        private void isWGS84RadioButton_Click(object sender, EventArgs e)
        {
            if (isWGS84RadioButton.Checked == true)
            {
                isWGS84RadioButton.Checked = false;
            }
            else
            {
                isWGS84RadioButton.Checked = true;
            }
        }
    }
}
