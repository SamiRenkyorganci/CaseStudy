# CaseStudy README

[English](#english-readme) | [Türkçe](#türkçe-readme)

## English README <a name="english-readme"></a>

This repository contains two separate projects: "CodeGenerate" and "OCRJsonParse".

### Q1 - CodeGenerate Project

This project aims to generate unique 8-character codes as per the request of a fast-moving consumer goods company operating in the food sector.

**Technologies Used:**
- C# programming language
- Random number generation and character selection algorithms

**Project Details:**
This project includes an algorithm that generates 8-character codes using randomly selected characters from the provided character set. Necessary checks are implemented to ensure code uniqueness and to keep the likelihood of manipulation low.

### Q2 - OCRJsonParse Project

This project is designed to process the JSON response obtained from a SaaS service, as part of a receipt scanning system.

**Technologies Used:**
- C# programming language
- JSON data processing library (Newtonsoft.Json)

**Project Details:**
This project involves parsing the JSON response received from the SaaS service and appropriately placing the text related to the receipt in a way that corresponds to its appearance in the image. OCR processing is not covered in this example; the focus is solely on processing the JSON data.

**How to Use:**
1. Build each of the CodeGenerate and OCRJsonParse projects separately. Select the respective project as the startup project.
2. Run the compiled applications to observe the functionality of the projects.

---

If you encounter any issues while running the projects or need more detailed explanations, please feel free to reach out to me.

---

## Türkçe README <a name="türkçe-readme"></a>

Bu depo, "CodeGenerate" ve "OCRJsonParse" olmak üzere iki ayrı projeyi içermektedir.

### Soru 1 - CodeGenerate Projesi

Bu proje, hızlı tüketim sektöründe faaliyet gösteren bir gıda firmasının talebi doğrultusunda, 8 haneli benzersiz kodların üretilmesini sağlamaktadır.

**Kullanılan Teknolojiler:**
- C# programlama dili
- Rastgele sayı üretimi ve karakter seçimi algoritmaları

**Proje Detayları:**
Bu proje, verilen karakter kümesi içerisinden rastgele seçilen karakterlerle 8 haneli kodları oluşturan bir algoritma içermektedir. Kodların benzersiz olması için gerekli kontroller yapılmakta ve manipülasyon olasılığı düşük tutulmaktadır.

### Soru 2 - OCRJsonParse Projesi

Bu proje, bir fiş tarama sistemi için SaaS hizmetinden alınan JSON yanıtının uygun şekilde işlenmesini sağlamaktadır.

**Kullanılan Teknolojiler:**
- C# programlama dili
- JSON veri işleme kütüphanesi (Newtonsoft.Json)

**Proje Detayları:**
Bu proje, SaaS hizmetinden gelen JSON yanıtını parse ederek, fişe ait metni görseldeki yerine uygun şekilde yerleştiren bir işlemi içermektedir. OCR işlemi bu örnekte ele alınmamış, sadece JSON verisinin işlenmesine odaklanılmıştır.

**Nasıl Kullanılır:**
1. CodeGenerate ve OCRJsonParse projelerinin her biri için ayrı ayrı derlemeleri yapın. İlgili proje için başlangıç ​​projesi olarak seçiniz.
2. Derlenmiş uygulamaları çalıştırarak projelerin işlevselliğini gözlemleyebilirsiniz.

---

Eğer projeleri çalıştırırken herhangi bir sorunla karşılaşırsanız veya daha fazla detaylı açıklamaya ihtiyacınız olursa, lütfen bana ulaşmaktan çekinmeyin.
