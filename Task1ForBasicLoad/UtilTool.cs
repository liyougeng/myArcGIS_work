using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Task1ForBasicLoad
{
    class UtilTool
    {
        public string lastFilePath = "C:\\Program Files (x86)\\ArcGIS\\DeveloperKit10.0\\Samples\\data\\World\\World.mxd";
        /// <summary>
        /// 通过对话框获取单个文件路径
        /// </summary>
        /// <param name="title">文件对话框标题</param>
        /// <param name="filter">对话框过滤字符串</param>
        /// <returns>正常：文件路径；异常：“”</returns>
        public string getSingleFilePathByDlg(string title, string filter)
        {
            try
            {
                OpenFileDialog dlgOpenSingleFile = new OpenFileDialog();
                dlgOpenSingleFile.Title = title;
                dlgOpenSingleFile.Multiselect = false;
                dlgOpenSingleFile.Filter = filter;
                if (dlgOpenSingleFile.ShowDialog() != DialogResult.OK)
                    return "";
                return lastFilePath=dlgOpenSingleFile.FileName;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Warn!");
            }
            return "";
        }

        /// <summary>
        /// 处理系统错误变量
        /// </summary>
        /// <param name="err">系统错误类型号</param>
        /// <returns>返回与错误号相关的字符串</returns>
        public string handleSystemError(SystemErrorType err)
        {
            switch (err)
            {
                case SystemErrorType.enumOK:
                    return "操作完成";
                case SystemErrorType.enumArcObjectHandleError:
                    return "ArcGIS控件操作失败";
                case SystemErrorType.enumArcOjectLoadFail:
                    return "ArcGIS控件加载失败";
                case SystemErrorType.enumDataIsIllegal:
                    return "处理的数据不合法或不服和要求";
                case SystemErrorType.enumFileNotExist:
                    return "文件不存在或不能被读写等操作";
                case SystemErrorType.enumFilePathIsNull:
                    return "文件路径不能为空";
                case SystemErrorType.enumTypeNotExist:
                    return "选取的类型不存在";
                case SystemErrorType.enumUnknowError:
                    return "遇到未知的异常";
                default:
                    return "系统错误类型不存在";
            }
        }
    
        //other functions 
    }
}
