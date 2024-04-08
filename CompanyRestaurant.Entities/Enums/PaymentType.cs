namespace CompanyRestaurant.Entities.Enums
{
    public enum PaymentType
    {
        Cash, // Nakit
        CreditCard, // Kredi Kartı
        Check, // Çek
        BankTransfer, // Banka Transferi
        OnlinePayment, // Online Ödeme (Paypal, Stripe vb.)
        TL,
        Euro,
        Dolar
    }
}
