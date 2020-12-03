using System;
using System.Collections.Generic;
using System.Text;

namespace SystemSp.DTOS.EntitisIndexApp
{
    public class UserInformation
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string UserTelephone { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int? UserType { get; set; }
        public UserMessageStates MessageStates { get; set; }
    }
    public class UserMessageStates 
    {
        public bool UserExist { get; set; }
        public bool UserCreateSuccessfull { get; set; }
        public bool UserIdentificationExist { get; set; }
        public bool UserEmailExist { get; set; }
    }
    public class UserInformationResult 
    {
        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                this._userId = value;
                this.NotifyDataChanged();
            }
        }
        private string _userName;
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                this._userName = value;
                this.NotifyDataChanged();
            }
        }
        private string _userImage;
        public string UserImage
        {
            get
            {
                return this._userImage;
            }
            set
            {
                this._userImage = value;
                this.NotifyDataChanged();
            }
        }
        private string _userTelephone;
        public string UserTelephone
        {
            get
            {
                return this._userTelephone;
            }
            set
            {
                this._userTelephone = value;
                this.NotifyDataChanged();
            }
        }
        private string _userEmail;
        public string UserEmail
        {
            get
            {
                return this._userEmail;
            }
            set
            {
                this._userEmail = value;
                this.NotifyDataChanged();
            }
        }
        private string _userPassword;
        public string UserPassword
        {
            get
            {
                return this._userPassword;
            }
            set
            {
                this._userPassword = value;
                this.NotifyDataChanged();
            }
        }
        private UserMessageStates _messageStates = new UserMessageStates();
        public UserMessageStates MessageStates
        {
            get
            {
                return this._messageStates;
            }
            set
            {
                this._messageStates = value;
                this.NotifyDataChanged();
            }
        }
        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();

    }
    public class UserSession 
    {
        private bool _isAvtive;
        public bool IsActive 
        {
            get 
            {
                return _isAvtive;
            }
            set 
            {
                _isAvtive = value;
                NotifyDataChanged();
            }
        }

        private DateTime? _lastEntry = DateTime.Now;
        public DateTime? LastEntry
        {
            get
            {
                return _lastEntry;
            }
            set
            {
                _lastEntry = value;
                NotifyDataChanged();
            }
        }
        private Guid? _passChanged;
        public Guid? PassChanged
        {
            get
            {
                return _passChanged;
            }
            set
            {
                _passChanged = value;
                NotifyDataChanged();
            }
        }

        public event Action OnChange;
        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}
