using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using C1.Win.C1Input;
using C1.Win.C1TrueDBGrid;
using PCSComUtils.Admin.BO;
using PCSComUtils.Admin.DS;
using PCSComUtils.Common;
using PCSComUtils.Common.BO;
using PCSComUtils.DataAccess;
using PCSComUtils.PCSExc;
using PCSUtils.Log;
using PCSUtils.Utils;
using System.Linq;
using CancelEventArgs = System.ComponentModel.CancelEventArgs;
using PCSComUtils.DataContext;

namespace PCSUtils.Admin
{
    /// <summary>
    /// ManageRole Form. 
    /// Created by: Cuong NT
    /// Implemented by: Thien HD.	
    /// </summary>
    public class ManageUser : Form
    {
        #region Declaration
        private EnumAction mFormAction = EnumAction.Default;
        public EnumAction FormAction
        {
            set { mFormAction = value; }
            get { return mFormAction; }
        }

        #region System Generated

        private Button btnAdd;
        private Button btnDelete;
        private Button btnClose;
        private Button btnEdit;
        private Button btnHelp;
        private Button btnSave;
        private ComboBox cboCCNID;
        private CheckBox chkActivate;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components;

        private C1DateEdit dtmExpiredDate;

        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private C1TrueDBGrid tgridViewData;
        private TextBox txtDescription;
        private TextBox txtExpiredDate;
        private TextBox txtName;
        private TextBox txtPassword;
        private TextBox txtPwd;
        private TextBox txtPwd_Re;
        private TextBox txtUserID;
        private TextBox txtUserName;

        #endregion System Generated

        private const string MASTERLOCATIONCODE = "MasterLocationCode";
        private const string THIS = "PCSUtils.Admin.ManageUser";
        private readonly bool blnEditUpdateData;
        private Button btnMasLoc; //This variable is used to determine user action to edit or not
        private Button btnName;
        private DataSet dstData;
        private DataTable dtbStoreGridLayout;
        private Label lblMasterLocation;
        private TextBox txtMasterLocation;
        private TextBox txtPwd_Old; // this variable is used to store all data for this form;

        #endregion Declaration

        #region Constructor, Destructor

        public ManageUser()
        {
            InitializeComponent();
        }

