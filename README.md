# Aplikacja internetowa E-commerce
Aplikacja która pozwala na zarządzanie sklepem z grami komputerowymi
## Założenia i opis projektu
Tematem projektu jest stworzenie kompletnego sklepu internetowego, który specjalizuje się w sprzedaży gier komputerowych.  
Sklep umożliwia zarządzanie asortymentem poprzez dodawanie, edycję i usuwanie produktów, a także pozwala użytkownikom na przeglądanie dostępnych gier i dodawanie ich do koszyka.
## Role użytkowników i uprawnienia
W projekcie istnieje podział na role przypisane do kont użytkowników, które determinują różne funkcje i uprawnienia dostępne na stronie:
- Użytkownik z rolą Administrator (Admin):
  - Może zarządzać kategoriami produktów, dodawać nowe kategorie, edytować istniejące i usuwać niepotrzebne
  - Ma pełną kontrolę nad produktami w sklepie, może dodawać nowe produkty, edytować istniejące (opis, cena, obrazek) oraz usuwać nieaktualne
  - Zarządza firmami, które kupują gry w sklepie, może dodawać, edytować i usuwać informacje o firmach
  - Ma dostęp do danych użytkowników, może przeglądać, edytować i usuwać konta
  - Zarządza zamówieniami, może przeglądać wszystkie zamówienia, aktualizować ich dane, oznaczać jako zrealizowane lub anulować
- Użytkownik z rolą Firma (Company):
  - Może składać zamówienia na produkty dostępne w sklepie.
  - Ma specjalną opcję płacenia później, umożliwiającą opóźnienie płatności za zamówione produkty.
  - Może anulować swoje zamówienie.
- Użytkownik z rolą Klient (Customer):
  - Może przeglądać katalog gier, dodawać wybrane pozycje do koszyka i składać zamówienia.
  - Ma dostęp do historii swoich zamówień i może sprawdzać ich status.
## Elementy i funkcje zawarte w projekcie
- Wyświetlanie katalogu gier
  - Sklep prezentuje użytkownikom listę dostępnych gier wraz z ich szczegółowymi informacjami, takimi jak tytuł, opis, cena, producent, wydawca, zdjęcie
  - Użytkownicy mogą przeglądać katalog i filtrować gry według różnych kryteriów, takich jak gatunek, platforma, wydawca itp.
- Dodawanie, edycja i usuwanie produktów
  - Administrator ma możliwość dodawania nowych produktów do sklepu, edytowania istniejących produktów (np. zmiana opisu, ceny, obrazka) oraz usuwania nieaktualnych pozycji
- Rejestracja i zarządzanie kontem
  - Użytkownicy mogą zarejestrować się w sklepie
  - Po zalogowaniu użytkownik ma możliwość zmiany swojego adresu e-mail lub hasła
  - Użytkownicy uzyskują również opcję usunięcia konta, która usuwa wszystkie powiązane informacje
- Koszyk i kalkulacja ceny
  - Użytkownicy mogą dodawać wybrane gry do koszyka, a system automatycznie oblicza całkowitą cenę zamówienia na podstawie ilości produktów i ich cen. Sumaryczna cena jest dynamicznie aktualizowana po dodaniu lub usunięciu
pozycji z koszyka.
- Składanie zamówień
  - Użytkownicy z rolami Klient lub Firma mogą składać zamówienia
  - Administratorzy mogą finalizować zamówienia, podając niezbędne informacje, takie jak nazwę dostawcy i numer śledzenia przesyłki
- Zarządzanie zamówieniami
  - Administrator ma możliwość przeglądania wszystkich złożonych zamówień, filtrowania ich według statusu zamówienia oraz aktualizowania danych zamówień
  - Użytkownik z rolą Firma może anulować zamówienie
  - Po wysłaniu produktu sklep oznacza zamówienie jako zrealizowane.
## Dane użytkowników do testowania
- Użytkownicy z rolą Customer:
  - Login: test@mail.com – Hasło: zaq1@WSX
  - Login: user@mail.com – Hasło: UsersPass1!
- Użytkownicy z rolą Admin:
  - Login: ja@szef.pl – Hasło: zaq1@WSX
- Użytkownicy z rolą Company:
  - Login: boss@kierownik.com – Hasło: zaq1@WSX
  - Login: firma@xz.com – Hasło: zaq1@WSX
## Interfejs użytkownika
![image](https://github.com/Verthie/GameShop/assets/47531645/094e86d6-3386-42be-8645-b6bac0860842)
![image](https://github.com/Verthie/GameShop/assets/47531645/938bd49b-e519-4ced-bb32-1d2ffc554dfe)
![image](https://github.com/Verthie/GameShop/assets/47531645/b9df09cd-66bc-4029-87b7-b6483bae5e36)
![image](https://github.com/Verthie/GameShop/assets/47531645/4fbf73ec-e6e9-48ea-9890-f5ef324c7337)
