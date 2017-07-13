using ChatClientWPF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClientWPF
{
    class MainWindowViewModel : IChatCallback, INotifyPropertyChanged
    {
        private static InstanceContext context;
        private static ChatClient proxy;
        public MainWindowViewModel()
        {
            context = new InstanceContext(this);
            proxy = new ChatClient(context);
        }


        #region Fields and properties
        private ObservableCollection<string> users;
        public ObservableCollection<string> Users
        {
            get { return users ?? (users = new ObservableCollection<string>()); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        private string textOfChat;

        public string TextOfChat
        {
            get { return textOfChat; }
            set
            {
                textOfChat = value;
                OnPropertyChanged("TextOfChat");
            }
        }

        private string selectedUser;

        public string SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        
        #endregion


        #region Commands
        private RelayCommand joinCommand;
        public RelayCommand JoinCommand
        {
            get
            {
                return joinCommand ?? (joinCommand = new RelayCommand(obj =>
                    {
                        if (!string.IsNullOrWhiteSpace(Name))
                        {
                            if (!proxy.GetNames().Contains(Name))
                            {
                                proxy.Join(Name);
                            }
                            else
                            {
                                MessageBox.Show("Такой никнейм уже существует.");
                            }
                        }
                        else MessageBox.Show("Нельзя использовать пустое имя.");
                    }));
            }
        }

        private RelayCommand leaveCommand;
        public RelayCommand LeaveCommand
        {
            get
            {
                return leaveCommand ?? (leaveCommand = new RelayCommand(obj =>
                    {
                        proxy.Leave(Name);
                        Users.Clear();
                        TextOfChat = "";
                        Message = "";
                    }));
            }
        }

        private RelayCommand sendMessageCommand;
        public RelayCommand SendMessageCommand
        {
            get
            {
                return sendMessageCommand ?? (sendMessageCommand = new RelayCommand(obj =>
                    {
                        proxy.SendMessage(Name, Message);
                        Message = "";
                    }));
            }
        }

        private RelayCommand sendPrivateMessageCommand;
        public RelayCommand SendPrivateMessageCommand
        {
            get
            {
                return sendMessageCommand ?? (sendPrivateMessageCommand = new RelayCommand(obj =>
                {
                    if (SelectedUser != null)
                    {
                        proxy.SendPrivateMessage(Name, Message, SelectedUser);
                        Message = "";
                    }
                    else
                    {
                        MessageBox.Show("Не выбран получатель.");
                    }
                }));
            }
        }

        private RelayCommand closeWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ?? (closeWindowCommand = new RelayCommand(obj =>
                    {
                        if (Users.Count > 0) proxy.Leave(Name);
                    }));
            }
        }
        
        #endregion


        #region IChatCallback
        public void AddUserToList(string name, bool showMessage)
        {
            Users.Add(name);
            if (showMessage)
            {
                TextOfChat += string.Format("<К нам присоединился {0}>\n", name);
            }
        }

        public void DeleteUserFromList(string name, bool showMessage)
        {
            Users.Remove(name);
            if (showMessage)
            {
                TextOfChat += string.Format("<Нас покинул {0}>\n", name);
            }
        }

        public void PrintMessage(string name, string message)
        {
            TextOfChat += string.Format("<{0}>: {1}\n", name, message);
        }

        public void PrintPrivateMessage(string nameFrom, string message, string nameTo)
        {
            TextOfChat += string.Format("<{0} (личное {1})>: {2}\n", nameFrom, nameTo, message);
        }

        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
