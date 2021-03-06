﻿using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;
/// <summary>
/// arthor: Peyman Justin
/// </summary>
namespace PJCalender
{
    /// <summary>
    /// Handles all user files and actions
    /// </summary>
    class User
    {
        /// <summary>
        /// creates files for new user 
        /// </summary>
        /// <param name="userLoggedIn">username</param>
        /// <param name="mainForm">parent form</param>
        public User(Menus mainForm)
        {
            bool fileNotFound = true;
            string userLoggedIn = "user";

            if (!System.IO.Directory.Exists(".credentials/.archived.users"))
                System.IO.Directory.CreateDirectory(".credentials/.archived.users");
            string[] files = Directory.GetFiles(@".credentials/.archived.users", "*");
            
            foreach (String file in files)
            {
                if (file.Split('-')[1].Equals(userLoggedIn))
                {
                    File.Move(file, @".credentials/currentUser/" + file.Split('\\')[1]);
                    userLoggedIn = file.Split('-')[1];
                    //fileNotFound = false;
                    mainForm.loginButtonChangeText();
                    break;
                }
            }

            if (fileNotFound)
            {
                if (!String.IsNullOrEmpty(userLoggedIn))
                {

                    Thread t = new Thread(() => new google(mainForm));
                    t.Name = "Google";
                    t.Start();
                }
            }

            mainForm.displayAll(); // make delegate

        }
        /// <summary>
        /// Logout current user
        /// </summary>
        static public void Logout()
        {
            try
            {
                string file = Directory.GetFiles(@".credentials/currentUser", "*")[0];
                if(!String.IsNullOrEmpty(file))
                    File.Delete(file);
            }
            catch (System.IndexOutOfRangeException indexEx)
            {
                System.Diagnostics.Debug.WriteLine(indexEx.ToString(), indexEx.GetType().ToString());
                MessageBox.Show("Error on log out");
            }
        }
        /// <summary>
        /// returns a string with user name if they exist
        /// </summary>
        /// <returns>The name of the user logged in</returns>
        static public string currentUserLoggedIn()
        {
            String file;
            try
            {
                if (!Directory.Exists(".credentials/currentUser"))
                {
                    Directory.CreateDirectory(".credentials/currentUser");
                    return null;
                }
                else {
                    file = Directory.GetFiles(".credentials/currentUser", "*")[0];
                    return file;
                }
            }
            catch (System.IndexOutOfRangeException indexEx)
            {
                System.Diagnostics.Debug.WriteLine(indexEx.ToString(), indexEx.GetType().ToString());
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.ToString(), ex.GetType().ToString());
            }
            return null;
        }
    }
}
