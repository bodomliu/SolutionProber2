using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace JsonDataShow
{
    public enum JsonDataType
    {
        NULL,
        String,
        Int,
        Double,
        Bool,
    }

    public partial class JsonDataForm : Form
    {
        /// <summary>
        /// Json根节点
        /// </summary>
        public JsonNode? m_fileMainNode { get; set; }

        //public JsonNode? m_showMainNode { get; set; }

        public string m_showMainName { get; set; }

        /// <summary>
        /// Json显示节点
        /// </summary>
        public JsonNode? m_Shownode { get; set; }

        /// <summary>
        /// Json文件路径地址
        /// </summary>
        public string m_jsonFilePath { get; set; } = string.Empty;

        /// <summary>
        /// Json当前显示路径
        /// </summary>
        public string m_jsonShowPath { get; set; } = string.Empty;

        /// <summary>
        /// 当前界面显示节点名
        /// </summary>
        public string m_jsonShowName { get; set; } = string.Empty;

        /// <summary>
        /// 当前界面显示类型
        /// </summary>
        public string m_jsonShowType { get; set; } = string.Empty;

        //TreeNode m_ListTrees;

        public JsonDataForm(string jsonpath, string sub_name = "")
        {
            InitializeComponent();

            init();

            m_showMainName = sub_name;

            string filename = Path.GetFileNameWithoutExtension(jsonpath);
            if (filename != null && filename != string.Empty && filename != "")
            {
                if (sub_name != null && sub_name != string.Empty && sub_name != "")
                {
                    this.Text = filename + " " + sub_name + " 配置";
                }
                else
                {
                    this.Text = filename + " 配置";
                }
            }

            m_jsonFilePath = jsonpath;
            label_JsonFilePath.Text = "文件路径：" + m_jsonFilePath;

            UpdateJsonData(jsonpath, m_showMainName);
        }

        public JsonDataForm(string jsonpath, Object obj_name)
        {
            InitializeComponent();

            init();

            string sub_name = obj_name.GetType().Name;

            m_showMainName = sub_name;

            string filename = Path.GetFileNameWithoutExtension(jsonpath);
            if (filename != null && filename != string.Empty && filename != "")
            {
                if (sub_name != null && sub_name != string.Empty && sub_name != "")
                {
                    this.Text = filename + " " + sub_name + " 配置";
                }
                else
                {
                    this.Text = filename + " 配置";
                }
            }

            m_jsonFilePath = jsonpath;
            label_JsonFilePath.Text = "文件路径：" + m_jsonFilePath;

            UpdateJsonData(jsonpath, m_showMainName);
        }

        //public void UpdateJsonPath(string jsonpath, string sub_name = "")
        //{
        //    if (sub_name == "")
        //    {
        //        m_jsonFilePath = jsonpath;
        //        label_JsonFilePath.Text = "文件路径：" + m_jsonFilePath;

        //        UpdateJsonData(m_jsonFilePath);
        //    }
        //    else
        //    {
                
        //    }
        //}

        public void init()
        {
            dataGridView_JsonShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_JsonShow.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dataGridView_JsonShow.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_JsonShow.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_JsonShow.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_JsonShow.Rows.Clear();
        }

        /// <summary>
        /// 从Json文件更新
        /// </summary>
        /// <param name="jsonpath"></param>
        /// <returns></returns>
        public string UpdateJsonData(string jsonpath, string sub_name = "")
        {
            string ret = "OK";
            do
            {
                try
                {
                    // 读取Json文件所有内容
                    string jsontext = File.ReadAllText(jsonpath);
                    // 判断内容是否为空
                    if (jsontext != null)
                    {
                        textBox_JsonText.Text = jsontext;
                        // 转化内容为JsonNode
                        m_fileMainNode = JsonNode.Parse(jsontext);
                        // 显示表格
                        UpdateGridView(m_fileMainNode, sub_name);
                    }
                    else
                    {
                        m_fileMainNode = null;
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                    break;
                }
            } while (false);
            return ret;
        }

        /// <summary>
        /// 保存Json数据到文件
        /// </summary>
        /// <param name="jsonpath"></param>
        /// <returns></returns>
        public string SaveJsonData(string jsonpath)
        {
            string ret = "OK";
            do
            {
                try
                {
                    if (m_fileMainNode != null)
                    {
                        JsonSerializerOptions options = new()
                        {
                            WriteIndented = true,
                        };
                        string strdata = JsonSerializer.Serialize(m_fileMainNode, options);
                        File.WriteAllText(jsonpath, strdata);
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                    break;
                }
            } while (false);
            return ret;
        }

        /// <summary>
        /// 更新Json文本显示
        /// </summary>
        /// <returns></returns>
        public string UpdateJsonTextShow()
        {
            string ret = "OK";
            do
            {
                try
                {
                    if (m_fileMainNode != null)
                    {
                        JsonSerializerOptions options = new()
                        {
                            WriteIndented = true,
                        };
                        string strdata = JsonSerializer.Serialize(m_fileMainNode, options);
                        textBox_JsonText.Text = strdata;
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                    break;
                }
            } while (false);
            return ret;
        }

        /// <summary>
        /// 更新表格显示
        /// </summary>
        /// <returns></returns>
        public string UpdateGridView(JsonNode? ParentNode, string? subkey)
        {
            string ret = "OK";
            do
            {
                try
                {
                    dataGridView_JsonShow.Rows.Clear();
                    int backindex = dataGridView_JsonShow.Rows.Add();
                    dataGridView_JsonShow.Rows[backindex].Cells[0].Value = "...";       // 回退行显示
                    dataGridView_JsonShow.Rows[backindex].Cells[1].Value = string.Empty;
                    dataGridView_JsonShow.Rows[backindex].Cells[2].Value = string.Empty;
                    dataGridView_JsonShow.Rows[backindex].Cells[3].Value = string.Empty;
                    dataGridView_JsonShow.Rows[backindex].Cells[4].Value = string.Empty;

                    if (ParentNode == null)
                    {
                        ParentNode = m_fileMainNode;
                        subkey = string.Empty;
                    }

                    if (m_fileMainNode != null && ParentNode != null)
                    {
                        m_Shownode = SearchNode(ParentNode, subkey);

                        if (m_Shownode != null)
                        {
                            string showpath = m_Shownode.GetPath();
                            m_jsonShowPath = showpath;

                            textBox_JsonPath.Text = m_jsonShowPath;

                            //JsonNode? outnode;
                            //bool getok = mainobject.TryGetPropertyValue(path, out outnode);
                            //var getvar = mainobject[path];

                            if (m_Shownode.GetType().Name == "JsonObject")
                            {
                                int count = m_Shownode.AsObject().Count;

                                for (int i = 0; i < count; i++)
                                {
                                    var objvalue = m_Shownode.AsObject().ElementAt(i);

                                    int index = dataGridView_JsonShow.Rows.Add();
                                    // 获取Key
                                    string key = objvalue.Key;

                                    // 获取Value
                                    var node = objvalue.Value;

                                    int subcount = 0;

                                    string nodetype = "NULL";

                                    //JsonValue? value = null;
                                    JsonNode? value = null;
                                    JsonDataType valuetype = JsonDataType.NULL;

                                    if (node != null)
                                    {
                                        nodetype = node.GetType().Name;
                                        // 判断类型是否为类
                                        if (node.GetType().Name == "JsonObject")
                                        {
                                            // 读取子项
                                            subcount = node.AsObject().Count;
                                        }
                                        else if (node.GetType().Name == "JsonArray")
                                        {
                                            subcount = node.AsArray().Count();
                                            //value;
                                        }
                                        else // 类型不为类
                                        {
                                            value = node.AsValue();

                                            valuetype = GetJsonDataType(value);

                                            //value = node;
                                        }

                                        //JsonObject

                                        //for (int j = 0; j < subcount; j++)
                                        //{
                                        //    var subobjvalue = node.AsObject().ElementAt(j);
                                        //    string subkey = subobjvalue.Key;
                                        //    var subnode = subobjvalue.Value;

                                        //    Type subtype = subnode.GetType();
                                        //}
                                    }

                                    // 显示

                                    dataGridView_JsonShow.Rows[index].Cells[0].Value = key;
                                    dataGridView_JsonShow.Rows[index].Cells[1].Value = nodetype;
                                    if (subcount == 0)
                                    {
                                        dataGridView_JsonShow.Rows[index].Cells[2].Value = string.Empty;
                                    }
                                    else
                                    {
                                        dataGridView_JsonShow.Rows[index].Cells[2].Value = subcount.ToString();
                                    }
                                    if (value != null)
                                    {
                                        dataGridView_JsonShow.Rows[index].Cells[3].Value = value;
                                        dataGridView_JsonShow.Rows[index].Cells[4].Value = valuetype.ToString();

                                    }
                                }
                            }
                            else if (m_Shownode.GetType().Name == "JsonArray")      // 数组显示
                            {
                                int count = m_Shownode.AsArray().Count;

                                for (int i = 0; i < count; i++)
                                {
                                    JsonNode? subnode = m_Shownode.AsArray()[i];
                                    if (subnode != null)        // 判断是否为空
                                    {
                                        // 判断是类还是项

                                        //var objvalue = subnode.AsObject().First();

                                        int index = dataGridView_JsonShow.Rows.Add();
                                        // 获取Key
                                        string key = i.ToString();

                                        // 获取Value
                                        var node = subnode.AsObject();

                                        int subcount = 0;

                                        string nodetype = "NULL";

                                        //JsonValue? value = null;
                                        JsonNode? value = null;

                                        if (node != null)
                                        {
                                            nodetype = node.GetType().Name;
                                            // 判断类型是否为类
                                            if (node.GetType().Name == "JsonObject")
                                            {
                                                // 读取子项
                                                subcount = node.AsObject().Count;
                                            }
                                            else if (node.GetType().Name == "JsonArray")
                                            {
                                                subcount = node.AsArray().Count();
                                                //value;
                                            }
                                            else // 类型不为类
                                            {
                                                value = node.AsValue();
                                                //value = node;
                                            }
                                        }

                                        // 显示

                                        dataGridView_JsonShow.Rows[index].Cells[0].Value = key;
                                        dataGridView_JsonShow.Rows[index].Cells[1].Value = nodetype;
                                        if (subcount == 0)
                                        {
                                            dataGridView_JsonShow.Rows[index].Cells[2].Value = string.Empty;
                                        }
                                        else
                                        {
                                            dataGridView_JsonShow.Rows[index].Cells[2].Value = subcount.ToString();
                                        }
                                        if (value != null)
                                        {
                                            dataGridView_JsonShow.Rows[index].Cells[3].Value = value;
                                            dataGridView_JsonShow.Rows[index].Cells[4].Value = value;

                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ret = ex.Message;
                    break;
                }
            } while (false);
            return ret;
        }

        /// <summary>
        /// 查找并返回所选节点
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <param name="subkey"></param>
        /// <returns></returns>
        public JsonNode? SearchNode(JsonNode? ParentNode, string? subkey)
        {
            JsonNode? retNode = null;
            if (ParentNode == null)
            {
                ParentNode = m_fileMainNode;
                subkey = string.Empty;
            }
            if (m_fileMainNode != null && ParentNode != null)
            {
                // 获取根节点和路径
                JsonNode mainnode = m_fileMainNode;
                string mainpath = mainnode.GetPath();

                string arraykey = string.Empty;


                // 赋值要显示的节点
                if (subkey != null && subkey != string.Empty && subkey != "")
                {
                    if (ParentNode.GetType().Name == "JsonObject")      // 判断是否有子节点
                    {
                        int parentcount = ParentNode.AsObject().Count;
                        bool findok = false;
                        for (int i = 0; i < parentcount; i++)
                        {
                            if (ParentNode.AsObject().ElementAt(i).Key == subkey)
                            {
                                retNode = ParentNode.AsObject().ElementAt(i).Value;
                                arraykey = subkey;
                                m_jsonShowName = subkey;
                                findok = true;
                            }
                        }
                        if (findok == false)    // 未找到对应子节点内容，显示当前节点
                        {
                            retNode = ParentNode;
                            m_jsonShowName = string.Empty;
                        }
                    }
                    else if (ParentNode.GetType().Name == "JsonArray")      // 数组内类的显示
                    {
                        int num = 0;
                        if (int.TryParse(subkey, out num))
                        {
                            retNode = ParentNode.AsArray().ElementAt(num);
                        }
                        else
                        {
                            retNode = ParentNode;
                        }
                    }
                    else        // 没有子节点，使用父节点
                    {
                        retNode = ParentNode.Parent;
                    }
                }
                else  // 没有子节点内容
                {
                    if (ParentNode.GetType().Name == "JsonObject")      // 判断是否有子节点
                    {
                        // 显示当前节点
                        retNode = ParentNode;
                    }
                    else if (ParentNode.GetType().Name == "JsonArray")
                    {
                        // 显示当前节点
                        retNode = ParentNode;
                    }
                    else        // 没有子节点，使用父节点
                    {
                        if (ParentNode.Parent != null)
                        {
                            retNode = ParentNode.Parent;
                        }
                        else
                        {
                            retNode = ParentNode;
                        }
                    }
                }
            }
            return retNode;
        }

        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public JsonDataType GetJsonDataType(JsonNode node)
        {
            JsonDataType type = JsonDataType.NULL;
            do
            {
                if (node != null)
                {
                    bool tryok = false;
                    if (tryok == false)
                    {
                        tryok = true;
                        try
                        {
                            int? tvalue = ((int?)node);
                            if (tvalue != null)
                            {
                                type = JsonDataType.Int;
                                break;
                            }
                        }
                        catch { tryok = false; }
                    }
                    if (tryok == false)
                    {
                        tryok = true;
                        try
                        {
                            double? tvalue = ((double?)node);
                            if (tvalue != null)
                            {
                                type = JsonDataType.Double;
                                break;
                            }
                        }
                        catch { tryok = false; }
                    }
                    if (tryok == false)
                    {
                        tryok = true;
                        try
                        {
                            bool? tvalue = ((bool?)node);
                            if (tvalue != null)
                            {
                                type = JsonDataType.Bool;
                                break;
                            }
                        }
                        catch { tryok = false; }
                    }
                    if (tryok == false)
                    {
                        tryok = true;
                        try
                        {
                            string? tvalue = node.ToString();
                            if (tvalue != null)
                            {
                                type = JsonDataType.String;
                                break;
                            }
                        }
                        catch { tryok = false; }
                    }
                }
            } while (false);

            return type;
        }

        /// <summary>
        /// 单击表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_JsonShow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;       // 获取行
            int col = e.ColumnIndex;    // 获取列
            if (col == 3)
            {
                // 判断类型
                if (dataGridView_JsonShow.Rows[row].Cells[1].Value.ToString() == "JsonObject" || dataGridView_JsonShow.Rows[row].Cells[1].Value.ToString() == "JsonArray")
                {
                    if (dataGridView_JsonShow.Rows[row].Cells[3].ReadOnly == false)
                    {
                        dataGridView_JsonShow.Rows[row].Cells[3].ReadOnly = true;
                    }
                }
                else
                {
                    if (dataGridView_JsonShow.Rows[row].Cells[3].ReadOnly == true)
                    {
                        dataGridView_JsonShow.Rows[row].Cells[3].ReadOnly = false;
                    }
                }
            }
        }

        /// <summary>
        /// 双击表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_JsonShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;       // 获取行
            int col = e.ColumnIndex;    // 获取列
            if (dataGridView_JsonShow.Rows[row].Cells[0].Value != null && dataGridView_JsonShow.Rows[row].Cells[1].Value != null)
            {
                // 判断类型
                if (dataGridView_JsonShow.Rows[row].Cells[1].Value.ToString() == "JsonObject")
                {
                    if (m_Shownode != null)
                    {
                        UpdateGridView(m_Shownode, dataGridView_JsonShow.Rows[row].Cells[0].Value.ToString());
                    }
                }
                else if (dataGridView_JsonShow.Rows[row].Cells[1].Value.ToString() == "JsonArray")
                {
                    if (m_Shownode != null)
                    {
                        UpdateGridView(m_Shownode, dataGridView_JsonShow.Rows[row].Cells[0].Value.ToString());
                    }
                }
                else if (dataGridView_JsonShow.Rows[row].Cells[0].Value.ToString() == "...")
                {
                    if (m_Shownode != null && m_Shownode.Parent != null)
                    {
                        UpdateGridView(m_Shownode.Parent, string.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// 结束表格输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_JsonShow_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;       // 获取行
            int col = e.ColumnIndex;    // 获取列
            //m_Shownode
            if (m_Shownode != null)
            {
                if (row > 0 && col == 3)
                {
                    JsonNode? selectNode = null;
                    if (m_Shownode.GetType().Name == "JsonObject")      // 当前为类的显示
                    {
                        selectNode = m_Shownode.AsObject().ElementAt(row - 1).Value;
                        if (selectNode != null)
                        {
                            if (selectNode.GetType().Name != "JsonObject" && selectNode.GetType().Name != "JsonArray")
                            {
                                string setstr = m_Shownode.AsObject().ElementAt(row - 1).Key;
                                object value = dataGridView_JsonShow.Rows[row].Cells[col].Value;
                                JsonDataType type = GetJsonDataType(selectNode);
                                switch (type)
                                {
                                    case JsonDataType.NULL:
                                        break;
                                    case JsonDataType.String:
                                        m_Shownode[setstr] = value.ToString();
                                        break;
                                    case JsonDataType.Int:
                                        int intvalue;
                                        double intdvalue;
                                        if (int.TryParse(value.ToString(), out intvalue))
                                        {
                                            m_Shownode[setstr] = intvalue;
                                        }
                                        else if (double.TryParse(value.ToString(), out intdvalue))  // int保存失败再尝试保存为double
                                        {
                                            m_Shownode[setstr] = intdvalue;
                                        }
                                        else        // double保存失败则报错
                                        {
                                            MessageBox.Show("数据类型错误！请改成int类型数据！");
                                        }
                                        break;
                                    case JsonDataType.Double:
                                        double doublevalue;
                                        if (double.TryParse(value.ToString(), out doublevalue))
                                        {
                                            m_Shownode[setstr] = doublevalue;
                                        }
                                        else
                                        {
                                            MessageBox.Show("数据类型错误！请改成Double类型数据！");
                                        }
                                        break;
                                    case JsonDataType.Bool:
                                        bool boolvalue;
                                        if (bool.TryParse(value.ToString(), out boolvalue))
                                        {
                                            m_Shownode[setstr] = boolvalue;
                                        }
                                        else
                                        {
                                            MessageBox.Show("数据类型错误！请改成Bool类型数据！");
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                UpdateJsonTextShow();
                                if (checkBox_autoSave.Checked)
                                {
                                    SaveJsonData(m_jsonFilePath);
                                }
                            }
                        }
                    }
                    else if (m_Shownode.GetType().Name == "JsonArray")      // 当前为数组显示
                    {
                        //selectNode = m_Shownode.AsArray().ElementAt(row - 1);
                    }
                    //if (selectNode != null)
                    //{
                    //    if (selectNode.GetType().Name != "JsonObject" && selectNode.GetType().Name != "JsonArray")
                    //    {
                    //        selectNode = dataGridView_JsonShow.Rows[row].Cells[col].Value.ToString();
                    //    }
                    //}
                }
            }
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            UpdateGridView(m_Shownode, string.Empty);
        }

        /// <summary>
        /// 保存Json到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_saveFile_Click(object sender, EventArgs e)
        {
            SaveJsonData(m_jsonFilePath);
        }

        /// <summary>
        /// 从Json文件重新导入刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateFromFile_Click(object sender, EventArgs e)
        {
            UpdateJsonData(m_jsonFilePath, m_showMainName);
        }
    }
}
