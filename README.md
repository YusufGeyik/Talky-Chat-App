[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/uelKf0-p)
[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-8d59dc4de5201274e310e4c54b9627a8934c3b88527886e3b421487c677d23eb.svg)](https://classroom.github.com/a/uelKf0-p)
Server tabanlı mesajlaşma uygulaması.
1. Motivasyonunuz (Neden böyle bir proje yapmak istiyorsunuz

Sevdiklerimle acil durumlarda yaygın uygulamaların yaşadığı hizmet kopuklukları (deprem anı ve sonrasında aşırı kullanıma bağlı whatsapp vb uygulamalarda ve telefon hatlarında yaşanan hizmet aksaklıkları) veya yaygın kullanılan uygulamaların yaptığı  işgalci veri hasatlarına ve saklamalarına maruz kalmadan güvenilir ve güvenli bir şekilde iletişim kurabilmek için bu uygulamayı geliştirmek istiyorum.

2. Amacınız (Proje sonunda ortaya çıkan yazılımın ne gibi özellikleri olacak.)
 Gerek projenin deadline'ı ve benim bilgi bakımından yetersizliğim dolayısıyla. Bu dönem projesi için ortaya çıkan uygulama asıl amaç olan uygulamanın bir demosu şeklinde olacak. Data ve server güvenliği vb belli başlıkları bu projenin içinde gerçekleştirmeyip bahsi geçen uygulamanın işlevsel bir demosu niteliğinde olacak.
 Bu demo şunları içerecek:
 -Kullanıcı adı ve şifre ile kayıt
 -kullanıcı adı ve şifre ile giriş
 -Yapılan sohbetlerin localde kontaklar ile birlikte tutulması ve program açılınca getirilmesi ve devam ettirilmesi.
 -Bir kontakla karşılıklı veya grup olarak sohbet başlatma,dahil olma ve mesajlaşma
 -Kullanıcı bilgilerinin ve sohbet geçmişlerinin databasede yedeklenmesi
 

3. Projenizde kullanacığınız muhtemel veritabanı tabloları neler olacaktır.
Projenin ilerleyen kısımlarında optimum tasarıma ulaşma yolunda değişme  ihtimali olmakla beraber, "Users" ve "Chats" tabloları projenin muhtemel tabloları olacaktır.
Bunlardan Chat tablosu  "ChatID" primary keyine sahip olacak.
Her bir satır dahili chat kontakları,ve chat geçmişini vb ayrıca foreign key olarak UserID tutacak.
Users tablosu ise yine benzersiz bir UserID primary keyine sahip olacak.
Bunun yanı sıra Users tablosundaki her satır kullanıcının username, password,ip ve tercih edilen port ve online-offline gibi bilgileri tutacak.
Belki ilerleyen aşamalarda username ve password ayrı kullanıcı ip ve port bilgileri ayrı bir tabloda tutulabilir buna projenin gidişatına göre karar vereceğim.
