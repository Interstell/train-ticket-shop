using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TrainTicketShop.Services;

namespace TrainTicketShop.Entities {
    public interface ITicketOrderCommand {
        void ConfirmPayment();
        void CancelOrder();
        void Book();
    }

    public class TicketOrder : ITicketOrderCommand {
        [NonSerialized]
        public ITicketData TicketData;
        [NonSerialized]
        public IOrderCacheService OrderCacheService;

        public List<Ticket> Tickets { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string HashCode { get; set; }

        public TicketOrder(IOrderCacheService orderCacheService, ITicketData ticketData) {
            OrderCacheService = orderCacheService;
            TicketData = ticketData;
        }

        public void CancelOrder() {
            OrderCacheService.Delete(this);
        }

        public void Book() {
            OrderCacheService.Set(this);
        }

        public void ConfirmPayment() {
            foreach(var ticket in Tickets) {
                TicketData.Add(ticket);
            }
            TicketData.Commit();
        }

        public void SetHashCode() {
            using (MD5 md5Hash = MD5.Create()) {
                byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(
                    this.Email + ((DateTimeOffset)this.CreationDate).ToUnixTimeMilliseconds()));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++) {
                    sb.Append(hash[i].ToString("X2"));
                }
                this.HashCode = sb.ToString();
            }
        }
    }
}