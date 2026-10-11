# GestionBanque
# Bank Account Management System (C# OOP)

A robust console-based banking application built in C# to demonstrate core **Object-Oriented Programming (OOP)** principles.

## 🚀 Features
- **Encapsulation:** Protected fields and validated properties ensuring data integrity.
- **Inheritance:** A strong hierarchy featuring a base class (`CompteBancaire`) and specialized derived classes (`CompteEpargne` and `CompteCourant`).
- **Polymorphism:** Method overriding (`virtual` / `override`) for customized descriptions and withdrawal logic.
- **Interactive Menu:** Fully interactive console interface allowing users to create accounts, deposit, withdraw, apply interests, and display records dynamically.

## 🏗️ Class Structure
1. **`CompteBancaire` (Base Class):** Manages account numbers with an automatic static counter, titular, and balance with validation.
2. **`CompteEpargne` (Savings Account):** Inherits from base, implements a fixed interest rate, and provides an interest calculation method.
3. **`CompteCourant` (Current Account):** Inherits from base, implements a fixed overdraft limit (`Découvert`), and overrides withdrawal rules to allow negative balances within limits.

## 💻 Technologies Used
- C# (.NET)
- Object-Oriented Programming (OOP)
