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
using System.Collections;

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
            ComboBoxInit();
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
            DialogResult returnResult =  dialog.ShowDialog();
            if (returnResult == DialogResult.OK)
            {
                //MessageBox.Show("文件打开成功","通知");
                return dialog.FileName;
            }
            else if (returnResult == DialogResult.Cancel)
            {
                //MessageBox.Show("返回文件路径失败");
                return " ";
            }
            else
            {
                return null;
            }
            
        }
        string traceFileName;
        private void openTraceFileButton_Click(object sender, EventArgs e)
        {
            traceFileName = OpenFiles();
            if (traceFileName != null)
            {
                if (traceFileName == " ")
                {
                    return;
                }
                else
                {
                    closeTraceFileButton.Enabled = true;
                    sr = new StreamReader(traceFileName);
                }

            }
            dirTextBox.Text = traceFileName;

        }
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
        public bool isJudgeDataStyle(List<string> dataList, bool dataNum)
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
                //true为三个数据 false为两个数据
                if(dataNum == true)
                {
                    if ((Convert.ToInt16(dataList[2]) > 5) || (Convert.ToDouble(dataList[0]) < 0))
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

        /// <summary>
        /// 判断是否加入刺激点的模式选择
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool dataMode(List<string> list)
        {
            switch (list.Count)
            {
                case 2: return false; break;
                case 3: return true; break;
                default: return true;
            }

        }


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
            LogRichTextBox.Clear();

            string content;
            drawTraceStimButton.Enabled = false;
            clearTraceStimButton.Enabled = false;
            try
            {
                //sr = new StreamReader(traceFileName);
                while ((content = sr.ReadLine()) != null)
                {
                    i++;
                    //数据以逗号分隔选取 
                    List<string> list = new List<string>(content.Split(','));
                    //判断数据格式是否正确
                    if (isJudgeDataStyle(list, dataMode(list)) == false)
                    {
                        MessageBox.Show("请打开数据格式正确的文件", "错误");
                        list.Clear();
                        clearTraceStimButton.Enabled = true;
                        drawTraceStimButton.Enabled = true;
                        return;
                    }
                    //进行数据转换
                    tempLon = Convert.ToDouble(list[0]);
                    tempLat = Convert.ToDouble(list[1]);

                    wgs84lonlat.lon = ConvertGPS.gps84_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lng; 
                    wgs84lonlat.lat = ConvertGPS.gps84_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lat;
                    //判断数据格式 带或者不带刺激点
                    if (dataMode(list))
                    {
                        tempStimFlag = Convert.ToInt16(list[2]);
                        wgs84lonlat.stimFlag = tempStimFlag;
                    }
                    else
                    {
                        wgs84lonlat.stimFlag = 0;
                    }
                    //是不是第一次
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
                    else
                    {
                        LogRichTextBox.AppendText(content + "\n");
                        webBrowser1.Document.InvokeScript("drawTraceAndStim", objects);//传参交互
                    }
                    Delay(1);
                    list.Clear();
                }
                objects[0] = wgs84lonlat.lon;
                objects[1] = wgs84lonlat.lat;
                objects[2] = wgs84lonlat.stimFlag;
                objects[3] = false;//
                objects[4] = true;//最后一次读数据将第四位改为true
                webBrowser1.Document.InvokeScript("drawTraceAndStim", objects);
                MessageBox.Show("轨迹绘制完毕", "完成");
                sr.Close();
                drawTraceStimButton.Enabled = true;
                clearTraceStimButton.Enabled = true;
            }
            catch {
                drawTraceStimButton.Enabled = true;
                clearTraceStimButton.Enabled = true;
                sr.Close();
            }

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
                MessageBox.Show("请设置格式正确的坐标\n例:121.093381,38.89841", "错误");
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
                objects[0] = ConvertGPS.gps84_To_Gcj02(new PointLatLng(targetPosLat, targetPosLon)).Lng;
                objects[1] = ConvertGPS.gps84_To_Gcj02(new PointLatLng(targetPosLat, targetPosLon)).Lat;
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
            webBrowser1.Document.InvokeScript("removeMarkers");
            closeTraceFileButton.Enabled = false;
            sr.Close();
            traceFileName = null;
            dirTextBox.Text = " ";
            LogRichTextBox.Text = string.Empty;
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www7.zzu.edu.cn/bsbci/");
        }

        //控件初始化
        public void ComboBoxInit()
        {
            ArrayList transComboBoxList = new ArrayList();
            transComboBoxList.Add(new DictionaryEntry(0, "WGS84转高德"));
            transComboBoxList.Add(new DictionaryEntry(1, "高德转WGS84"));
            transComboBoxList.Add(new DictionaryEntry(2, "WGS84转百度"));
            transComboBoxList.Add(new DictionaryEntry(3, "百度转WGS84"));
            transComboBoxList.Add(new DictionaryEntry(4, "高德转百度"));     
            transComboBoxList.Add(new DictionaryEntry(5, "百度转高德"));
            this.transComboBox.DataSource = transComboBoxList;
            this.transComboBox.DisplayMember = "Value";
            this.transComboBox.ValueMember = "Key";
            this.transComboBox.SelectedIndex = 0;

        }
        #region
        private void label4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Author:  LXK\nDate:  2021.10", "GoodLuck!");
        }
        #endregion
        //开始转换按钮
        private void beginTransButton_Click(object sender, EventArgs e)
        {
            string content;
            content = rawDataTextBox.Text.ToString();
            List<string> list = new List<string>(content.Split(','));
            //判断数据格式是否正确
            if (isJudgeDataStyle(list, dataMode(list)) == false)
            {
                MessageBox.Show("请设置格式正确的坐标\n例:121.093381,38.89841", "错误");
                list.Clear();
                return;
            }

            double tempLon = Convert.ToDouble(list[0]);
            double tempLat = Convert.ToDouble(list[1]);
            #region
            //transComboBoxList.Add(new DictionaryEntry(0, "WGS84转高德"));
            //transComboBoxList.Add(new DictionaryEntry(1, "高德转WGS84"));
            //transComboBoxList.Add(new DictionaryEntry(2, "WGS84转百度"));
            //transComboBoxList.Add(new DictionaryEntry(3, "百度转WGS84"));
            //transComboBoxList.Add(new DictionaryEntry(4, "高德转百度"));     
            //transComboBoxList.Add(new DictionaryEntry(5, "百度转高德"));
            #endregion
            if (transComboBox.SelectedIndex == 0)
            {
                double Lon = ConvertGPS.gps84_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.gps84_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
            else if (transComboBox.SelectedIndex == 1)
            {
                double Lon = ConvertGPS.gcj02_To_Gps84(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.gcj02_To_Gps84(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
            else if (transComboBox.SelectedIndex == 2)
            {
                double Lon = ConvertGPS.Gps84_To_bd09(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.Gps84_To_bd09(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
            else if (transComboBox.SelectedIndex == 3)
            {
                double Lon = ConvertGPS.bd09_To_Gps84(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.bd09_To_Gps84(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
            else if (transComboBox.SelectedIndex == 4)
            {
                double Lon = ConvertGPS.gcj02_To_Bd09(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.gcj02_To_Bd09(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
            else if (transComboBox.SelectedIndex == 5)
            {
                double Lon = ConvertGPS.bd09_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lng;
                double Lat = ConvertGPS.bd09_To_Gcj02(new PointLatLng(tempLat, tempLon)).Lat;
                transedTextBox.Text = string.Empty;
                transedTextBox.Text = Lon.ToString() + "," + Lat.ToString();
            }
        }

        private void clearTransButton_Click(object sender, EventArgs e)
        {
            rawDataTextBox.Text = string.Empty;
            transedTextBox.Text = string.Empty;
        }


    }
}
