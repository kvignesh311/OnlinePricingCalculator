
# Online Pricing Calculator

A full-stack pricing calculator application built with:

- **Frontend:** React (Vite) – Hosted on Vercel  
- **Backend:** .NET 8 Web API – Hosted on Render  
- **Database:** Supabase (PostgreSQL)

---

## 🌐 Live URLs

- **Frontend App:** https://online-pricing-calculator.vercel.app/
- **Backend API:** https://onlinepricingcalculator.onrender.com

---

## 🛒 Discount Rules

### 🟠 Orange
- **Buy 1 Get 1 Free**
- Valid from **Jan 1, 2025 – Dec 31, 2025**

### 🍎 Apple
- **Buy 2 Get 1 Free**
- Valid from **Jan 1, 2026 – Dec 31, 2026**

### 🍌 Banana
- **Flat 10% Discount**
- Valid from **Jan 1, 2026 – Dec 31, 2026**

### 🥭 Mango
- **Flat 20% Discount**
- Valid from **Jan 1, 2025 – Dec 31, 2025**

### 🍇 Grapes
- **Buy 1 Get 1 Free AND Flat 15% Discount**
- Only one discount is applied — whichever gives the **maximum benefit**
- Valid from **Jan 1, 2026 – Dec 31, 2026**

### 🥝 Kiwi
- **No discount available**

---

## 🚀 API Endpoints

### GET  
https://onlinepricingcalculator.onrender.com/api/items

Returns all active items.

---

### POST  
https://onlinepricingcalculator.onrender.com/api/pricing/calculate

#### Example Request

```json
{
  "items": [
    { "itemId": 1, "quantity": 3 },
    { "itemId": 2, "quantity": 2 }
  ]
}
```

Returns detailed pricing including:

- Original price
- Discount applied
- Total payable amount

---

## ⚙️ Project Structure

```
backend/
    PricingCalculator.Domain
    PricingCalculator.Application
    PricingCalculator.Infrastructure
    PricingCalculator.Api

frontend/
    pricing-calculator-ui
```

---

## 📦 Deployment Architecture

Browser → Vercel (React Frontend) → Render (.NET API) → Supabase (PostgreSQL)

---

## 🛠 Tech Stack

- .NET 8 Web API
- Entity Framework Core
- PostgreSQL (Supabase)
- React + Vite
- TypeScript
- Docker (Backend deployment)

---

## 👨‍💻 Author

Vignesh Kumar
