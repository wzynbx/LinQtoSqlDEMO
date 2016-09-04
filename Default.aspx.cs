using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            BinderToGridView(1,2);

        }
    }

    private void BinderToGridView()
    {
        //获取DataContext--获取映射文件--当我们对DB进行对象操作的时候，自动生成相对应的SQL语句
        LinQDBDataContext linqDB = new LinQDBDataContext();

        var result = linqDB.User;
        
        //要实现分页处理
        this.GridView1.DataSource = result;
        this.GridView1.DataBind();
    }
    private void BinderToGridView(int pageIndex,int pageSize)
    {
        //获取DataContext--获取映射文件--当我们对DB进行对象操作的时候，自动生成相对应的SQL语句
        LinQDBDataContext linqDB = new LinQDBDataContext();
        var result = linqDB.User;
        
        int pageTotal=(result.Count()+pageSize-1)/pageSize;
        this.DropDownList1.DataSource = (System.Linq.Enumerable.Range(1, pageTotal)).ToList<int>();
        this.DropDownList1.DataBind();

        //要实现分页处理--跳过（pageIndex-1)*pageSize条记录，然后提取pageSize条记录
        this.GridView1.DataSource = result.Skip((pageIndex - 1) * pageSize).Take(pageSize);

        this.GridView1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        BinderToGridView(int.Parse(this.DropDownList1.SelectedItem.ToString()), 2);
    }
}