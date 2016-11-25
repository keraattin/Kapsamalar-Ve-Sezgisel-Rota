# Minimum Kapsamalar Ve Sezgisel Rota Algoritmasi

## **Minimum Kapsamalar Nedir ?**

- Minimum kapsamalar bize en d�s�k maliyetle veya en az sayida eleman kullanarak
en �ok isi yapabilmemizi saglar.�rnegin bir n�bet �izelgesi olusturulacak ise
kisi sayisi kadar satir ve g�n sayisi kadar sutun olusturulur, 
kisilerin musait oldugu g�nler belirlenir ve tabloya yerlestirilir sonrasinda
minimum kapsama adimlari uygulandiginda en az kisi ile en �ok verim elde edilir,
daha dogrusu t�m g�nler kapatilmis olur.

## **Minimum Kapsamalar Nasil Yapilir ?**

- Minimum kapsamalarda �ncelikli olan sey mutlak satir bulmaktir,
bu y�zden s�rekli olarak mutlak satir aranir bulunamaz ise tekrar kapsama islemleri
veya satir silme islemleri uygulanarak tekrar aranir. Bulunan mutlak satirlar 
kapsamaya yazilir.Bu islemler bos matris elde edilinceye kadar devam eder.

## **Mutlak Satir Nedir ?**

- Sutun agirlik degeri 1 olan degerin bulundugu satir "mutlak satir" olarak adlandirilir.