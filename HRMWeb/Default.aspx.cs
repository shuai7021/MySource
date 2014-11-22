using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{


    private string employeeID,employeeName,connectionSetting,identityCard;
    private int  oaUserID,periodID,year,month;
    

    private bool IsCheckCardNo = false;

    DataSet dset = new DataSet();

    private List<String> employeeNameList = new List<String>();
    
    
   

    protected void Page_Load(object sender, EventArgs e)
    {
        connectionSetting = Convert.ToString(ConfigurationManager.ConnectionStrings["SqlServices"]);

         oaUserID = (Convert.ToInt32(Request.QueryString["id"].ToString()) - 118) / 85312 - 1;

        ////oaUserID = Convert.ToInt32(Request.QueryString["id"].ToString());

      
        //oaUserID = 12;
        ////employeeName.Text = oaUserID + "";
        //employeeID = "DL00087";
        GetEmployeeID();
  
     
        //if (employeeNameList.Contains(employeeName)) s_search.Enabled = false;



    }
    void Bind_Data(string strsql)
    {

        SqlConnection myconn = new SqlConnection(connectionSetting);
        //打开数据库连接
        myconn.Open();

   
        SqlCommand mycmd = new SqlCommand(strsql, myconn);

        //执行数据操作命令
        //SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
        SqlDataReader result = mycmd.ExecuteReader(CommandBehavior.CloseConnection);

        //绑定数据源
        salaryData.DataSource = result;
        //绑定数据
        salaryData.DataBind();
        for(int i=0;i<salaryData.Columns.Count;i++){
            ((BoundField)salaryData.Columns[i]).ItemStyle.Wrap = false;
            ((BoundField)salaryData.Columns[i]).ItemStyle.Width = 90;
        }
        if (salaryData.Columns.Count == 0)
        {
            //lbl_message.Visible = true;
            //lbl_message.Text = "搜索结果为空！";
        }

    }

    SqlDataReader GetDataReader(string sqltr) {
        SqlConnection myconn = new SqlConnection(connectionSetting);
        //打开数据库连接
        myconn.Open();


        SqlCommand mycmd = new SqlCommand(sqltr, myconn);

        //执行数据操作命令
        //SqlDataReader读取数据到记录集后，会自动关闭数据库的连接
        SqlDataReader result = mycmd.ExecuteReader(CommandBehavior.CloseConnection);
        return result;
       
      

        
}

    void GetDataSet(string sqlStr,string tableName) 
      {
          SqlConnection myconn = new SqlConnection(connectionSetting);
          //打开数据库连接
          myconn.Open();
         
          SqlDataAdapter sqlda = new SqlDataAdapter(sqlStr, myconn);
          sqlda.Fill(dset,tableName);
          myconn.Close();
         
      }
 
    void GetEmployeeID()
    {
        SqlDataReader dr = GetDataReader("select EmployeeID,EmployeeName,IdentityCard from Employee where EmployeeStatus='A' and OAID=" + oaUserID);
        if (dr.Read())
        {
            employeeID = dr.GetString(0);
            employeeName =dr.GetString(1);
            employeeNameLable.Text = employeeName;
            identityCard = dr.IsDBNull(2) ? "" : dr.GetString(2);


        }
        dr.Close();
    }

    void BindEmployeeInfo() {

        SqlDataReader dr = GetDataReader(@"SELECT Salary.EmployeeName AS 姓名, SYS_Depts.DeptName AS 部门, 
                                          CAST(Salary.JionDate AS varchar) AS 入厂日期, Salary.Probation AS 试用期, 
                                          CAST(Salary.ProbDate AS varchar) AS 转正日期, Position.PositionName AS 职位, 
                                          ParaSalaryType.ParaName AS 薪酬制度,Salary.PerformanceBase as 绩效基数, Salary.CoeffMark AS 个人绩效得分,Salary.CoeffPerson AS 个人绩效系数,Salary.PerformanceAllw as 绩效工资
                                    FROM Position INNER JOIN
                                          SYS_Parameter AS ParaSalaryType INNER JOIN
                                          SYS_Depts INNER JOIN
                                          Salary ON SYS_Depts.DeptID = Salary.DeptID ON 
                                          ParaSalaryType.ParaCode = Salary.SalaryType ON 
                                          Position.PositionCode = Salary.PositionCode 
                                    WHERE (ParaSalaryType.ParaType = 'SalaryType') and EmployeeID='" + employeeID + "' and PeriodID=" + periodID);
        if (dr.Read())
        {
           
            employeeDept.Text = dr.GetString(1);
            employeeJionDate.Text = dr.GetString(2);
            employeeProbation.Text = dr.GetString(3);
            if (dr.IsDBNull(4))
                employeeProDate.Text = "";
            else employeeProDate.Text = dr.GetString(4);
            emplpyeePostion.Text = dr.GetString(5);
            salaryType.Text = dr.GetString(6);


            if (!dr.IsDBNull(7))

                performanceBase.Text = dr.GetDecimal(7).ToString();
            else
                performanceBase.Text = "0";
        
            coefMark.Text = dr.GetDecimal(8).ToString();
            coeffPerson.Text = dr.GetDecimal(9).ToString();
            performanceAllw.Text = dr.GetDecimal(10).ToString();
           
    
        }
        else
        {
            emplpyeePostion.Text = "";
            salaryType.Text = "";
            performanceBase.Text ="";
          
            coefMark.Text = "";
            coeffPerson.Text = "";
            performanceAllw.Text ="";

        }
        dr.Close();
    
    }

    void BindSalary() 
    {
        int i=0;

        if (year < 2014)
        {
            if ((emplpyeePostion.Text.Trim().Equals("技工") || emplpyeePostion.Text.Trim().Equals("技师")) && employeeProbation.Text.Trim().Equals("否") && year >= 2013 && month >= 1)
            {
                GetDataSet(@"SELECT  Salary.BaseSalary AS 基本工资,  Salary.GOTSalary AS 周六加班工资, 
                          Salary.WorkAgeAllw AS 工龄补贴, Salary.EduAllw AS 学历补贴, Salary.SkillAllw AS 技能补贴, 
                          Salary.SumBase AS 底薪, 
                          Salary.HourAllw AS 平时加班工资,Salary.PieceSalary AS 计件工资,
                          Salary.PerformanceAllw AS 绩效工资, 
                          Salary.HouseAllw AS 住房补贴, Salary.MealAllw AS 伙食补贴, 
                          Salary.TransportAllw AS 搬运补贴, Salary.SecurityAllw AS 保安补贴, 
                          Salary.EnvironAllw AS 环境补贴, Salary.CleanAllw AS 卫生补贴, 
                          Salary.OtherAllw1 AS 其他补贴, Salary.OtherAllw2 AS 全勤奖, 
                          Salary.OtherAllw3 AS 其他奖励, Salary.ShouldSent AS 应发合计, 
                          Salary.Deduction1 AS 住宿费用, Salary.Deduction2 AS 水电费, 
                          Salary.MealsCounts AS 用餐次数, Salary.MealsFor AS 扣餐费, 
                          Salary.Deduction3 AS 考勤扣款, Salary.Deduction4 AS 扣工衣, 
                          Salary.HouseAcc AS 住房公积金, Salary.Assurance AS 保险, 
                          Salary.OtherAllw5 AS 固定扣款, Salary.Deduction5 AS 其他扣款, 
                          Salary.Deduction6 AS 罚款, Salary.OtherAllw4 AS [补/扣上月], 
                          Cast(round(Salary.SalaryTotal,0) as int) AS 税前工资合计
                    FROM Salary INNER JOIN
                          Employee ON Employee.EmployeeID = Salary.EmployeeID
                    WHERE Salary.PeriodID =" + periodID + " AND (Salary.EmployeeID = '" + employeeID + "')", "Salary");
            }
            else
            {
                GetDataSet(@"SELECT  Salary.BaseSalary AS 基本工资,  Salary.GOTSalary AS 周六加班工资, 
                           Salary.PostionAllw AS 岗位津贴,  Salary.WorkAgeAllw AS 工龄津贴, 
                          Salary.SumBase AS 底薪, Salary.PerformanceAllw AS 绩效工资, 
                          Salary.PieceSalary AS 计件工资, Salary.HourAllw AS 计时补贴, 
                          Salary.HouseAllw AS 住房补贴, Salary.MealAllw AS 伙食补贴, 
                          Salary.TransportAllw AS 搬运补贴, Salary.SecurityAllw AS 保安补贴, 
                          Salary.EnvironAllw AS 环境补贴, Salary.CleanAllw AS 卫生补贴, 
                          Salary.OtherAllw1 AS 其他补贴, Salary.OtherAllw2 AS 全勤奖, 
                          Salary.OtherAllw3 AS 其他奖励, Salary.ShouldSent AS 应发合计, 
                          Salary.Deduction1 AS 住宿费用, Salary.Deduction2 AS 水电费, 
                          Salary.MealsCounts AS 用餐次数, Salary.MealsFor AS 扣餐费, 
                          Salary.Deduction3 AS 考勤扣款, Salary.Deduction4 AS 扣工衣, 
                          Salary.HouseAcc AS 住房公积金, Salary.Assurance AS 保险, 
                          Salary.OtherAllw5 AS 固定扣款, Salary.Deduction5 AS 其他扣款, 
                          Salary.Deduction6 AS 罚款, Salary.OtherAllw4 AS [补/扣上月], 
                          Cast(round(Salary.SalaryTotal,0) as int) AS 税前工资合计
                    FROM Salary INNER JOIN
                          Employee ON Employee.EmployeeID = Salary.EmployeeID
                    WHERE Salary.PeriodID =" + periodID + " AND (Salary.EmployeeID = '" + employeeID + "')", "Salary");
            }
        }
        else 
        {

            if ((emplpyeePostion.Text.Trim().Equals("技工") || emplpyeePostion.Text.Trim().Equals("技师")) && employeeProbation.Text.Trim().Equals("否") )
            {
                GetDataSet(@"SELECT  Salary.BaseSalary AS 基本工资,  Salary.GOTSalary AS 周六加班工资, 
                          Salary.WorkAgeAllw AS 工龄补贴, Salary.EduAllw AS 学历补贴, Salary.SkillAllw AS 技能补贴, 
                          Salary.SumBase AS 底薪, 
                          Salary.HourAllw AS 平时加班工资,Salary.PieceSalary AS 计件工资,
                          Salary.PerformanceAllw AS 绩效工资, 
                          Salary.HouseAllw AS 住房补贴, Salary.MealAllw AS 伙食补贴, 
                          Salary.TransportAllw AS 搬运补贴, Salary.SecurityAllw AS 保安补贴, 
                          Salary.EnvironAllw AS 环境补贴, Salary.CleanAllw AS 卫生补贴, 
                          Salary.OtherAllw1 AS 其他补贴, Salary.OtherAllw2 AS 全勤奖, 
                          Salary.OtherAllw3 AS 其他奖励, Salary.ShouldSent AS 应发合计, 
                          Salary.Deduction1 AS 住宿费用, Salary.Deduction2 AS 水电费, 
                          Salary.MealsCounts AS 用餐次数, Salary.MealsFor AS 扣餐费, 
                          Salary.Deduction3 AS 考勤扣款, Salary.Deduction4 AS 扣工衣, 
                          Salary.HouseAcc AS 住房公积金, Salary.Assurance AS 保险, 
                          Salary.OtherAllw5 AS 固定扣款, Salary.Deduction5 AS 其他扣款, 
                          Salary.Deduction6 AS [赔偿/纪律扣款], Salary.OtherAllw4 AS [补/扣上月], 
                          Cast(round(Salary.SalaryTotal,0) as int) AS 税前工资合计
                    FROM Salary INNER JOIN
                          Employee ON Employee.EmployeeID = Salary.EmployeeID
                    WHERE Salary.PeriodID =" + periodID + " AND (Salary.EmployeeID = '" + employeeID + "')", "Salary");
            }
            else
            {
                GetDataSet(@"SELECT  Salary.BaseSalary AS 基本工资,  Salary.GOTSalary AS 周六加班工资, 
                           Salary.PostionAllw AS 岗位津贴,  Salary.WorkAgeAllw AS 工龄津贴, 
                          Salary.SumBase AS 底薪, Salary.PerformanceAllw AS 绩效工资, 
                          Salary.PieceSalary AS 计件工资, Salary.HourAllw AS 计时补贴, 
                          Salary.HouseAllw AS 住房补贴, Salary.MealAllw AS 伙食补贴, Salary.DiscAwards as 纪律奖金,
                          Salary.TransportAllw AS 搬运补贴, Salary.SecurityAllw AS 保安补贴, 
                          Salary.EnvironAllw AS 环境补贴, Salary.CleanAllw AS 卫生补贴, 
                          Salary.OtherAllw1 AS 其他补贴, Salary.OtherAllw2 AS 全勤奖, 
                          Salary.OtherAllw3 AS 其他奖励, Salary.ShouldSent AS 应发合计, 
                          Salary.Deduction1 AS 住宿费用, Salary.Deduction2 AS 水电费, 
                          Salary.MealsCounts AS 用餐次数, Salary.MealsFor AS 扣餐费, 
                          Salary.Deduction3 AS 考勤扣款, Salary.Deduction4 AS 扣工衣, 
                          Salary.HouseAcc AS 住房公积金, Salary.Assurance AS 保险, 
                          Salary.OtherAllw5 AS 固定扣款, Salary.Deduction5 AS 其他扣款, 
                          Salary.Deduction6 AS 赔偿, Salary.OtherAllw4 AS [补/扣上月], 
                          Cast(round(Salary.SalaryTotal,0) as int) AS 税前工资合计
                    FROM Salary INNER JOIN
                          Employee ON Employee.EmployeeID = Salary.EmployeeID
                    WHERE Salary.PeriodID =" + periodID + " AND (Salary.EmployeeID = '" + employeeID + "')", "Salary");
            }
        

        }

        DataTable dt = dset.Tables["Salary"];
        DataTable dataTable = new DataTable();
        if (dt.Columns.Count % 2 == 1) i = (dt.Columns.Count + 1) / 2;
        else i = dt.Columns.Count / 2;

        for (int j = 0; j < i; j++)
        {
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            dataTable.Columns.Add(column);
        }
        for (int j = 0; j < 4; j++)
        {
            DataRow dr = dataTable.NewRow();
            dataTable.Rows.Add(dr);
        }
        if (dt.Rows.Count > 0)
        {
            for (int m = 0; m < dt.Columns.Count; m++)
            {
                if (m / i >= 1)
                {
                    dataTable.Rows[2][m % i] = dt.Columns[m].ColumnName;
                    dataTable.Rows[3][m % i] = dt.Rows[0][m].ToString();
                }
                else
                {
                    dataTable.Rows[0][m] = dt.Columns[m].ColumnName;
                    dataTable.Rows[1][m] = dt.Rows[0][m].ToString();
                }
            }
        }
        salaryData.DataSource = dataTable;
        salaryData.DataBind();
        if (dt.Rows.Count == 0)
        {
            salaryMessage.Visible =true;
            salaryData.Visible = false;
        }
        else 
        {
            salaryMessage.Visible = false;
            salaryData.Visible = true;
        }
      

    }

    void BindAttend() 
    {
        GetDataSet(@"SELECT Shift.ShiftName AS 班制, Attendance.ClosedDay AS 结算周期天数, 
                                          Attendance.NormalWorkDay AS 正常出勤天数, 
                                          Attendance.PersonNormalDay AS 个人应出勤天数, 
                                          Attendance.WorkingDay AS 实际出勤天数, Attendance.AbsentDay AS 缺勤天数, 
                                          Attendance.LeaveDay AS 请假天数, Attendance.NoReasonAbsent AS 旷工天数, 
                                          Attendance.LateMins AS 迟到早退分钟, Attendance.Rewards AS 全勤奖, 
                                          Attendance.Deduction AS 纪律扣款, SYS_Parameter.ParaName AS 状态
                                    FROM Shift INNER JOIN
                                          Employee ON Shift.ShiftID = Employee.ShiftID INNER JOIN
                                          Attendance ON Employee.EmployeeID = Attendance.EmployeeID INNER JOIN
                                          SYS_Depts ON Employee.DeptID = SYS_Depts.DeptID INNER JOIN
                                          SYS_Parameter ON SYS_Parameter.ParaCode = Attendance.CheckFlag
                                    WHERE (SYS_Parameter.ParaType = 'CheckFlag') and Attendance.EmployeeID='"+employeeID+"' and PeriodID=" +periodID,"Attend");
        attendData.DataSource = dset.Tables["Attend"];
        attendData.DataBind();
        if (attendData.Rows.Count == 0)
            attendMessage.Visible = true;
        else
            attendMessage.Visible = false;

    }

    void BindRePunish()
    {
        GetDataSet(@"select RePunish.RePuType AS 奖扣类型,Cast(RePunish.HappenTime AS varchar) as 发生时间, 
                                          RePunish.Reason AS 原因, RePunish.HappenCost AS [奖励/扣款], 
                                          CAST(RePunish.PeriodYear AS varchar) 
                                          + '年' + CAST(RePunish.PeriodMonth AS varchar) + '月' AS 计入工资月份                                        
                                    FROM RePunish INNER JOIN
                                          SYS_Period ON RePunish.PeriodYear = SYS_Period.YearID AND 
                                          RePunish.PeriodMonth = SYS_Period.MonthID 
                                    WHERE  SYS_Period.PeriodID="+periodID+" and EmployeeID='"+employeeID+"'","Repunish");
        reDeduData.DataSource = dset.Tables["Repunish"];
        reDeduData.DataBind();
        if (reDeduData.Rows.Count == 0)
            redeuMassage.Visible = true;
        else
            redeuMassage.Visible = false;

    }

    void BindLeave()
    {
        GetDataSet(@"SELECT  CONVERT(varchar,LeaveDetail.FromDate, 120 ) AS 开始日期, LeaveDetail.FromHour AS 开始时间, 
              CONVERT(varchar,LeaveDetail.ToDate , 120 ) AS 结束日期, LeaveDetail.ToHour AS 结束时间, 
              LeaveDetail.LeaveDays AS 请假天数, LeaveDetail.Reason AS 请假事由
        FROM LeaveDetail INNER JOIN
              SYS_Period ON LeaveDetail.ToDate >= SYS_Period.FromDate AND 
              LeaveDetail.ToDate <= SYS_Period.ToDate 
        WHERE (LeaveDetail.TransStatus = 1) AND (LeaveDetail.AuditStatus = 'Y') AND  LeaveDetail.LeaveType=1 and SYS_Period.PeriodID=" + periodID + " and  LeaveDetail.EmployeeID='" + employeeID + "'", "Leave");
        leaveData.DataSource = dset.Tables["Leave"];
        leaveData.DataBind();
        if (leaveData.Rows.Count == 0)
            leaveMessage.Visible = true;
        else
            leaveMessage.Visible = false;

    }

    void bindPaidLeve() 
    {
        GetDataSet(@"SELECT CONVERT(varchar,LeaveDetail.FromDate, 120 )  AS 休息开始日期 ,LeaveDetail.FromHour AS 休息开始时间, 
         CONVERT(varchar,LeaveDetail.ToDate, 120 )  AS 休息结束日期, LeaveDetail.ToHour AS 休息结束时间, 
          CONVERT(varchar,LeaveDetail.WorkFromDate, 120 )  AS 上班开始日期, LeaveDetail.WorkFromHour AS 上班开始时间, 
          CONVERT(varchar,LeaveDetail.WorkToDate, 120 )  AS 上班结束日期, LeaveDetail.WorkToHour AS 上班结束时间, 
          ABS(LeaveDetail.LeaveDays) AS 调休天数, LeaveDetail.Reason AS 调休事由
          FROM   
            LeaveDetail INNER JOIN 
            SYS_Period ON LeaveDetail.ToDate >= SYS_Period.FromDate AND 
            LeaveDetail.ToDate <= SYS_Period.ToDate
          WHERE (LeaveDetail.TransStatus = 1) AND (LeaveDetail.AuditStatus = 'Y') and  LeaveDetail.LeaveType=0 AND  SYS_Period.PeriodID=" + periodID + " and  LeaveDetail.EmployeeID='" + employeeID + "'", "paidLeave");
        paidLeave.DataSource = dset.Tables["paidLeave"];
        paidLeave.DataBind();
        if (paidLeave.Rows.Count == 0)
            paidLeaveMessage.Visible = true;
        else
            paidLeaveMessage.Visible = false;
    }

    void bindOverTimeWageMessage() 
    {
       
        GetDataSet(@"SELECT  CONVERT(varchar,OccurDate, 120 ) AS 加班日期, WorkTime AS [加班时长（小时）], UnitPrice AS 单价, TotalPrice AS 合计, Remarks AS 备注
          FROM   
             TimeWage INNER JOIN 
            SYS_Period ON  TimeWage.OccurDate >= SYS_Period.FromDate AND 
            TimeWage.OccurDate <= SYS_Period.ToDate
          WHERE (TimeWage.CheckStatus = 1)  AND  SYS_Period.PeriodID=" + periodID + " and TimeWage.EmployeeID='" + employeeID + "'", "OverTimeWage");
         overTimeWage.DataSource = dset.Tables["OverTimeWage"];
         overTimeWage.DataBind();



         if (overTimeWage.Rows.Count == 0)

         {
             overTimeWageTotal.DataSource = null ;
             overTimeWageTotal.DataBind();
             overTimeWageMessage.Visible = true;
         }
         else
         {
             GetDataSet(@"SELECT '合计',sum(WorkTime) AS [加班时长（小时）],'', sum(TotalPrice) AS 合计, ''
          FROM   
             TimeWage INNER JOIN 
            SYS_Period ON  TimeWage.OccurDate >= SYS_Period.FromDate AND 
            TimeWage.OccurDate <= SYS_Period.ToDate
          WHERE (TimeWage.CheckStatus = 1)  AND  SYS_Period.PeriodID=" + periodID + " and TimeWage.EmployeeID='" + employeeID + "'", "OverTimeWageTotal");
             overTimeWageTotal.DataSource = dset.Tables["OverTimeWageTotal"];
             overTimeWageTotal.DataBind();

             overTimeWageMessage.Visible = false;
         }
    }

    
    void lookUpPeriod(int year ,int month) {

        SqlDataReader dr = GetDataReader("select  * from SYS_Period where ClosedStatus=1 and YearID=" + year + " and MonthID=" + month);
        //SqlDataReader dr = GetDataReader("select  * from SYS_Period where YearID=" + year + " and MonthID=" + month);

        if (dr.Read()) 
        {
            periodID = dr.GetInt32(0);
        }
        dr.Close();
         
    }

    protected void s_search_Click(object sender, EventArgs e)
    {

        if (!this.IsCheckCardNo)
        {
            if (!checkIdentityCard()) return;
            else {
                this.txtCardNo.Visible = false;
                this.LblCardNo.Visible = false;
            }
        }


        if (!checkOAPwd())
        {
            year = Convert.ToInt32(listYear.SelectedValue);
            month = Convert.ToInt32(listMonth.SelectedValue);
            lookUpPeriod(year, month);

            BindEmployeeInfo();
            BindAttend();
            BindSalary();
            BindLeave();
            bindPaidLeve();
            BindRePunish();
            bindOverTimeWageMessage();
            
        }
    }


    bool checkOAPwd() 
    {
        
        bool isDefaultPwd = false;

        byte[] result = Encoding.Default.GetBytes("000000");    //tbPass为输入密码的文本框
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] output = md5.ComputeHash(result);
        string defaultPwd = BitConverter.ToString(output).Replace("-", "").ToLower();  //tbMd5pass为输出加密文本的文本框

        SqlDataReader dr = GetDataReader(String.Format("SELECT [password] FROM [firstframe].[dbo].[system_users] where id={0}",oaUserID));
        //SqlDataReader dr = GetDataReader("select  * from SYS_Period where YearID=" + year + " and MonthID=" + month);

        if (dr.Read())
        {
            string pwd = dr.GetString(0);
            if (pwd.Equals(defaultPwd))
            {
                this.Response.Write("<Script Language='JavaScript'>window.alert('当前OA密码仍为初始密码，请修改OA密码以后再查询！');</script>");
                return true;
            }
            
        }

        
        return isDefaultPwd;
    }


    bool checkIdentityCard() 
    {
    if (String.IsNullOrEmpty(this.txtCardNo.Text.Trim()))
        {
            this.Response.Write("<Script Language='JavaScript'>window.alert('请输入身份号码进行验证！');</script>");
            this.txtCardNo.Focus();
            return false;
        }
        else 
        {
            if (String.IsNullOrEmpty(this.identityCard))
            {
                this.Response.Write("<Script Language='JavaScript'>window.alert('未登记身份证号码，请联系人力资源部！');</script>");
                this.txtCardNo.Focus();
                return false;
            }
            else 
            {
                if (!this.identityCard.ToUpper().Equals(txtCardNo.Text.Trim().ToUpper()))
                {
                    this.Response.Write("<Script Language='JavaScript'>window.alert('身份证号码不匹配！');</script>");
                    this.txtCardNo.Focus();
                    return false;
                }
                else
                {
                    this.IsCheckCardNo = true;
                    return true;
                }
            }
        }  

       
    }



    
}
