using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRoles();
    }

    private void GetRoles()
    {
        LinQDBDataContext linqDB = new LinQDBDataContext();
        this.rdlRole.DataSource = linqDB.Role.ToList<Role>().Distinct();
        this.rdlRole.DataTextField = "RoleName";
        this.rdlRole.DataValueField = "RoleID";
        this.rdlRole.DataBind();
        this.rdlRole.Items[0].Selected = true;
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //是否已经存在
        LinQDBDataContext linqDB = new LinQDBDataContext();
        int i = linqDB.User.Where(p => this.txtName.Text == p.UserName).Count();
        if (i > 0)
        {
            Response.Write("<script language=javascript>window.alert('该用户已经存在')</script>");
            return;
        }
        //注册用户
        //OR映射实现注册
        //将需要保存的信息封装在对象内部，然后OR映射将对象转化为SQL语句
        User u = new User();
        u.UserName = this.txtName.Text;
        u.UserPassword = this.txtPwd.Text;
        u.RoleID = int.Parse(this.rdlRole.SelectedValue.ToString());
        //在容器中添加一个新对象
        linqDB.User.InsertOnSubmit(u);
        //更新到数据库
        linqDB.SubmitChanges();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //是否已经存在
        LinQDBDataContext linqDB = new LinQDBDataContext();
        int i = linqDB.User.Where(p => this.txtName.Text == p.UserName).Count();
        if (i > 0)
        {
            User u = linqDB.User.Where(p => p.UserName == this.txtName.Text).Single();
            u.UserPassword = this.txtPwd.Text;
            u.RoleID = int.Parse(this.rdlRole.SelectedValue.ToString());
            //更新对象
            linqDB.SubmitChanges();
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该用户已经存在')</script>");
            return;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        //是否已经存在
        LinQDBDataContext linqDB = new LinQDBDataContext();
        int i = linqDB.User.Where(p => this.txtName.Text == p.UserName).Count();
        if (i > 0)
        {
            User u = linqDB.User.Where(p => p.UserName == this.txtName.Text).Single();
            linqDB.User.DeleteOnSubmit(u);
            //更新对象
            linqDB.SubmitChanges();
        }
        else
        {
            Response.Write("<script language=javascript>window.alert('该用户已经存在')</script>");
            return;
        }
    }
}