using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using ADLib;

namespace ADDemo
{
    public partial class main : Form
    {
        ActiveDirectory ad;
        
        BindingSource userBinding = new BindingSource();
        BindingSource groupBinding = new BindingSource();
        List<Control> allUserControls;
        public main()
        {
            InitializeComponent();
            //Initialize bindings
            userBinding.DataSource = typeof(ADUser);
            groupBinding.DataSource = typeof(IList<String>);

            //Add bindings from controls to data structures
            userName.DataBindings.Add("Text", userBinding, "GivenName");
            userSurname.DataBindings.Add("Text", userBinding, "Surname");
            userDisplayName.DataBindings.Add("Text", userBinding, "DisplayName");
            userDescription.DataBindings.Add("Text", userBinding, "Description");
            userEmail.DataBindings.Add("Text", userBinding, "EmailAddress");
            userMainPhone.DataBindings.Add("Text", userBinding, "VoiceTelephoneNumber");
            userSAMAccountName.DataBindings.Add("Text", userBinding, "SamAccountName");
            userEnabled.DataBindings.Add("Checked", userBinding, "Enabled",true, DataSourceUpdateMode.OnPropertyChanged);
            searchResults.DataSource = userBinding;
            searchResults.AutoGenerateColumns = true;

            save.DataBindings.Add("Enabled", userBinding, "isSaveable");
            deleteButton.DataBindings.Add("Enabled", userBinding, "isDeleteable");

            //Handle the "position changed" event, so we can initialize non-bound controls for the new record
            userBinding.PositionChanged += userBindings_NewCurrent;

            userGroups.DataSource = groupBinding;
            groupBinding.DataSource = userBinding;
            groupBinding.DataMember = "Groups";
            userGroups.DisplayMember = "Groups";

            //Create a list of all our AD user controls so they can be iterated
            allUserControls = new List<Control>()
            {
                userName,userSurname, userDisplayName, userEmail, userMainPhone, userGroups,
                save, addGroup, removeGroup, deleteButton, userPassword1, userPassword2, userEnabled,
                userDescription, userSAMAccountName, newGroup
            };

            //Disable all controls by default
            set_Control_Enable(false);
            searchType.SelectedIndex=0;

            try
            {
                //Connect to the AD server
                ad = new ActiveDirectory(ConfigurationManager.AppSettings["AdContainer"],
                                            ConfigurationManager.AppSettings["AdName"],
                                            ConfigurationManager.AppSettings["AdUserId"],
                                            ConfigurationManager.AppSettings["AdPassword"]);
            }
            catch (PrincipalServerDownException ex)
            {
                //Print out the error text, write the status, and disable search controls
                Error_Message(ex.Message);
                Set_Status("AD connection failed");
                queryString.Enabled = false;
                search.Enabled = false;
                newButton.Enabled = false;
            }
        }

        /// <summary>
        /// Initialize controls
        /// </summary>
        /// <param name="enabled">Flags whether controls should be enabled</param>
        private void set_Control_Enable(Boolean enabled)
        {
            //For each control
            foreach (Control control in allUserControls)
            {
                //If the control isn't bound
                if (control.DataBindings.Count < 1)
                {
                    if (control is TextBox)
                    {
                        //Blank out text boxes
                        control.Text = "";
                    }
                    else if (control is ListBox && ((ListBox)control).DataSource == null)
                    {
                        //Clear listboxes
                        ((ListBox)control).Items.Clear();
                    }
                    else if (control is CheckBox)
                    {
                        //Uncheck check boxes
                        ((CheckBox)control).Checked = false;
                    }
                }

                //Set enabled
                control.Enabled = enabled;
            }
        }

        /// <summary>
        /// Update user data fields, disabling if bindings are empty
        /// </summary>
        private void update_Display()
        {
            set_Control_Enable(userBinding.Count > 0);
        }

