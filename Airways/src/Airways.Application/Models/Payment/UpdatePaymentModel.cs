﻿namespace Airways.Application.Models.Payment
{
    public class UpdatePaymentModel
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public PayStatus payStatus { get; set; }
        public CardType paymentType { get; set; }
        public Guid User_id { get; set; }
        public Guid Order_id { get; set; }
    }
    public class UpdatePaymentResponceModel : BaseResponceModel { }
}