        public ManageUser(bool blnEditUpdateData)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            this.blnEditUpdateData = blnEditUpdateData;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion Constructor, Destructor

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUser));
            C1.Win.C1TrueDBGrid.Style style1 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style2 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style3 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style4 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style5 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style6 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style7 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style8 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style9 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style10 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style11 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style12 = new C1.Win.C1TrueDBGrid.Style();
            C1.Win.C1TrueDBGrid.Style style13 = new C1.Win.C1TrueDBGrid.Style();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExpiredDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtPwd_Re = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCCNID = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkActivate = new System.Windows.Forms.CheckBox();
            this.tgridViewData = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtPwd_Old = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dtmExpiredDate = new C1.Win.C1Input.C1DateEdit();
            this.btnName = new System.Windows.Forms.Button();
            this.txtMasterLocation = new System.Windows.Forms.TextBox();
            this.lblMasterLocation = new System.Windows.Forms.Label();
            this.btnMasLoc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tgridViewData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmExpiredDate)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtExpiredDate
            // 
            resources.ApplyResources(this.txtExpiredDate, "txtExpiredDate");
            this.txtExpiredDate.Name = "txtExpiredDate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtPwd
            // 
            resources.ApplyResources(this.txtPwd, "txtPwd");
            this.txtPwd.Name = "txtPwd";
            // 
            // txtPwd_Re
            // 
            resources.ApplyResources(this.txtPwd_Re, "txtPwd_Re");
            this.txtPwd_Re.Name = "txtPwd_Re";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // cboCCNID
            // 
            this.cboCCNID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboCCNID, "cboCCNID");
            this.cboCCNID.Name = "cboCCNID";
            this.cboCCNID.SelectedValueChanged += new System.EventHandler(this.cboCCNID_SelectedValueChanged);
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // chkActivate
            // 
            resources.ApplyResources(this.chkActivate, "chkActivate");
            this.chkActivate.Name = "chkActivate";
            // 
            // tgridViewData
            // 
            resources.ApplyResources(this.tgridViewData, "tgridViewData");
            this.tgridViewData.CaptionStyle = style1;
            this.tgridViewData.EditorStyle = style2;
            this.tgridViewData.EvenRowStyle = style3;
            this.tgridViewData.FilterBarStyle = style4;
            this.tgridViewData.FooterStyle = style5;
            this.tgridViewData.GroupStyle = style6;
            this.tgridViewData.HeadingStyle = style7;
            this.tgridViewData.HighLightRowStyle = style8;
            this.tgridViewData.Images.Add(((System.Drawing.Image)(resources.GetObject("tgridViewData.Images"))));
            this.tgridViewData.InactiveStyle = style9;
            this.tgridViewData.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow;
            this.tgridViewData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None;
            this.tgridViewData.Name = "tgridViewData";
            this.tgridViewData.OddRowStyle = style10;
            this.tgridViewData.PreviewInfo.Location = ((System.Drawing.Point)(resources.GetObject("tgridViewData.PreviewInfo.Location")));
            this.tgridViewData.PreviewInfo.Size = ((System.Drawing.Size)(resources.GetObject("tgridViewData.PreviewInfo.Size")));
            this.tgridViewData.PreviewInfo.ZoomFactor = ((double)(resources.GetObject("tgridViewData.PreviewInfo.ZoomFactor")));
            this.tgridViewData.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("tgridViewData.PrintInfo.PageSettings")));
            this.tgridViewData.PrintInfo.ShowOptionsDialog = ((bool)(resources.GetObject("tgridViewData.PrintInfo.ShowOptionsDialog")));
            this.tgridViewData.RecordSelectorStyle = style11;
            this.tgridViewData.RowDivider.Color = ((System.Drawing.Color)(resources.GetObject("resource.Color")));
            this.tgridViewData.RowDivider.Style = ((C1.Win.C1TrueDBGrid.LineStyleEnum)(resources.GetObject("resource.Style")));
            this.tgridViewData.SelectedStyle = style12;
            this.tgridViewData.Style = style13;
            this.tgridViewData.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.tgridViewData_RowColChange);
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Name = "txtUserID";
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Name = "btnClose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtPwd_Old
            // 
            resources.ApplyResources(this.txtPwd_Old, "txtPwd_Old");
            this.txtPwd_Old.Name = "txtPwd_Old";
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtmExpiredDate
            // 
            // 
            // 
            // 
            this.dtmExpiredDate.Calendar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dtmExpiredDate.Calendar.ImeMode")));
            resources.ApplyResources(this.dtmExpiredDate, "dtmExpiredDate");
            this.dtmExpiredDate.Name = "dtmExpiredDate";
            this.dtmExpiredDate.Tag = null;
            // 
            // btnName
            // 
            resources.ApplyResources(this.btnName, "btnName");
            this.btnName.Name = "btnName";
            this.btnName.Click += new System.EventHandler(this.btnName_Click);
            // 
            // txtMasterLocation
            // 
            resources.ApplyResources(this.txtMasterLocation, "txtMasterLocation");
            this.txtMasterLocation.Name = "txtMasterLocation";
            this.txtMasterLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMasterLocation_KeyDown);
            this.txtMasterLocation.Validating += new System.ComponentModel.CancelEventHandler(this.txtMasterLocation_Validating);
            // 
            // lblMasterLocation
            // 
            this.lblMasterLocation.ForeColor = System.Drawing.Color.Maroon;
            resources.ApplyResources(this.lblMasterLocation, "lblMasterLocation");
            this.lblMasterLocation.Name = "lblMasterLocation";
            // 
            // btnMasLoc
            // 
            resources.ApplyResources(this.btnMasLoc, "btnMasLoc");
            this.btnMasLoc.Name = "btnMasLoc";
            this.btnMasLoc.Click += new System.EventHandler(this.btnMasLoc_Click);
            // 
            // ManageUser
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.btnClose;
            this.Controls.Add(this.btnMasLoc);
            this.Controls.Add(this.lblMasterLocation);
            this.Controls.Add(this.txtMasterLocation);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.dtmExpiredDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPwd_Old);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtPwd_Re);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tgridViewData);
            this.Controls.Add(this.chkActivate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboCCNID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Name = "ManageUser";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.ManageUser_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.tgridViewData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtmExpiredDate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Class's Method

        /// <summary>
        /// Load data into grid
        /// </summary>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void LoadForm()
        {
            const int FULLNAME_WIDTH = 200;

            //Init the BO object
            var objManageUserBO = new ManageUserBO();
            
            //Get the list of roles for this data and store into dstData variable
            dstData = objManageUserBO.List();            
            //tgridViewData.DataSource = listUser;
            dstData.Tables[0].DefaultView.Sort = Sys_UserTable.USERNAME_FLD;

            dstData.Tables[0].PrimaryKey = new[] { dstData.Tables[0].Columns[Sys_UserTable.USERID_FLD] };

            //Grant this data into the grid
            tgridViewData.DataSource = dstData.Tables[0];

            for (var i = 0; i < tgridViewData.Splits[0].DisplayColumns.Count; i++)
                tgridViewData.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;

            //Set the role name to be unique
            dstData.Tables[0].Columns[Sys_UserTable.USERNAME_FLD].Unique = true;

            //set the ROLE ID to Identity column
            dstData.Tables[0].Columns[Sys_UserTable.USERID_FLD].AutoIncrement = true;

            //invisible USER ID column
            tgridViewData.Splits[0].DisplayColumns[Sys_UserTable.USERID_FLD].Visible = false;

            tgridViewData.Splits[0].DisplayColumns[Sys_UserTable.NAME_FLD].Width = FULLNAME_WIDTH;

            tgridViewData.Columns[Sys_UserTable.EXPIREDDATE_FLD].NumberFormat = Constants.DATETIME_FORMAT;
            tgridViewData.Columns[Sys_UserTable.CREATEDDATE_FLD].NumberFormat = Constants.DATETIME_FORMAT;
            FormControlComponents.RestoreGridLayout(tgridViewData, dtbStoreGridLayout);
        }


        /// <summary>
        /// This method is used to display the current row in data grid to textboxes
        /// </summary>
        /// <param name="drvDataRowView"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void DisplayTheCurrentRowInfor(DataRowView drvDataRowView)
        {
            //User Name
            txtUserName.Text = drvDataRowView[Sys_UserTable.USERNAME_FLD].ToString();

            //Full Name
            txtName.Text = drvDataRowView[Sys_UserTable.NAME_FLD].ToString();
            txtName.Tag = drvDataRowView[Sys_UserTable.EMPLOYEEID_FLD].ToString();

            txtMasterLocation.Text = drvDataRowView[MASTERLOCATIONCODE].ToString();
            txtMasterLocation.Tag = drvDataRowView[MST_MasterLocationTable.MASTERLOCATIONID_FLD];
            //Description
            txtDescription.Text = drvDataRowView[Sys_UserTable.DESCRIPTION_FLD].ToString();

            //Disable 
            if (drvDataRowView[Sys_UserTable.ACTIVATE_FLD] != DBNull.Value)
            {
                chkActivate.Checked = (bool)drvDataRowView[Sys_UserTable.ACTIVATE_FLD];
            }
            else
            {
                chkActivate.Checked = false; //Disable
            }

            //User ID
            txtUserID.Text = drvDataRowView[Sys_UserTable.USERID_FLD].ToString();

            //Expire Date
            dtmExpiredDate.Value = drvDataRowView[Sys_UserTable.EXPIREDDATE_FLD];

            //Password
            txtPwd.Text = drvDataRowView[Sys_UserTable.PWD_FLD].ToString();
            txtPwd_Re.Text = drvDataRowView[Sys_UserTable.PWD_FLD].ToString();
            txtPwd_Old.Text = drvDataRowView[Sys_UserTable.PWD_FLD].ToString();

            //HACK: Added by Tuan TQ -- 20 May 2005
            //Check user name for super administrator & lock related buttons
            bool bIsSuperUser = txtUserName.Text.Equals(Constants.SUPER_ADMIN_USER);
            btnEdit.Enabled = !bIsSuperUser;
            btnSave.Enabled = !bIsSuperUser;
            //End hack
        }


        /// <summary>
        /// Clear all textbox to add a new user
        /// </summary>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void ClearForm()
        {
            //clear data and focus
            txtUserID.Text = String.Empty;
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPwd.Text = String.Empty;
            txtPwd_Old.Text = String.Empty;
            txtPwd_Re.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtName.Text = String.Empty;
            txtName.Tag = null;
            txtMasterLocation.Text = String.Empty;
            txtMasterLocation.Tag = null;
            dtmExpiredDate.Value = DBNull.Value;
            dtmExpiredDate.Text = String.Empty;

            chkActivate.Checked = false;
            //cboCCNID.SelectedIndex = -1;

            if (cboCCNID.Items.Count > 0)
            {
                cboCCNID.SelectedIndex = 0;
            }
            FormControlComponents.SetDefaultMasterLocation(txtMasterLocation);
            txtUserName.Focus();
        }


        /// <summary>
        /// Add a new user into database
        /// </summary>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void AddNewUser()
        {

        }


        /// <summary>
        /// Validate data
        /// </summary>
        /// <param name="blnValidateAdd"></param>
        /// <returns></returns>
        /// <author> Thien HD, Jan 07, 2005</author>

        private bool ValidateData(bool blnValidateAdd)
        {
            bool blnCheckPwd = true;
            // check user name
            if (!CheckMandatory(txtUserName))
            {
                PCSMessageBox.Show(ErrorCode.MANDATORY_INVALID, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }


            if (!blnValidateAdd)
            {
                blnCheckPwd = txtPwd.Text != txtPwd_Old.Text;
            }

            if (blnCheckPwd)
            {
                //check Password
                if (txtPwd.Text.Length == 0)
                {
                    PCSMessageBox.Show(ErrorCode.MANDATORY_INVALID, MessageBoxIcon.Error);
                    txtPwd.Focus();
                    return false;
                }

                //check repassword
                if (txtPwd.Text != txtPwd_Re.Text)
                {
                    PCSMessageBox.Show(ErrorCode.NEWPASSWORD_DIFFERENT_CONFIRMPASSWORD, MessageBoxIcon.Error);
                    txtPwd_Re.Focus();
                    return false;
                }
            }
            else // check difference Password and ConfirmPassword
            {
                //check repassword
                if (txtPwd.Text != txtPwd_Re.Text)
                {
                    PCSMessageBox.Show(ErrorCode.NEWPASSWORD_DIFFERENT_CONFIRMPASSWORD, MessageBoxIcon.Error);
                    txtPwd_Re.Focus();
                    return false;
                }
            }

            //Check fullname
            if (txtName.Text.Trim() == String.Empty)
            {
                PCSMessageBox.Show(ErrorCode.MANDATORY_INVALID, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            //Check MasterLocation
            if (txtMasterLocation.Text.Trim() == String.Empty)
            {
                PCSMessageBox.Show(ErrorCode.MANDATORY_INVALID, MessageBoxIcon.Error);
                txtMasterLocation.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtmExpiredDate.Text))
            {
                MessageBox.Show("Nhập ngày hết hạn.", SystemProperty.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error); dtmExpiredDate.Focus(); return false;
            }
            //check expire date
            if (dtmExpiredDate.Value.ToString().Trim() != String.Empty)
            {
                // get the system date from database
                var objManageUserBO = new ManageUserBO();
                DateTime dtmDatabaseDate = objManageUserBO.GetDatabaseDate();
                // DateTime dtmCurrentInputDate = (DateTime)dtmExpiredDate.Value;

                if (((DateTime)dtmExpiredDate.Value).Date < dtmDatabaseDate.Date)
                {
                    PCSMessageBox.Show(ErrorCode.MESSAGE_MANAGEUSER_EXPIREDDATE, MessageBoxIcon.Error);
                    dtmExpiredDate.Focus();
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// This method to check data in two texboxes code and name
        /// </summary>
        /// <param name="pobjControl"></param>
        /// <returns></returns>
        /// <author> Thien HD, Jan 07, 2005</author>
        private bool CheckMandatory(Control pobjControl)
        {
            if (pobjControl.Text.Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// Update the user information
        /// </summary>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void UpdateUserInfor()
        {
            //validate data before saving
            if (!ValidateData(true))
            {
                return;
            }
            const string METHOD_NAME = THIS + ".UpdateUserInfor()";
            try
            {
                Sys_User objUser = new Sys_User();
                //get the system date
                var objManageUserBO = new ManageUserBO();
                if (!string.IsNullOrEmpty(txtUserID.Text.Trim()))
                {
                    objUser.UserID = int.Parse(txtUserID.Text.Trim());
                    if (objManageUserBO.UserExist(txtUserName.Text.Trim(), txtUserID.Text.Trim()))
                    {
                        //UserName da ton tai
                        PCSMessageBox.Show(ErrorCode.DUPLICATE_KEY, MessageBoxIcon.Error);
                        txtUserName.Focus();
                        return;
                    }
                }
                else
                {
                    if (objManageUserBO.UserExist(txtUserName.Text.Trim(), string.Empty))
                    {
                        //UserName da ton tai
                        PCSMessageBox.Show(ErrorCode.DUPLICATE_KEY, MessageBoxIcon.Error);
                        txtUserName.Focus();
                        return;
                    }
                    objUser.UserID = 0;
                }
                //objUser.LastLoginTime = objUser.CreatedDate = objUser.LastLogoutTime = Utilities.Instance.GetDBDate();
                //objUser.Super = 0;
                objUser.UserName = txtUserName.Text = txtUserName.Text.Trim();
                objUser.Name = txtName.Text = txtName.Text.Trim();
                objUser.Pwd = CryptoUtil.EncryptPassword(txtPwd.Text);
                objUser.Description = txtDescription.Text = txtDescription.Text.Trim();
                objUser.EmployeeID = Convert.ToInt32(txtName.Tag);
                objUser.MasterLocationID = Convert.ToInt32(txtMasterLocation.Tag);
                objUser.Activate = chkActivate.Checked;
                objUser.CCNID = SystemProperty.CCNID;
                if (dtmExpiredDate.Value != DBNull.Value && dtmExpiredDate.Value.ToString().Trim() != String.Empty)
                    objUser.ExpiredDate = (DateTime)dtmExpiredDate.Value;
                else
                    objUser.ExpiredDate = objUser.CreatedDate;
                //Call the BO class to store this object
                var intUserID = objManageUserBO.AddNewUserAndReturnNewID(objUser);
                FormAction = EnumAction.Default;
                SetEnable();
                //Reload Database
                LoadForm();
                //find to that row
                var intUpdatedRow = 0; 
                for (var i = 0; i < tgridViewData.RowCount; i++)
                {
                    if (tgridViewData[i, Sys_UserTable.USERID_FLD].ToString() != intUserID.ToString()) continue;
                    intUpdatedRow = i;
                    break;
                }
                tgridViewData.Row = intUpdatedRow;
                tgridViewData.Col = tgridViewData.Columns.IndexOf(tgridViewData.Columns[Sys_UserTable.USERNAME_FLD]);
                //Display Message
                PCSMessageBox.Show(ErrorCode.MESSAGE_AFTER_SAVE_DATA, MessageBoxIcon.Information);
            }
            catch (PCSException ex)
            {
                // displays the error message.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
                txtUserName.Focus();
            }
            catch (ConstraintException ex)
            {
                PCSMessageBox.Show(ErrorCode.MESSAGE_ROLE_NAME_DUPLICATE, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
                txtUserName.Focus();
            }

            catch (Exception ex)
            {
                // displays the error message.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
        }

        #endregion Class's Method

        #region Event Processing

        /// <summary>
        ///   This method is used to load data
        ///   Data for the True DBGrid data for Combox Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void ManageUser_Load(object sender, EventArgs e)
        {
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            const string METHOD_NAME = THIS + ".ManageRole_Load()";
            //Call the LoadForm method to load data for the first time
            try
            {
                #region Security

                //Set authorization for user
                var objSecurity = new Security();
                Name = THIS;
                if (objSecurity.SetRightForUserOnForm(this, SystemProperty.UserName) == 0)
                {
                    Close();
                    // You don't have the right to view this item
                    PCSMessageBox.Show(ErrorCode.MESSAGE_YOU_HAVE_NO_RIGHT_TO_VIEW, MessageBoxIcon.Warning);
                    // Code Inserted Automatically

                    #region Code Inserted Automatically

                    Cursor = Cursors.Default;

                    #endregion Code Inserted Automatically

                    return;
                }

                #endregion

                dtbStoreGridLayout = FormControlComponents.StoreGridLayout(tgridViewData);
                dtmExpiredDate.CustomFormat = Constants.DATETIME_FORMAT;

                //Load CCN
                //LoadCCN();

                //Load data into grid
                LoadForm();
            }
            catch (PCSException ex)
            {
                // displays the error message.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // displays the error message.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                // log message
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }

        /// <summary>
        /// This method is used to display the current row information
        /// to texboxes and date time, combo box ect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void tgridViewData_RowColChange(object sender, RowColChangeEventArgs e)
        {
            const string METHOD_NAME = THIS + ".tgridViewData_RowColChange()";
            try
            {
                //DataSet ds =(DataSet) dbgDetailRouting.DataSource;
                var cm =
                    (CurrencyManager)tgridViewData.BindingContext[tgridViewData.DataSource, tgridViewData.DataMember];
                if (cm.Position >= 0)
                {
                    //DataRow dr = dstData.Tables[0].Rows[cm.Position];
                    var dv = (DataRowView)cm.Current;
                    DisplayTheCurrentRowInfor(dv);
                    FormAction = EnumAction.Default;
                    SetEnable();
                }
            }
            catch (InvalidCastException ex)
            {
                PCSMessageBox.Show(ErrorCode.MESSAGE_DATA_CAST, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            txtUserName.Focus();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            Close();

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }


        private void ManageUser_Closing(object sender, CancelEventArgs e)
        {
            const string METHOD_NAME = THIS + ".ManageUser_Closing()";
            try
            {
                if (blnEditUpdateData)
                {
                    if (
                        PCSMessageBox.Show(ErrorCode.MESSAGE_QUESTION_STORE_INTO_DATABASE, MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Delete the current row in true DB Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAction = EnumAction.Edit;
            SetEnable();
        }
        private void SetEnable()
        {
            switch (FormAction)
            {
                case EnumAction.Add:
                    btnAdd.Enabled = btnDelete.Enabled = btnEdit.Enabled = false;
                    btnSave.Enabled = true;
                    txtDescription.Enabled = txtExpiredDate.Enabled = txtMasterLocation.Enabled = true;
                    txtName.Enabled = txtPassword.Enabled = txtPwd.Enabled = txtPwd_Old.Enabled = txtPwd_Re.Enabled = txtUserName.Enabled = true;
                    break;
                case EnumAction.Edit:
                    btnAdd.Enabled  = btnEdit.Enabled = false;
                    btnDelete.Enabled = btnSave.Enabled = true;
                    txtDescription.Enabled = txtExpiredDate.Enabled = txtMasterLocation.Enabled = true;
                    txtName.Enabled = txtPassword.Enabled = txtPwd.Enabled = txtPwd_Old.Enabled = txtPwd_Re.Enabled = txtUserName.Enabled = true;
                    break;
                case EnumAction.Default:
                    txtDescription.Enabled = txtExpiredDate.Enabled = txtMasterLocation.Enabled = false;
                    txtName.Enabled = txtPassword.Enabled = txtPwd.Enabled = txtPwd_Old.Enabled = txtPwd_Re.Enabled = txtUserName.Enabled = false;
                    btnAdd.Enabled = true;
                    btnSave.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Add a new row into the truedb grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAction = EnumAction.Add;
            SetEnable();
            txtUserName.Focus();            
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            const string METHOD_NAME = THIS + ".btnClear_Click()";
            try
            {
                ClearForm();
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }


        /// <summary>
        /// Save the current modification to the current row into grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            const string METHOD_NAME = THIS + ".btnSave_Click()";
            try
            {
                //BEGIN: Added by Tuan TQ -- 20th May 2005
                if (txtUserName.Text.Trim().Equals(Constants.SUPER_ADMIN_USER)) return;
                //END: Added by Tuan TQ 

                UpdateUserInfor();
                //txtUserName.Focus();
            }
            catch (PCSException ex)
            {
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                // log message.
                try
                {
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }


        /// <summary>
        /// Clear data in form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author> Thien HD, Jan 07, 2005</author>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Code Inserted Automatically
            Cursor = Cursors.WaitCursor;
            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            const string METHOD_NAME = THIS + ".btnDelete_Click()";
            try
            {
                if (tgridViewData.RowCount == 0)
                {
                    return;
                }

                string strUserID = tgridViewData[tgridViewData.Row, Sys_UserTable.USERID_FLD].ToString();
                string strUserName = tgridViewData[tgridViewData.Row, Sys_UserTable.USERNAME_FLD].ToString();

                //BEGIN: Added by Tuan TQ -- 20th May 2005
                //if(txtUserName.Text.Equals(Constants.SUPER_ADMIN_USER)) return;			
                if (strUserName.Equals(Constants.SUPER_ADMIN_USER)) return;
                //END: Added by Tuan TQ 

                if (strUserID.Trim() == String.Empty)
                {
                    PCSMessageBox.Show(ErrorCode.MESSAGE_MANAGEUSER_SELECT_USER, MessageBoxIcon.Error);
                    return;
                }

                DialogResult result;
                result = PCSMessageBox.Show(ErrorCode.MESSAGE_DELETE_RECORD, MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var objManageUserBO = new ManageUserBO();
                    objManageUserBO.DeleteUser(int.Parse(strUserID));
                    ClearForm();
                    LoadForm();
                    PCSMessageBox.Show(ErrorCode.MESSAGE_AFTER_SAVE_DATA);
                }
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            Cursor = Cursors.Default;
        }

        #endregion Event Processing

        private void btnName_Click(object sender, EventArgs e)
        {
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            // find customer base on code
            const string METHOD_NAME = THIS + ".btnName_Click()";
            try
            {
                //Hashtable htbCriteria = new Hashtable();
                //htbCriteria.Add(CUSTOMER, (int)PartyTypeEnum.CUSTOMER);
                DataRowView drwResult = FormControlComponents.OpenSearchForm(MST_EmployeeTable.TABLE_NAME,
                                                                             MST_EmployeeTable.NAME_FLD, txtName.Text,
                                                                             null, true);
                if (drwResult != null)
                {
                    txtName.Text = drwResult[MST_EmployeeTable.NAME_FLD].ToString();
                    txtName.Tag = drwResult[MST_EmployeeTable.EMPLOYEEID_FLD];
                }
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            string METHOD_NAME = THIS + ".txtPause_Validating()";
            try
            {
                if (!txtName.Modified) return;
                if (txtName.Text.Trim() == string.Empty)
                {
                    txtName.Tag = null;
                    return;
                }

                DataRowView drwResult = FormControlComponents.OpenSearchForm(MST_EmployeeTable.TABLE_NAME,
                                                                             MST_EmployeeTable.CODE_FLD,
                                                                             txtName.Text.Trim(), null, false);
                if (drwResult != null)
                {
                    txtName.Tag = drwResult[MST_EmployeeTable.EMPLOYEEID_FLD];
                    txtName.Text = drwResult[MST_EmployeeTable.NAME_FLD].ToString();
                }
                else
                    e.Cancel = true;
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
                if (btnName.Enabled)
                    btnName_Click(sender, e);
        }

        /// <summary>
        /// btnMasLoc_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Trada</author>
        /// <date>Wednesday, December 21 2005</date>
        private void btnMasLoc_Click(object sender, EventArgs e)
        {
            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.WaitCursor;

            #endregion Code Inserted Automatically

            const string METHOD_NAME = THIS + ".btnMasLoc_Click()";
            try
            {
                var drwResult = FormControlComponents.OpenSearchForm(MST_MasterLocationTable.TABLE_NAME,
                                                                             MST_MasterLocationTable.CODE_FLD,
                                                                             txtMasterLocation.Text.Trim(), null, true);

                if (drwResult != null)
                {
                    txtMasterLocation.Text = drwResult[MST_MasterLocationTable.CODE_FLD].ToString();
                    txtMasterLocation.Tag = drwResult[MST_MasterLocationTable.MASTERLOCATIONID_FLD];
                }
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                PCSMessageBox.Show(ex.mCode, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }

            // Code Inserted Automatically

            #region Code Inserted Automatically

            Cursor = Cursors.Default;

            #endregion Code Inserted Automatically
        }

        private void txtMasterLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
                if (btnMasLoc.Enabled)
                    btnMasLoc_Click(sender, e);
        }

        /// <summary>
        /// txtMasterLocation_Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Trada</author>
        /// <date>Wednesday, December 21 2005</date>
        private void txtMasterLocation_Validating(object sender, CancelEventArgs e)
        {
            const string METHOD_NAME = THIS + ".txtMasterLocation_Validating()";
            try
            {
                if (!txtMasterLocation.Modified) return;
                if (txtMasterLocation.Text.Trim() == string.Empty)
                {
                    txtMasterLocation.Tag = null;
                    return;
                }

                var drwResult = FormControlComponents.OpenSearchForm(MST_MasterLocationTable.TABLE_NAME,
                                                                             MST_MasterLocationTable.CODE_FLD,
                                                                             txtMasterLocation.Text.Trim(), null,
                                                                             false);

                if (drwResult != null)
                {
                    txtMasterLocation.Tag = drwResult[MST_MasterLocationTable.MASTERLOCATIONID_FLD];
                    txtMasterLocation.Text = drwResult[MST_MasterLocationTable.CODE_FLD].ToString();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Processing SelectedValueChanged event. Clear related data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboCCNID_SelectedValueChanged(object sender, EventArgs e)
        {
            const string METHOD_NAME = THIS + ".cboCCNID_SelectedValueChanged()";
            try
            {
                //txtMasterLocation.Text = string.Empty;
                //txtMasterLocation.Tag = "0";
            }
            catch (PCSException ex)
            {
                // Displays the error message if throwed from PCSException.
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex.CauseException, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Displays the error message if throwed from system.
                PCSMessageBox.Show(ErrorCode.OTHER_ERROR, MessageBoxIcon.Error);
                try
                {
                    // Log error message into log file.
                    Logger.LogMessage(ex, METHOD_NAME, Level.ERROR);
                }
                catch
                {
                    // Show message if logger has an error.
                    PCSMessageBox.Show(ErrorCode.LOG_EXCEPTION, MessageBoxIcon.Error);
                }
            }
        }
    }
}