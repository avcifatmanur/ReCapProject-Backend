using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç eklendi!";
        public static string CarDeleted = "Araç silindi!";
        public static string CarUpdated = "Araç bilgileri güncellendi!";
        public static string CarListed = "Araçlar listelendi!";
        public static string CarInvalid = "Araç bilgileri geçersiz!";

        public static string ColorAvailable = "Renk zaten mevcut!";
        public static string ColorAdded = "Renk eklendi!";
        public static string ColorDeleted = "Renk silindi!";
        public static string ColorUpdated = "Renk bilgileri güncellendi!";
        public static string ColorInvalid = "Renk bilgileri geçersiz!";

        public static string BrandAvailable = "Marka zaten mevcut!";
        public static string BrandAdded = "Marka eklendi!";
        public static string BrandDeleted = "Marka silindi!";
        public static string BrandUpdated = "Marka bilgileri güncellendi!";
        public static string BrandInvalid = "Marka bilgileri geçersiz!";

        public static string UserAvailable = "Kullanıcı zaten mevcut!";
        public static string UserAdded = "Kullanıcı eklendi!";
        public static string UserDeleted = "Kullanıcı silindi!";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi!";
        public static string UserInvalid = "Kullanıcı bilgileri geçersiz!";

        public static string CustomerAvailable = "Müşteri zaten mevcut!";
        public static string CustomerAdded = "Müşteri eklendi!";
        public static string CustomerDeleted = "Müşteri silindi!";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi!";
        public static string CustomerInvalid = "Müşteri bilgileri geçersiz!";

        public static string RentalAdded = "Araç kiralama işlemi başarılı!";
        public static string RentalDeleted = "Araç kiralama işlemi iptal edildi!";
        public static string RentalUpdated = "Araç kiralama işlemi güncellendi!";
        public static string RentalFailed = "Araç şuan müsait değil!";
        public static string RentalReturn = "Araç teslim alındı!";
        public static string RentalInvalid = "Girilen bilgiler geçersiz!";
        public static string CarCheckImageLimited="Araç resim limitine ulaştı!";

        public static string AddedCarImages = "Araba resmi eklendi!";
        public static string NotFoundImage= "Resim bulunamadı!";
        public static string DeletedImage="Resim silindi!";
        public static string UpdatedImage="Resim güncellendi!";

        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string PasswordError = "Hatalı parola!";
        public static string SuccessfulLogin = "Giriş başarılı!";
        public static string UserAlreadyExist = "Bu kullanıcı zaten mevcut!";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi!";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu!";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string RentalDetailsListed = "Detaylı kiralama listelendi!";

    }
}
