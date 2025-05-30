# 💾 Aplikacja internetowa E-commerce – Sklep z grami

Aplikacja e-commerce stworzona w technologii **Blazor Server** umożliwia zarządzanie sklepem z grami komputerowymi. Wspiera różne role użytkowników (Administrator, Firma, Klient), posiada pełną logikę zarządzania produktami, koszykiem i zamówieniami.

## 🛠 Technologie
- ASP.NET Core (.NET 6/7)
- Blazor Server
- Entity Framework Core (Code-First)
- SQLite
- Bootstrap 5

## 📦 Funkcje systemu

### Ogólne:
- Koszyk z dynamiczną kalkulacją ceny
- Rejestracja, logowanie oraz możliwość edycji danych po rejestracji
- Filtrowanie i wyszukiwanie

### Dla Administratora:
- Zarządzanie kategoriami produktów (CRUD)
- Dodawanie, edycja, usuwanie gier
- Zarządzanie firmami i użytkownikami
- Obsługa oraz filtrowanie zamówień

### Dla Firmy:
- Składanie zamówień
- Opcja "płać później", umożliwiająca opóźnienie płatności za zamówione produkty
- Możliwość anulowania zamówienia

### Dla Klienta:
- Przeglądanie katalogu gier
- Historia zamówień
- Składanie zamówień

## 🧩 Moduły aplikacji

- **Autoryzacja i role:** Identity + role-based UI
- **Produkty i kategorie:** gry przypisane do kategorii, z danymi (tytuł, cena, wydawca, producent, zdjęcie)
- **Koszyk:** dodawanie/usuwanie pozycji, obliczanie sumy
- **Zamówienia:** składanie zamówień, zarządzanie statusami (zrealizowane, anulowane)
- **Zarządzanie użytkownikami i firmami:** tylko dla administratora

## 📋 Testowe dane logowania

| Rola       | Login                 | Hasło         |
|------------|------------------------|---------------|
| **Admin**  | ja@szef.pl             | `zaq1@WSX`    |
| **Firma**  | boss@kierownik.com     | `zaq1@WSX`    |
|            | firma@xz.com           | `zaq1@WSX`    |
| **Klient** | test@mail.com          | `zaq1@WSX`    |
|            | user@mail.com          | `UsersPass1!` |

## 🚀 Uruchamianie aplikacji

### Wymagania:
- .NET 6 SDK lub nowszy
- Visual Studio 2022+ z obsługą Blazor/ASP.NET
- SQLite (lokalnie wbudowany w aplikację)

### Kroki:

1. **Sklonuj repozytorium:**
 ```bash
 git clone https://github.com/twoj-user/GameShop.git
 cd GameShop
 ```

2. **Otwórz projekt w Visual Studio**
Plik rozwiązania: GameShop.sln

3. **Uruchom aplikację:**
- Visual Studio: F5 lub Ctrl+F5
- Terminal:
```bash
dotnet run
```

4. **Dostęp:**
Aplikacja działa domyślnie pod adresem https://localhost:5001/

## 📃 Licencja
Projekt edukacyjny – do swobodnego użytku, edycji i rozbudowy.
