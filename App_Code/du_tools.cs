using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// JScript ��ժҪ˵��
/// </summary>
public class du_tools
{
    public const string gcs_sytem = "shift";
    public du_tools()
    {
        //
        // TODO: �ڴ˴���ӹ��캯���߼�
        //
    }
    /// ����JavaScriptС����
    /// </summary>
    /// <param name="js">������Ϣ</param>
    public static void f_ok_2_url(string message, string url)
    {
        string js = "<script language=javascript>alert('"+message+"');window.location.replace('"+url+"')</script>";
        HttpContext.Current.Response.Write(js);
    }


    /// <summary>
    /// ����ҳ�е�����Ϣ����Ի���,���رյ�ǰ��ҳ
    /// </summary>
    /// <param name="page">Ҫע��javascript�ű���web�������</param>
    /// <param name="message">������Ϣ����</param>
    public static void CloseWindow(Page page, string message)
    {
        string js = string.Format("alert('{0}');window.close();", message);
        page.ClientScript.RegisterStartupScript(page.GetType(), "error", js, true);
    }


    /// <summary>
    /// ����JavaScriptС����,��������һ��
    /// </summary>
    /// <param name="message">������Ϣ</param>
    public static void AlertAndGoBack(string message)
    {
        string js = @"<Script language='JavaScript'>
                    alert('" + message + "');history.go(-1);</Script>";
        HttpContext.Current.Response.Write(js);
    }

    public static void AlertForSave(string message)
    {
        string RamCode = DateTime.Now.ToString("yyyyMMddHHmmssff");
        string Url = HttpContext.Current.Request.Url.ToString();
        if (Url.IndexOf('?') > 0)
            Url = string.Format("{0}&RamCode={1}", Url, RamCode);
        else
            Url = string.Format("{0}?RamCode={1}", Url, RamCode);

        string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
        HttpContext.Current.Response.Write(string.Format(js, message, Url));
    }

    /// <summary>
    /// �ص���ʷҳ��
    /// </summary>
    /// <param name="value">-1/1</param>
    public static void GoHistory(int value)
    {
        #region
        string js = @"<Script language='JavaScript'>
                    history.go({0});  
                  </Script>";
        HttpContext.Current.Response.Write(string.Format(js, value));
        #endregion
    }

    /// <summary>
    /// �رյ�ǰ����
    /// </summary>
    public static void CloseWindow()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    parent.opener=null;window.close();  
                  </Script>";
        HttpContext.Current.Response.Write(js);
        HttpContext.Current.Response.End();
        #endregion
    }

    
    /// <summary>
    /// ˢ�´򿪴���
    /// </summary>
    public static void RefreshOpener()
    {
        #region
        string js = @"<Script language='JavaScript'>
                    opener.location.reload();
                  </Script>";
        HttpContext.Current.Response.Write(js);
        #endregion
    }


    /// <summary>
    /// ��ָ����С���´���
    /// </summary>
    /// <param name="url">��ַ</param>
    /// <param name="width">��</param>
    /// <param name="heigth">��</param>
    /// <param name="top">ͷλ��</param>
    /// <param name="left">��λ��</param>
    public static void OpenWebFormSize(string url, int width, int heigth, int top, int left)
    {
        #region
        string js = @"<Script language='JavaScript'>window.open('" + url + @"','','height=" + heigth + ",width=" + width + ",top=" + top + ",left=" + left + ",location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>";

        HttpContext.Current.Response.Write(js);
        #endregion
    }

    /// <summary>
    /// ��ָ����Сλ�õ�ģʽ�Ի���
    /// </summary>
    /// <param name="webFormUrl">���ӵ�ַ</param>
    /// <param name="width">��</param>
    /// <param name="height">��</param>
    /// <param name="top">������λ��</param>
    /// <param name="left">������λ��</param>
    public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
    {
        #region
        string features = "dialogWidth:" + width.ToString() + "px"
            + ";dialogHeight:" + height.ToString() + "px"
            + ";dialogLeft:" + left.ToString() + "px"
            + ";dialogTop:" + top.ToString() + "px"
            + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
        ShowModalDialogWindow(webFormUrl, features);
        #endregion
    }

    public static void ShowModalDialogWindow(string webFormUrl, string features)
    {
        string js = ShowModalDialogJavascript(webFormUrl, features);
        HttpContext.Current.Response.Write(js);
    }

    public static string ShowModalDialogJavascript(string webFormUrl, string features)
    {
        #region
        string js = @"<script language=javascript>							
							showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
        return js;
        #endregion
    }



    public static void ShowMsg(EeekSoft.Web.PopupWin PopupWin1, string Message)
    {
        //����ΪĬ�ϵ���Ϣ���� 
        PopupWin1.ActionType = EeekSoft.Web.PopupAction.MessageWindow;
        //���ô��ڵı��⣬��Ϣ���� 
        PopupWin1.Title = "Warning��";
        PopupWin1.Message = Message;
        PopupWin1.Text = Message;
        //������ɫ��� 
        PopupWin1.ColorStyle = EeekSoft.Web.PopupColorStyle.Blue;
        //���ô��ڵ�������ʧ��ʱ�� 
        PopupWin1.HideAfter = 3000;
        PopupWin1.ShowAfter = 100;
        PopupWin1.Visible = true;
    }

    public static bool IsInteger(string s)
    {
        string pattern = @"^\d*$";
        return System.Text.RegularExpressions.Regex.IsMatch(s, pattern);

    }

    public static void f_data_2_ddlb(string ps_sql, System.Web.UI.Control pddlb)
    {
        DropDownList ddlb = (DropDownList)pddlb;
        ddlb.Items.Clear();
        ddlb.Items.Add("");
        System.Data.DataTable ldt = SQLHelper.GetDataTable(ps_sql);
        for (int li_i = 0; li_i < ldt.Rows.Count; li_i++)
        {
            ddlb.Items.Add(ldt.Rows[li_i][0].ToString().Trim());
        }
    }

    //��datatable����
    public static DataTable f_dt_order(DataTable dt, string ps_order)
    {
        DataView dv = dt.DefaultView;
        dv.Sort = ps_order;
        System.Data.DataTable dt2 = dv.ToTable();
        return dt2;
    }
}