        /// <summary>
        /// Write a message to the diagnostic window
        /// </summary>
        /// <param name="message">A message to write</param>
        private void Write(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        /// <summary>
        /// Implements a single user search by SAMAccountID.  No longer used, but left for an example
        /// </summary>
        /// <param name="userID">User ID for which to search</param>
        private void Single_User_Search(string userID)
        {
            //Clear the bindings
            userBinding.Clear();

            if (userID != "")
            {
                try
                {
                    //Add the user object if it's found
                    userBinding.Add(new ADUser(ad, ad.GetUser(userID)));
                }
                catch (ADNotFound ex)
                {
                    //Not found, write out a message
                    Write(ex.Message);
                }
                catch (Exception ex)
                {
                    //Unknown error, pop up an error box
                    Error_Message(ex.Message);
                }

                //Set the status box accordingly
                Set_Status("Search " + toSucceeded(userBinding.Count > 0));
            }

            //Update the display
            update_Display();
        }

        /// <summary>
        /// Implements a multi-object search
        /// </summary>
        /// <param name="name">Object name to search for</param>
        private void Many_User_Search(string name)
        {
            Boolean success = false;
            ADObjectFactory factory = new ADObjectFactory(ad);

            //Clear out the data
            userBinding.Clear();

            //Disable controls
            set_Control_Enable(false);
            try
            {
                //For each Princpal returned by ad.Find...
                foreach (Principal item in ad.Find(name, ADObjectType.User))
                {
                    //Create an ADObject using the factory, and add it to the binding
                    userBinding.Add(factory.toADObject(item));

                    //Enable user controls
                    set_Control_Enable(true);
                }

                success = true;
            }
            catch (Exception ex)
            {
                //If we get an error, display the message in a message box
                Error_Message(ex.Message);
            }

            //Reset the bindings to update bound controls
            userBinding.ResetBindings(false);

            //Set the status text
            Set_Status("Search " + toSucceeded(success));
        }

        /// <summary>
        /// Process clicks of the search button
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void search_Click(object sender, EventArgs e)
        {
            switch (searchType.Text)
            {
                case "Users":
                    Many_User_Search(queryString.Text);
                    break;
                //case "Groups":
                default:
                    Error_Message("Search type not yet implemented");
                    break;

            }

        }

        /// <summary>
        /// Retrieves the currently selected item in the databinding set
        /// </summary>
        private ADUser currentUser
        {
            get { return (ADUser)userBinding.Current; }
            set { userBinding.Add(value); }
        }

        /// <summary>
        /// Handles when the queryString box is entered.
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void queryString_Enter(object sender, EventArgs e)
        {
            //Select all text
            queryString.SelectAll();
        }

        /// <summary>
        /// Process clicks of the save button
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void save_Click(object sender, EventArgs e)
        {
            if (userBinding.Count > 0)
            {
                Boolean success = false;
                try
                {
                    if (currentUser.isSaveable)
                    {
                        currentUser.Save();
                        success = true;
                        userBinding.ResetBindings(false);
                    }
                }
                catch (Exception ex)
                {
                    Write(ex.ToString());
                    Error_Message(ex.Message.Trim());
                }
                Set_Status("Save " + toSucceeded(success));
            }
        }

        /// <summary>
        /// Process clicks to the addGroup button
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void addGroup_Click(object sender, EventArgs e)
        {
            if (newGroup.Text.Length > 0)
            {
                //Get the group by that name
                GroupPrincipal group = ad.GetGroup(newGroup.Text);
                Boolean abortAdd = false;

                if (group == null)
                {
                    //Group doesn't exist, create it?
                    DialogResult result = MessageBox.Show("Group doesn't exist, create it?", "Adding group...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Create the group
                        ad.CreateGroup(newGroup.Text);
                    }
                    else
                    {
                        //Don't add the non-existant group if we're not creating it
                        abortAdd = true;
                    }
                }

                //If we're still adding the group
                if (!abortAdd)
                {
                    //Add the group
                    currentUser.Groups.Add(newGroup.Text);

                    //Reset bindings to update the controls
                    userBinding.ResetBindings(false);

                    //Clear the newGroup text
                    newGroup.Clear();
                }
            }
        }

        /// <summary>
        /// Handle clicks to the removeGroup button
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void removeGroup_Click(object sender, EventArgs e)
        {
            foreach (int index in userGroups.SelectedIndices)
            {
                currentUser.Groups.RemoveAt(index);
                newGroup.Text = (string) userGroups.Items[index];
            }
            userBinding.ResetBindings(false);
        }

        /// <summary>
        /// Handle when the userPassword1 box is changed
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void userPassword1_TextChanged(object sender, EventArgs e)
        {
            //If the text is not empty, and it's the same as userPassword2
            if (userPassword1.Text.Length > 0 && userPassword1.Text == userPassword2.Text)
            {
                //Update the object's password field
                currentUser.Password = userPassword1.Text;

                //Reset bindings to update controls
                userBinding.ResetBindings(false);
            }

        }

        /// <summary>
        /// Handle when the userPassword2 box is changed
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void userPassword2_TextChanged(object sender, EventArgs e)
        {
            //If the text is not empty, and it's the same as userPassword1
            if (userPassword2.Text.Length > 0 && userPassword1.Text == userPassword2.Text)
            {
                //Update the object's password field
                currentUser.Password = userPassword1.Text;

                //Reset bindings to update controls
                userBinding.ResetBindings(false);
            }
        }

        /// <summary>
        /// Handle clicks of the 'new' button
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void newButton_Click(object sender, EventArgs e)
        {
            //Clear the bound data
            userBinding.Clear();

            //Add a blank ADUser object
            userBinding.Add(new ADUser(ad));

            //Update controls
            update_Display();

            //Reset bindings to update controls
            userBinding.ResetBindings(false);
        }

        /// <summary>
        /// Handle 'delete' button clicks
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //If the object can be deleted
            if (currentUser.isDeleteable)
            {
                //Get the currently selected object
                ADObject current = (ADObject)userBinding.Current;

                //Temporarily suspend binding so we don't mess it up by deleting items
                userBinding.SuspendBinding();

                //Clear the binding data
                userBinding.Clear();

                //Delete the object from the remote server
                current.Delete();

                //Resume binding
                userBinding.ResumeBinding();

                //Disable controls
                set_Control_Enable(false);

                //Update status
                Set_Status("Delete Succeeded");
            }
            
        }

        /// <summary>
        /// Handles writing to the status bar
        /// </summary>
        /// <param name="status">Status text to write</param>
        private void Set_Status(string status)
        {
            queryStatusLabel.Text = System.DateTime.Now.ToString() + " - " + status.Trim();
        }

        /// <summary>
        /// Pop up an error box
        /// </summary>
        /// <param name="message">Message to display</param>
        private void Error_Message(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Converts boolean values to 'succeeded' or 'failed'
        /// </summary>
        /// <param name="result">Boolean pass/fail</param>
        /// <returns>'Succeeded' or 'Failed'</returns>
        private string toSucceeded(Boolean result)
        {
            return (result ? "Succeeded" : "Failed");
        }

        /// <summary>
        /// Handles when the 'current' item of the userbinding set changes
        /// </summary>
        /// <param name="sender">object from which the event was sent</param>
        /// <param name="e">Arguments to the event</param>
        private void userBindings_NewCurrent(object sender, EventArgs e)
        {
            //Clear out controls and enable
            set_Control_Enable(true);
        }
    }
}
