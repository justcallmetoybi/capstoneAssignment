using Caliburn.Micro;
using DISPLAY__ADD__EDIT_AND_DELETE_FROM_DATABASE.Models;
using System.Collections.Generic;
using System.Data;

namespace DISPLAY__ADD__EDIT_AND_DELETE_FROM_DATABASE.ViewModels
{
    public class MainWindowViewModel : Screen
    {
        private DataTable _datagridmembersSource;

        public DataTable datagridmembersSource
        {
            get { return _datagridmembersSource; }
            set { _datagridmembersSource = value; }
        }

        protected override void OnActivate()
        {
            _datagridmembersSource = Conn.DbTable("Select user_id as 'ID', user_fname as 'First Name', user_lname as 'Last Name', user_gender as 'Gender' from users_tbl;");

            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        private string _fnameTextbox;

        public string fnameTextbox
        {
            get { return _fnameTextbox; }
            set { _fnameTextbox = value; }
        }

        private string _lnameTextbox;

        public string lnameTextbox
        {
            get { return _lnameTextbox; }
            set { _lnameTextbox = value; }
        }

        private List<string> _genderCombobox;

        public List<string> genderCombobox
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _genderCombobox = value; }
        }

        private object _datagridSelecteditem;

        public object datagridSelecteditem
        {
            get { return _datagridSelecteditem; }
            set { _datagridSelecteditem = value; }
        }

        private string _genderComboboxSelecteditem;

        public string genderComboboxSelecteditem
        {
            get { return this._genderComboboxSelecteditem; }
            set
            {
                this._genderComboboxSelecteditem = value;
                this.NotifyOfPropertyChange(() => this.genderComboboxSelecteditem);
            }
        }

        private IWindowManager windowManager = new WindowManager();
        private string _selectedGridid;
        private string selectedGridid;

        public MainWindowViewModel(string selectedGridid)
        {
            this.selectedGridid = selectedGridid;
        }

        public void showdatagridSelecteditem()
        {
            DataRowView dataRowView = (DataRowView)_datagridSelecteditem;
            _selectedGridid = dataRowView.Row[0].ToString();
            windowManager.ShowWindow(new MainWindowViewModel(_selectedGridid), null, null);
        }

    

        public void updateButton()
        {
            DataTable dt = Conn.DbTable("Select * from users_tbl where user_id = " + _selectedGridid + ";");
            _fnameTextbox = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(() => fnameTextbox);
            _lnameTextbox = dt.Rows[0][2].ToString();
            NotifyOfPropertyChange(() => lnameTextbox);
            _genderComboboxSelecteditem = dt.Rows[0][3].ToString();
            NotifyOfPropertyChange(() => genderComboboxSelecteditem);
            _selectedGridid = dt.Rows[0][0].ToString();
            NotifyOfPropertyChange(() => selectedGridid);
        }

        public void refreshButton()
        {
            _datagridmembersSource = Conn.DbTable("Select user_id as 'ID', user_fname as 'First Name', user_lname as 'Last Name', user_gender as 'Gender' from users_tbl;");
            NotifyOfPropertyChange(() => datagridmembersSource);
        }

        public void insertButton()
        {
            Conn.DbComm("INSERT INTO `capstoneassignment`.`users_tbl` (`user_fname`, `user_lname`, `user_gender`) VALUES('" + _fnameTextbox + "','" + _lnameTextbox + "','" + _genderComboboxSelecteditem + "');");
        }
    }
}