﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PJCalender
{
    class UserControl
    {
        String userLoggedIn;
        public UserControl(String type, Menus mainForm)
        {
            //currentUserLoggedIn();
            if (type.Equals("Login"))
            {
                string[] files = Directory.GetFiles(@".credentials/.archived.users", "*");

                UsernameDialog login = new UsernameDialog(mainForm);
                login.ShowDialog();

                userLoggedIn = login.username;

                bool fileNotFound = true;

                foreach (String file in files)
                {
                    if (file.Split('-')[1].Equals(userLoggedIn))
                    {
                        File.Move(file, @".credentials/currentUser/" + file.Split('\\')[1]);
                        userLoggedIn = file.Split('-')[1];
                        fileNotFound = false;
                        break;
                    }
                }

                if (fileNotFound)
                {
                    if (!String.IsNullOrEmpty(userLoggedIn))
                    {
                        new google(mainForm, userLoggedIn);
                    }
                    
                }

                type = "Logout";
            }
            else {
                try
                {
                    string file = Directory.GetFiles(@".credentials/currentUser", "*")[0];
                    File.Delete(@".credentials/.archived.users/" + file.Split('\\')[1]);
                    File.Move(file, @".credentials/.archived.users/" + file.Split('\\')[1]);
                }
                catch (System.IndexOutOfRangeException indexEx)
                {
                    MessageBox.Show(indexEx.ToString(), indexEx.GetType().ToString());
                }
                type = "Login";
            }
        }

        static public String currentUserLoggedIn()
        {
            String file;
            try
            {
                if (!Directory.Exists(@".credentials/currentUser"))
                {
                    Directory.CreateDirectory(@".credentials/currentUser");
                }
                file = Directory.GetFiles(@".credentials/currentUser", "*")[0];
                return file.Split('-')[1];
            }
            catch (System.IndexOutOfRangeException ex)
            {
                return null;
                throw ex;
            }
        }
    }
}
