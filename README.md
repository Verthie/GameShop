# 💾 Aplikacja internetowa E-commerce – Sklep z grami

Aplikacja e-commerce stworzona w technologii **Blazor Server** umożliwia zarządzanie sklepem z grami komputerowymi. Wspiera różne role użytkowników (Administrator, Firma, Klient), posiada pełną logikę zarządzania produktami, koszykiem i zamówieniami.

## 🛠 Technologie
- ASP.NET Core (.NET 7)
- Blazor Server
- Entity Framework Core (Code-First)
- SQLite
- Bootstrap 5

## 🧩 Moduły aplikacji

- **Autoryzacja i role:** Identity + role-based UI
- **Produkty i kategorie:** gry przypisane do kategorii, z danymi (tytuł, cena, wydawca, producent, zdjęcie), opcja filtrowania
- **Koszyk:** dodawanie/usuwanie pozycji, obliczanie sumy
- **Zamówienia:** składanie zamówień, zarządzanie statusami (zrealizowane, anulowane)
- **Zarządzanie użytkownikami i firmami:** tylko dla administratora

## 📦 Specjalne funkcje systemu

### Dla Administratora:
- Zarządzanie kategoriami produktów (CRUD)
- Dodawanie, edycja, usuwanie gier
- Zarządzanie firmami i użytkownikami
- Finalizacja oraz anulowanie zamówień

### Dla Firmy:
- Opcja "płać później", umożliwiająca opóźnienie płatności za zamówione produkty
- Możliwość anulowania zamówienia

## 🧾 Uprawnienia i dostęp
| Czynność                            | Admin | Firma | Klient |
|------------------------------------|:-----:|:-----:|:------:|
| Przegląd katalogu                  | ✅    | ✅    | ✅     |
| Dodawanie/usuwanie gier            | ✅    | ❌    | ❌     |
| Składanie zamówień                 | ❌    | ✅    | ✅     |
| Finalizacja/anulowanie zamówień    | ✅    | ✅    | ❌     |
| Zarządzanie firmami/użytkownikami  | ✅    | ❌    | ❌     |

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
 git clone https://github.com/Verthie/GameShop.git
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

## 📃 Licencja
Projekt edukacyjny – do swobodnego użytku, edycji i rozbudowy.
