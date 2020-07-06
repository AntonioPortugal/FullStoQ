using Recodme.RD.FullStoQ.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recodme.RD.FullStoQ.Data.Person
{
    public class Message : Entity
    {
        private string _text;
        [Required]
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                RegisterChange();
            }
        }

        [ForeignKey("ProfileSender")]
        public Guid ProfileSenderId { get; set; }
        public virtual Profile ProfileSender { get; set; }

        [ForeignKey("ProfileReceiver")]
        public Guid ProfileReceiverId { get; set; }
        public virtual Profile ProfileReceiver { get; set; }

        public Message(string text, Guid profileSenderId, Guid profileReceiverId) : base()
        {
            _text = text;
            ProfileReceiverId = profileReceiverId;
            ProfileSenderId = profileSenderId;
        }
        public Message(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string text, Guid profileSenderId, Guid profileReceiverId) : base(id, createdAt, updatedAt, isDeleted)
        {
            _text = text;
            ProfileReceiverId = profileReceiverId;
            ProfileSenderId = profileSenderId;
        }
    }
}
