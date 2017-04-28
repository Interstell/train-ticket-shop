using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TrainTicketShop.Entities {
    public interface ITicketOrderCommand {
        void ConfirmPayment();
        void CancelOrder();
    }

    public class TicketOrder : ITicketOrderCommand {
        public List<Ticket> Tickets { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string HashCode { get; set; }

        public void CancelOrder() {
            throw new NotImplementedException();
        }

        public void ConfirmPayment() {
            throw new NotImplementedException();
        }

        public void SetHashCode() {
            using (MD5 md5Hash = MD5.Create()) {
                this.HashCode = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(
                    this.Email + ((DateTimeOffset)this.CreationDate).ToUnixTimeMilliseconds())).ToString();
            }
        }
    }
}